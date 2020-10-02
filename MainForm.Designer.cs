namespace InstallPrinters
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmbPrintersModel = new System.Windows.Forms.ComboBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdbUSB = new System.Windows.Forms.RadioButton();
            this.rdbLan = new System.Windows.Forms.RadioButton();
            this.txtLanName = new System.Windows.Forms.TextBox();
            this.lblGoInstall = new System.Windows.Forms.Label();
            this.lblModelText = new System.Windows.Forms.Label();
            this.lblNetNameText = new System.Windows.Forms.Label();
            this.lblPlugInText = new System.Windows.Forms.Label();
            this.cmbInstalledPrinters = new System.Windows.Forms.ComboBox();
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.btnGetInstalledPrinters = new System.Windows.Forms.Button();
            this.btnDdefaultPrinter = new System.Windows.Forms.Button();
            this.btnDellPrinters = new System.Windows.Forms.Button();
            this.chbOptions = new System.Windows.Forms.CheckBox();
            this.lblDescriptionText = new System.Windows.Forms.Label();
            this.tlpInstall = new System.Windows.Forms.ToolTip(this.components);
            this.tlpGetInstalled = new System.Windows.Forms.ToolTip(this.components);
            this.tlpTestPrint = new System.Windows.Forms.ToolTip(this.components);
            this.tlpDelPrint = new System.Windows.Forms.ToolTip(this.components);
            this.tlpDefault = new System.Windows.Forms.ToolTip(this.components);
            this.tlpInstalledPrintersList = new System.Windows.Forms.ToolTip(this.components);
            this.tlpPrintersModel = new System.Windows.Forms.ToolTip(this.components);
            this.tlpLanName = new System.Windows.Forms.ToolTip(this.components);
            this.tlpLanPrinterRdb = new System.Windows.Forms.ToolTip(this.components);
            this.tlpUsbPrinterRdb = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cmbPrintersModel
            // 
            this.cmbPrintersModel.BackColor = System.Drawing.Color.White;
            this.cmbPrintersModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPrintersModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cmbPrintersModel.FormattingEnabled = true;
            this.cmbPrintersModel.Location = new System.Drawing.Point(27, 110);
            this.cmbPrintersModel.Name = "cmbPrintersModel";
            this.cmbPrintersModel.Size = new System.Drawing.Size(242, 23);
            this.cmbPrintersModel.TabIndex = 0;
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInstall.Location = new System.Drawing.Point(39, 225);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(106, 44);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "Установить";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(151, 225);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 44);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdbUSB
            // 
            this.rdbUSB.AutoSize = true;
            this.rdbUSB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdbUSB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbUSB.Location = new System.Drawing.Point(164, 36);
            this.rdbUSB.Name = "rdbUSB";
            this.rdbUSB.Size = new System.Drawing.Size(93, 17);
            this.rdbUSB.TabIndex = 3;
            this.rdbUSB.TabStop = true;
            this.rdbUSB.Text = "Принтер USB";
            this.rdbUSB.UseVisualStyleBackColor = false;
            this.rdbUSB.CheckedChanged += new System.EventHandler(this.rdbUSB_CheckedChanged);
            // 
            // rdbLan
            // 
            this.rdbLan.AutoSize = true;
            this.rdbLan.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdbLan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbLan.Location = new System.Drawing.Point(42, 36);
            this.rdbLan.Name = "rdbLan";
            this.rdbLan.Size = new System.Drawing.Size(111, 17);
            this.rdbLan.TabIndex = 4;
            this.rdbLan.TabStop = true;
            this.rdbLan.Text = "Сетевой принтер";
            this.rdbLan.UseVisualStyleBackColor = false;
            this.rdbLan.CheckedChanged += new System.EventHandler(this.rdbLan_CheckedChanged);
            // 
            // txtLanName
            // 
            this.txtLanName.BackColor = System.Drawing.Color.White;
            this.txtLanName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLanName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtLanName.Location = new System.Drawing.Point(27, 172);
            this.txtLanName.Name = "txtLanName";
            this.txtLanName.Size = new System.Drawing.Size(242, 23);
            this.txtLanName.TabIndex = 5;
            // 
            // lblGoInstall
            // 
            this.lblGoInstall.AutoSize = true;
            this.lblGoInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoInstall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGoInstall.Location = new System.Drawing.Point(36, 207);
            this.lblGoInstall.Name = "lblGoInstall";
            this.lblGoInstall.Size = new System.Drawing.Size(0, 13);
            this.lblGoInstall.TabIndex = 6;
            // 
            // lblModelText
            // 
            this.lblModelText.AutoSize = true;
            this.lblModelText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblModelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblModelText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModelText.Location = new System.Drawing.Point(39, 90);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Size = new System.Drawing.Size(193, 17);
            this.lblModelText.TabIndex = 7;
            this.lblModelText.Text = "Выберите модель принтера";
            // 
            // lblNetNameText
            // 
            this.lblNetNameText.AutoSize = true;
            this.lblNetNameText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNetNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNetNameText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNetNameText.Location = new System.Drawing.Point(39, 152);
            this.lblNetNameText.Name = "lblNetNameText";
            this.lblNetNameText.Size = new System.Drawing.Size(216, 17);
            this.lblNetNameText.TabIndex = 8;
            this.lblNetNameText.Text = "Введите сетевое имя принтера";
            // 
            // lblPlugInText
            // 
            this.lblPlugInText.AutoSize = true;
            this.lblPlugInText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlugInText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPlugInText.Location = new System.Drawing.Point(42, 9);
            this.lblPlugInText.Name = "lblPlugInText";
            this.lblPlugInText.Size = new System.Drawing.Size(197, 13);
            this.lblPlugInText.TabIndex = 9;
            this.lblPlugInText.Text = "Выберите тип подключения принтера";
            // 
            // cmbInstalledPrinters
            // 
            this.cmbInstalledPrinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbInstalledPrinters.FormattingEnabled = true;
            this.cmbInstalledPrinters.Location = new System.Drawing.Point(306, 110);
            this.cmbInstalledPrinters.Name = "cmbInstalledPrinters";
            this.cmbInstalledPrinters.Size = new System.Drawing.Size(218, 23);
            this.cmbInstalledPrinters.TabIndex = 10;
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.BackColor = System.Drawing.Color.Goldenrod;
            this.btnTestPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestPrint.Location = new System.Drawing.Point(418, 172);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(106, 44);
            this.btnTestPrint.TabIndex = 11;
            this.btnTestPrint.Text = "Пробная печать";
            this.btnTestPrint.UseVisualStyleBackColor = false;
            this.btnTestPrint.Click += new System.EventHandler(this.BtnTestPrint_Click);
            // 
            // btnGetInstalledPrinters
            // 
            this.btnGetInstalledPrinters.BackColor = System.Drawing.Color.Goldenrod;
            this.btnGetInstalledPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetInstalledPrinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetInstalledPrinters.Location = new System.Drawing.Point(306, 172);
            this.btnGetInstalledPrinters.Name = "btnGetInstalledPrinters";
            this.btnGetInstalledPrinters.Size = new System.Drawing.Size(106, 44);
            this.btnGetInstalledPrinters.TabIndex = 12;
            this.btnGetInstalledPrinters.Text = "Установленные принтеры";
            this.btnGetInstalledPrinters.UseVisualStyleBackColor = false;
            this.btnGetInstalledPrinters.Click += new System.EventHandler(this.BtnGetInstalledPrinters_Click);
            // 
            // btnDdefaultPrinter
            // 
            this.btnDdefaultPrinter.BackColor = System.Drawing.Color.Goldenrod;
            this.btnDdefaultPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDdefaultPrinter.Location = new System.Drawing.Point(418, 225);
            this.btnDdefaultPrinter.Name = "btnDdefaultPrinter";
            this.btnDdefaultPrinter.Size = new System.Drawing.Size(106, 44);
            this.btnDdefaultPrinter.TabIndex = 13;
            this.btnDdefaultPrinter.Text = "Принтер по умолчанию";
            this.btnDdefaultPrinter.UseVisualStyleBackColor = false;
            this.btnDdefaultPrinter.Click += new System.EventHandler(this.BtnDdefaultPrinter_Click);
            // 
            // btnDellPrinters
            // 
            this.btnDellPrinters.BackColor = System.Drawing.Color.Goldenrod;
            this.btnDellPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDellPrinters.Location = new System.Drawing.Point(306, 225);
            this.btnDellPrinters.Name = "btnDellPrinters";
            this.btnDellPrinters.Size = new System.Drawing.Size(106, 44);
            this.btnDellPrinters.TabIndex = 14;
            this.btnDellPrinters.Text = "Удалить принтер";
            this.btnDellPrinters.UseVisualStyleBackColor = false;
            this.btnDellPrinters.Click += new System.EventHandler(this.BtnDellPrinters_Click);
            // 
            // chbOptions
            // 
            this.chbOptions.AutoSize = true;
            this.chbOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chbOptions.Location = new System.Drawing.Point(42, 59);
            this.chbOptions.Name = "chbOptions";
            this.chbOptions.Size = new System.Drawing.Size(149, 17);
            this.chbOptions.TabIndex = 15;
            this.chbOptions.Text = "управление принтерами";
            this.chbOptions.UseVisualStyleBackColor = true;
            this.chbOptions.CheckedChanged += new System.EventHandler(this.ChbOptions_CheckedChanged);
            // 
            // lblDescriptionText
            // 
            this.lblDescriptionText.AutoSize = true;
            this.lblDescriptionText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescriptionText.Location = new System.Drawing.Point(303, 9);
            this.lblDescriptionText.Name = "lblDescriptionText";
            this.lblDescriptionText.Size = new System.Drawing.Size(260, 91);
            this.lblDescriptionText.TabIndex = 16;
            this.lblDescriptionText.Text = resources.GetString("lblDescriptionText.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(296, 285);
            this.Controls.Add(this.lblDescriptionText);
            this.Controls.Add(this.chbOptions);
            this.Controls.Add(this.btnDellPrinters);
            this.Controls.Add(this.btnDdefaultPrinter);
            this.Controls.Add(this.btnGetInstalledPrinters);
            this.Controls.Add(this.btnTestPrint);
            this.Controls.Add(this.cmbInstalledPrinters);
            this.Controls.Add(this.lblPlugInText);
            this.Controls.Add(this.lblNetNameText);
            this.Controls.Add(this.lblModelText);
            this.Controls.Add(this.lblGoInstall);
            this.Controls.Add(this.txtLanName);
            this.Controls.Add(this.rdbLan);
            this.Controls.Add(this.rdbUSB);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.cmbPrintersModel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Установка принтера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrintersModel;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbUSB;
        private System.Windows.Forms.RadioButton rdbLan;
        private System.Windows.Forms.TextBox txtLanName;
        private System.Windows.Forms.Label lblGoInstall;
        private System.Windows.Forms.Label lblModelText;
        private System.Windows.Forms.Label lblNetNameText;
        private System.Windows.Forms.Label lblPlugInText;
        private System.Windows.Forms.ComboBox cmbInstalledPrinters;
        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.Button btnGetInstalledPrinters;
        private System.Windows.Forms.Button btnDdefaultPrinter;
        private System.Windows.Forms.Button btnDellPrinters;
        private System.Windows.Forms.CheckBox chbOptions;
        private System.Windows.Forms.Label lblDescriptionText;
        private System.Windows.Forms.ToolTip tlpInstall;
        private System.Windows.Forms.ToolTip tlpGetInstalled;
        private System.Windows.Forms.ToolTip tlpTestPrint;
        private System.Windows.Forms.ToolTip tlpDelPrint;
        private System.Windows.Forms.ToolTip tlpDefault;
        private System.Windows.Forms.ToolTip tlpInstalledPrintersList;
        private System.Windows.Forms.ToolTip tlpPrintersModel;
        private System.Windows.Forms.ToolTip tlpLanName;
        private System.Windows.Forms.ToolTip tlpLanPrinterRdb;
        private System.Windows.Forms.ToolTip tlpUsbPrinterRdb;
    }
}

