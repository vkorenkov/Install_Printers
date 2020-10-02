using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.Net.NetworkInformation;
using System.Collections;

namespace InstallPrinters
{
    #region Класс главного окна
    public partial class MainForm : Form
    {
        #region Переменные и массивы

        // Делегат передачи данных из одного потока в другой
        public delegate void Delegate(string tempName);

        // Переменная для проверки сетевого статуса принтера
        bool netStat;

        // Удалены жесткие ссылки на файлы
        #region Массивы с данными для установки

        static List<string> AllInstallData = new List<string>();

        // переменная путь для принтеров
        string GeneralPath;

        // DataSource для cmbPrintersModel
        string[] LanModels;

        // Массив с именами драйверов принтеров
        string[] driversNames;

        // Массив с моделями которые поддерживают только USB подключение. Необходим для проверки выбранного принтра в режиме установки по сети
        string[] usbPrinters;

        #endregion

        // Поле потока установки
        Thread install;

        // Поле потока проверки сетевого статуса
        Thread check;

        #endregion

        #region главное окно

        /// <summary>
        /// Главное окно программы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            try
            {
                AllInstallData = File.ReadAllLines(@"\\PrintersDriversSource\Links.prn").ToList(); // Вставить корректный путь к папке с драйверами принтеров (Папки с драйверами рекомендуется назвать моделями принтеров и поместить в эти папки распакованные драйверы принтеров)
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            GetData();

            // Добавление списка принтеров в combobox cmbPrintersModel
            cmbPrintersModel.DataSource = LanModels;

            // Отключние кнопки установить при запуске программы
            btnInstall.Enabled = false;

            // Отключение поля ввода имени принтера при запуске программы
            txtLanName.Visible = false;
            lblNetNameText.Visible = false;

            // Отключение выбора модели при запуске программы
            cmbPrintersModel.Enabled = false;

            // Подсказка при наведение на кнопу "установить"
            tlpInstall.SetToolTip(btnInstall, "Установка выбранных принтеров");

            // Подсказка при наведение на кнопку "установленные принтеры"
            tlpGetInstalled.SetToolTip(btnGetInstalledPrinters, "Получение установленных в системе принтеров");

            // Подсказка при наведении на кнопку "Пробная печать"
            tlpTestPrint.SetToolTip(btnTestPrint, "Тестовая печать");

            // Подсказка при наведении на кнопку Удаление из ОС выбранного принтера
            tlpDelPrint.SetToolTip(btnDellPrinters, "Удаление выбранного принтера из ОС");

            // Устоновка принтера по умолчанию
            tlpDefault.SetToolTip(btnDdefaultPrinter, "Установка выбранного принтера в качестве основного устройства печати");

            // Подсказка списка установленных принтеров
            tlpInstalledPrintersList.SetToolTip(cmbInstalledPrinters, "Список установленных принтеров в ОС. Для получения списка нажмите "+'"' + "Установленные принтеры" + '"');

            // Подсказка списка моделей принтеров
            tlpPrintersModel.SetToolTip(cmbPrintersModel, "Модели принтеров доступные для установки");

            // Подсказка списка поля ввода сетевого имени принтера
            tlpLanName.SetToolTip(txtLanName, "Поле ввода сетевого имени принтера");

            // Подсказка выбора типа установки сетевого принтера
            tlpLanPrinterRdb.SetToolTip(rdbLan, "Выберите для установки сетевого принтера");

            // Подсказка выбора типа установки USB принтера
            tlpUsbPrinterRdb.SetToolTip(rdbUSB, "Выберите для установки сетевого принтера");
        }

        #endregion


        #region Методы

        private void GetData()
        {
            try
            {
                // переменная путь для принтеров
                GeneralPath = AllInstallData[0];

                // DataSource для cmbPrintersModel
                LanModels = File.ReadAllLines(AllInstallData[1]);

                // Массив с именами драйверов принтеров
                driversNames = File.ReadAllLines(AllInstallData[2]);

                // Массив с моделями которые поддерживают только USB подключение. Необходим для проверки выбранного принтра в режиме установки по сети
                usbPrinters = File.ReadAllLines(AllInstallData[3]);
            }
            catch 
            {
                MessageBox.Show("Ошибка подключения к источнику");
            }
        }

        /// <summary>
        /// Метод получает установленные на компьютере драйверы принтеров и сравнивает с названием модели выбранного принтера.
        /// Если возникнет совпадение модели и драйвера, то метод возвращает значение true 
        /// и  драйвер устанавливаться не будет, произойдет только подключение принтера
        /// </summary>
        /// <param name="printerName"></param>
        /// <returns></returns>
        bool getPrinterDriver(string printerName)
        {
            // Экземпляр класса ManagementObjectSearcher для работы с WMI объектом Win32_PrinterDriver
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PrinterDriver");

            // Цикл для сравнения полученных имен драйверов и названия выбранной модели
            foreach (ManagementObject queryObj in searcher.Get())
            {
                // сравнение название модели и имени принтера. При совпадении метод вернет true
                if (queryObj["Name"].ToString().Contains(printerName))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            // ответ метода при отсутствии совпадений
            return false;
        }


        /// <summary>
        /// Метод меняет lblGoInstall для отражения текущего статуса программы
        /// </summary>
        /// <param name="label"></param>
        void changeLabel(string label)
        {
            lblGoInstall.Text = label;
        }


        /// <summary>
        /// Метод устанавливает драйверы выбранного принтера если getPrinterDriver вернул false
        /// </summary>
        /// <param name="installDriver"></param>
        /// <param name="printerName"></param>
        /// <param name="lanName"></param>
        void InstallPrintersDrivers(string installDriver, string printerName, string lanName) 
        {

            // Вызов метода проверки аличия драйверов
            getPrinterDriver(printerName);

            // Условие при котором getPrinterDriver вернул true
            if (getPrinterDriver(printerName) == true)
            {
                // Создание и запуск потока подключения принтера
                install = new Thread(delegate () { connectPrinter(printerName, lanName); });
                install.Start();
            }

            // Условие при значении false матода getPrinterDriver
            else if (getPrinterDriver(printerName) == false)
            {
                // Передача статуса выполнения установки драйверов в метод changeLabel
                string label = "Установка драйвера " + printerName;
                BeginInvoke(new Delegate(changeLabel), label);

                // инициализация экземпляра класса для запуска процесса установки драйвера
                Process Install = new Process();

                // Запуск командной строки
                Install.StartInfo.FileName = "cmd.exe";

                // отключение окна командной строки
                Install.StartInfo.CreateNoWindow = true; 
                Install.StartInfo.UseShellExecute = false;

                try
                {
                    // Передача параметров потоку install (Путь к драйверам и ключи установки pnputil)
                    Install.StartInfo.Arguments = string.Format("/c pnputil /add-driver " + '"' + installDriver + @"\*.inf" + '"' + " /install /subdirs");

                    // запус процесса
                    Install.Start();

                    // Ожидание завершения предыдущего процесса
                    Install.WaitForExit();

                    // Передача статуса выполнения установки драйверов в метод changeLabel
                    label = "Установка драйвера завершена";
                    BeginInvoke(new Delegate(changeLabel), label);

                    // Условие при котором запускается новый поток подключения принтера
                    if (rdbLan.Checked)
                    {
                        // Создание и запуск потока подключения принтера
                        install = new Thread(delegate () { connectPrinter(printerName, lanName); });
                        install.Start();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Метод создает сетевой порт принтера в соответствии с введенным именем принтера 
        /// и подключает принтер с именем соответствующим выбранному в cmbPrintersModel
        /// </summary>
        /// <param name="printerName"></param>
        /// <param name="lanName"></param>
        void connectPrinter(string printerName, string lanName)
        {

            // Пустая переменная для именем драйвера принтера
            string driverName = string.Empty;

            // Цикл выбора необходимого имени драйвера принтера
            foreach (string temp in driversNames)
            {
                // Если временная переменная с именем драйвера из массива driversNames будет содержать название выбранного принтера, то driverName принимает это значение
                if (temp.Contains(printerName))
                {
                    driverName = temp;
                }
            }

            // Передача статуса добавления принтера в метод changeLabel
            string label = "Добавление принтера " + printerName;
            BeginInvoke(new Delegate(changeLabel), label);

            // Экземпляр класса ManagementObjectSearcher для работы с WMI объектом "Win32_TCPIPPrinterPort". Создание сетевого порта принтера
            ManagementClass createPort = new ManagementClass("Win32_TCPIPPrinterPort");
            ManagementObject port = createPort.CreateInstance();

            // Параметры сетевого порта принтера
            port["Name"] = lanName;
            port["HostAddress"] = lanName;
            port["PortNumber"] = 9100;
            port["Protocol"] = 1;
            port["SNMPCommunity"] = "public";
            port["SNMPEnabled"] = true;
            port["SNMPDevIndex"] = 1;

            // Запись параметров сетвого порта принтера
            PutOptions options = new PutOptions();
            options.Type = PutType.UpdateOrCreate;
            // Применение параметров сетевого порта принтера
            port.Put(options);

            try
            {
                // Экземпляр класса ManagementClass для работы с WMI объектом "Win32_Printer". Подключение принтера
                ManagementClass createPrinter = new ManagementClass("Win32_Printer");
                createPrinter.Get();
                ManagementObject printer = createPrinter.CreateInstance();

                // Параметры подключаемого принтера
                printer["DriverName"] = driverName;
                printer["PortName"] = lanName;
                printer["DeviceID"] = printerName;
                printer["Network"] = true;

                // Запись параметров подключаемого принтера
                PutOptions optionsPrint = new PutOptions();
                optionsPrint.Type = PutType.UpdateOrCreate;
                // Применение параметров сетевого порта принтера
                printer.Put(optionsPrint);

                // Передача статуса добавления принтера в метод changeLabel
                label = "Добавление принтера завершено";
                BeginInvoke(new Delegate(changeLabel), label);
            }
            catch
            {
                // Сообщение при неудачном выполнении метода connectPrinter
                MessageBox.Show("Ошибка применения драйвера");
            }
        }

        /// <summary>
        /// Метод собирает параметры, передает их в метод InstallPrintersDrivers и запуска новый поток
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lanName"></param>
        /// <returns></returns>
        Thread instalation(string model, string lanName)
        {
            try
            {
                // Заполнение переменной, которая содержит полный путь к папке с драйвером выбранного принтера
                string GetModels = GeneralPath + @"\" + model;

                // создание потока с методом InstallPrintersDrivers
                install = new Thread(delegate () { InstallPrintersDrivers(GetModels, model, lanName); });

                // Возврат переменной с параметрами запуска потока с методом InstallPrintersDrivers
                return install;
            }
            catch
            {
                // Сообщение при неудачной попытке обратиться к папке с драйверами выбранного принтера
                MessageBox.Show("Не удалось найти путь к драйверу");
                return null;
            }
            
        }

        /// <summary>
        /// Метод проверяет подключен ли выбранный принтер к ethernet порту. Если метод возвращает true, 
        /// то принтер подключен к сети и будет подключен к данному компьютеру
        /// Если метод возвращает false то будет выведенно сообщение об ошибке
        /// </summary>
        /// <param name="lanName"></param>
        /// <param name="labelInstall"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        bool checkNetStatus(string lanName, string labelInstall, string model)
        {
            try
            { 
                // Инициализация экземпляра класса Ping
                Ping testPing = new Ping();
                PingReply reply = testPing.Send(lanName);

                // При ответе принтера переменная netStat принимает значение true
                if (reply.Status == IPStatus.Success)
                {
                    netStat = true;
                }

                // Если принтер не отвечает на запрос, то переменная netStat принимает значение false
                else
                {
                    netStat = false;
                }
            }
            catch
            {
                netStat = false;
            }

            // При значении переменной netStat - true будет вызван метод instalation
            if (netStat == true)
            {
                try
                {
                    // Вызов метода instalation
                    instalation(model, lanName);

                    // Запуск потока установки драйверов и подключения принтера
                    install.Start();
                }
                catch
                {
                    // При ошибке выполнения происходит очистка lblGoInstall
                    labelInstall = null;
                    BeginInvoke(new Delegate(changeLabel), labelInstall);
                }
            }
            else
            {
                // статус подключения при неудачной попыстке связвться с принтером
                labelInstall = "Принтер не в сети или вы ошиблись в имени";
                BeginInvoke(new Delegate(changeLabel), labelInstall);
            }
            return true;
        }

        /// <summary>
        /// Метод получает установленные в системе принтеры
        /// </summary>
        List<string> installedPrinters()
        {
            List<string> printermass = new List<string>();
            // Инициализация класса WMI для работы с принтерами
            ManagementObjectSearcher searcherInstallPrinters = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Printer");

            // Цикл добавления полученных имен принтеров в коллекцию printermass
            foreach (ManagementObject queryObj in searcherInstallPrinters.Get())
            {
                printermass.Add(queryObj["Name"].ToString());               
            }
            return printermass;
        }

        /// <summary>
        /// Метод посылает на печать тестовую страницу выбранного принтера
        /// </summary>
        void testPrinteing()
        {
            ManagementObject classInstance = new ManagementObject("root\\cimv2", "Win32_Printer.DeviceID='" + cmbInstalledPrinters.SelectedItem + "'", null);

            ManagementBaseObject outParams = classInstance.InvokeMethod("PrintTestPage", null, null);
        }

        /// <summary>
        /// Метод устанавливает выбранный принтер по умолчанию в системе
        /// </summary>
        void defaultPrinter()
        {
            ManagementObject classInstance = new ManagementObject("root\\cimv2", "Win32_Printer.DeviceID='" + cmbInstalledPrinters.SelectedItem + "'", null);

            ManagementBaseObject outParams = classInstance.InvokeMethod("SetDefaultPrinter", null, null);
        }

        /// <summary>
        /// Метод удаляет выбранный принтер из системы
        /// </summary>
        void deletePrinter()
        {
            SelectQuery printer = new SelectQuery("Win32_Printer", "Name = " + '"' + cmbInstalledPrinters.Text + '"');

            ManagementObjectSearcher delete = new ManagementObjectSearcher(printer);

            foreach (ManagementObject prn in delete.Get())
            {
                prn.Delete();
            }
        }

        #endregion

        #region события

        // кнопка выхода из приложения
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Действие при нажатии кнопки btnExit
            Close();
        }

        // Кнопка установки
        private void btnInstall_Click(object sender, EventArgs e)
        {
            // Действия при выбранном rdbLan (сетевая установка)
            if (rdbLan.Checked)
            {
                // Присвоение переменных элементам с вводимыми данными
                string model = cmbPrintersModel.Text;
                string lanName = txtLanName.Text;
                string labelInstall = lblGoInstall.Text;

                // Проверка выбранного принтера на подключение только по USB
                if (usbPrinters.Contains(model))
                {
                    MessageBox.Show("Данный принтер доступен для установки только по USB");
                }
                else
                {
                    // Проверка на пустые значения в cmbPrintersModel и txtLanName
                    if (cmbPrintersModel.SelectedIndex >= 0 && txtLanName.Text != string.Empty)
                    {
                        // Статус Проверки сетевого статуса принтера в lblGoInstall
                        lblGoInstall.Text = "Проверка сетевого статуса принтера";

                        // Создание и запуск потока с методом checkNetStatus
                        check = new Thread(delegate () { checkNetStatus(lanName, labelInstall, model); });
                        check.Start();
                    }
                    // Сообщение при не заполненом сетевом имени принтера
                    else if (txtLanName.Text == string.Empty)
                    {
                        MessageBox.Show("Вы не ввели сетевое имя");
                    }
                    // Сообщение при пустом значении выбора модели
                    else if (cmbPrintersModel.Text == string.Empty)
                    {
                        MessageBox.Show("Вы не выбрали модель");
                    }
                }
            }

            // Действия при выбранном rdbUSB (установка по USB)
            if (rdbUSB.Checked)
            {
                // Условие при выбранной модели принтера
                if (cmbPrintersModel.SelectedIndex >= 0)
                {
                    // Запуск установки драйвера выбранного принтера
                    instalation(cmbPrintersModel.Text, txtLanName.Text);
                    install.Start();
                }
                // Сообщение при пустом значении выбранного принтера
                else if(cmbPrintersModel.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали модель");
                }
            }
            
            // Сообщение при отсутствии выбора типа подключения
            if (rdbLan.Checked == false && rdbUSB.Checked == false) 
            {
                MessageBox.Show("Вы не выбрали тип подключения");
            }
        }

        // Выбор установки принтера по USB
        private void rdbUSB_CheckedChanged(object sender, EventArgs e)
        {
            // Условие при котором открывается возможность выбора модели принтера
            if (rdbUSB.Checked)
            {
                btnInstall.Enabled = true;
                btnInstall.BackColor = Color.Goldenrod;
                txtLanName.Visible = false;
                lblNetNameText.Visible = false;
                cmbPrintersModel.Enabled = true;
                cmbPrintersModel.BackColor = Color.White;
            }
        }

        // Выбор установки сетевого принтера
        private void rdbLan_CheckedChanged(object sender, EventArgs e)
        {
            // Условие при котором открывается возможность выбора модели и ввода сетевого имени принтера
            if (rdbLan.Checked)
            {
                btnInstall.Enabled = true;
                btnInstall.BackColor = Color.Goldenrod;
                txtLanName.Visible = true;
                lblNetNameText.Visible = true;
                cmbPrintersModel.Enabled = true;
                cmbPrintersModel.BackColor = Color.White;
            }
        }   

        // Событие получения установленных принтеров
        private void BtnGetInstalledPrinters_Click(object sender, EventArgs e)
        {
            // Статус выполнения метода installedPrinters
            lblGoInstall.Text = "Получаем принтеры";

            // Формирование списка в cmbInstalledPrinters
            cmbInstalledPrinters.DataSource = installedPrinters();

            lblGoInstall.Text = "Принтеры получены";
        }

        // Событие вызова метода тестовой печати
        private void BtnTestPrint_Click(object sender, EventArgs e)
        {
            testPrinteing();
        }

        // Событие вызова метода установки принтера по умолчанию
        private void BtnDdefaultPrinter_Click(object sender, EventArgs e)
        {
            defaultPrinter();
        }

        // Изменение размера формы при ChbOptions = true
        private void ChbOptions_CheckedChanged(object sender, EventArgs e)
        {
            // Условия изменения размера формы
            if(chbOptions.Checked)
            {
                Width = 576;
            }
            else
            {
                Width = 316;
            }
        }
        
        // Событие вызова метода удаления выбранного принтера
        private void BtnDellPrinters_Click(object sender, EventArgs e)
        {
            // Вызов метода удаления принтера
            deletePrinter();

            // Условие очистки списка выбора принтера cmbInstalledPrinters
            if (installedPrinters().Count > 0)
            {
                cmbInstalledPrinters.DataSource = installedPrinters();
            }
            else
            {
                cmbInstalledPrinters.DataSource = null;
            }
        }
        #endregion
    }
    #endregion
}

