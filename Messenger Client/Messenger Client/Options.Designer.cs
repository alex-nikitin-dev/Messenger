namespace Messenger_Client
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.OptionsTab = new System.Windows.Forms.TabControl();
            this.GeneralOptions = new System.Windows.Forms.TabPage();
            this.btnShowWatch = new System.Windows.Forms.Button();
            this.chkWatchForce = new System.Windows.Forms.CheckBox();
            this.Байда = new System.Windows.Forms.CheckBox();
            this.gboxProfile = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.AutoRun = new System.Windows.Forms.CheckBox();
            this.ConnectOptionsTab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.message_delay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Host = new System.Windows.Forms.TextBox();
            this.SecurityOptions = new System.Windows.Forms.TabPage();
            this.btnToBlack = new System.Windows.Forms.Button();
            this.btnToWite = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstBlack = new System.Windows.Forms.ListBox();
            this.lstWite = new System.Windows.Forms.ListBox();
            this.MChatOptions = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MChatColorReset = new System.Windows.Forms.Button();
            this.TimeBackColor = new System.Windows.Forms.Label();
            this.TimeForeColor = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MessageTextBackColor = new System.Windows.Forms.Label();
            this.MessageTextForeColor = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lll = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.MChatOwnBackColor = new System.Windows.Forms.Label();
            this.MChatUListBackColor = new System.Windows.Forms.Label();
            this.MChatUserBackColor = new System.Windows.Forms.Label();
            this.MChatBackColor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.MChatOwnForeColor = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MChatUListForeColor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.MChatUserForeColor = new System.Windows.Forms.Label();
            this.Protect = new System.Windows.Forms.Panel();
            this.lblSubWarning = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DlgColor = new System.Windows.Forms.ColorDialog();
            this.OptionsTab.SuspendLayout();
            this.GeneralOptions.SuspendLayout();
            this.gboxProfile.SuspendLayout();
            this.ConnectOptionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.message_delay)).BeginInit();
            this.SecurityOptions.SuspendLayout();
            this.MChatOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Protect.SuspendLayout();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsTab
            // 
            this.OptionsTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.OptionsTab.Controls.Add(this.GeneralOptions);
            this.OptionsTab.Controls.Add(this.ConnectOptionsTab);
            this.OptionsTab.Controls.Add(this.SecurityOptions);
            this.OptionsTab.Controls.Add(this.MChatOptions);
            this.OptionsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTab.Location = new System.Drawing.Point(0, 0);
            this.OptionsTab.Multiline = true;
            this.OptionsTab.Name = "OptionsTab";
            this.OptionsTab.SelectedIndex = 0;
            this.OptionsTab.Size = new System.Drawing.Size(390, 318);
            this.OptionsTab.TabIndex = 1;
            // 
            // GeneralOptions
            // 
            this.GeneralOptions.Controls.Add(this.btnShowWatch);
            this.GeneralOptions.Controls.Add(this.chkWatchForce);
            this.GeneralOptions.Controls.Add(this.Байда);
            this.GeneralOptions.Controls.Add(this.gboxProfile);
            this.GeneralOptions.Controls.Add(this.AutoRun);
            this.GeneralOptions.Location = new System.Drawing.Point(4, 25);
            this.GeneralOptions.Name = "GeneralOptions";
            this.GeneralOptions.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralOptions.Size = new System.Drawing.Size(382, 289);
            this.GeneralOptions.TabIndex = 0;
            this.GeneralOptions.Text = "Общие";
            this.GeneralOptions.UseVisualStyleBackColor = true;
            // 
            // btnShowWatch
            // 
            this.btnShowWatch.Location = new System.Drawing.Point(243, 231);
            this.btnShowWatch.Name = "btnShowWatch";
            this.btnShowWatch.Size = new System.Drawing.Size(104, 23);
            this.btnShowWatch.TabIndex = 6;
            this.btnShowWatch.Text = "Показать вотч";
            this.btnShowWatch.UseVisualStyleBackColor = true;
            this.btnShowWatch.Visible = false;
            // 
            // chkWatchForce
            // 
            this.chkWatchForce.AutoSize = true;
            this.chkWatchForce.Location = new System.Drawing.Point(22, 235);
            this.chkWatchForce.Name = "chkWatchForce";
            this.chkWatchForce.Size = new System.Drawing.Size(121, 17);
            this.chkWatchForce.TabIndex = 5;
            this.chkWatchForce.Text = "Форсировать вотч";
            this.chkWatchForce.UseVisualStyleBackColor = true;
            this.chkWatchForce.CheckedChanged += new System.EventHandler(this.chkWatchForce_CheckedChanged);
            // 
            // Байда
            // 
            this.Байда.AutoSize = true;
            this.Байда.Location = new System.Drawing.Point(22, 258);
            this.Байда.Name = "Байда";
            this.Байда.Size = new System.Drawing.Size(107, 17);
            this.Байда.TabIndex = 0;
            this.Байда.Text = "Включить байду";
            this.Байда.UseVisualStyleBackColor = true;
            this.Байда.CheckedChanged += new System.EventHandler(this.Байда_CheckedChanged);
            // 
            // gboxProfile
            // 
            this.gboxProfile.Controls.Add(this.label6);
            this.gboxProfile.Controls.Add(this.label5);
            this.gboxProfile.Controls.Add(this.btnEditProfile);
            this.gboxProfile.Location = new System.Drawing.Point(22, 75);
            this.gboxProfile.Name = "gboxProfile";
            this.gboxProfile.Size = new System.Drawing.Size(336, 115);
            this.gboxProfile.TabIndex = 4;
            this.gboxProfile.TabStop = false;
            this.gboxProfile.Text = "Личные данные";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = " еmail и другие. ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Изменить такие личные данные как логин, пароль,";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Location = new System.Drawing.Point(157, 86);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(168, 23);
            this.btnEditProfile.TabIndex = 2;
            this.btnEditProfile.Text = "Редактировать профиль";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // AutoRun
            // 
            this.AutoRun.AutoSize = true;
            this.AutoRun.Location = new System.Drawing.Point(22, 36);
            this.AutoRun.Name = "AutoRun";
            this.AutoRun.Size = new System.Drawing.Size(255, 17);
            this.AutoRun.TabIndex = 1;
            this.AutoRun.Text = "Автоматически запускать вместе с Windows";
            this.AutoRun.UseVisualStyleBackColor = true;
            this.AutoRun.CheckedChanged += new System.EventHandler(this.AutoRun_CheckedChanged);
            // 
            // ConnectOptionsTab
            // 
            this.ConnectOptionsTab.Controls.Add(this.label7);
            this.ConnectOptionsTab.Controls.Add(this.message_delay);
            this.ConnectOptionsTab.Controls.Add(this.label2);
            this.ConnectOptionsTab.Controls.Add(this.Port);
            this.ConnectOptionsTab.Controls.Add(this.label1);
            this.ConnectOptionsTab.Controls.Add(this.Host);
            this.ConnectOptionsTab.Location = new System.Drawing.Point(4, 25);
            this.ConnectOptionsTab.Name = "ConnectOptionsTab";
            this.ConnectOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectOptionsTab.Size = new System.Drawing.Size(382, 289);
            this.ConnectOptionsTab.TabIndex = 1;
            this.ConnectOptionsTab.Text = "Соединение";
            this.ConnectOptionsTab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "Set delay  time in miliseconds \r\nfor sending message";
            // 
            // message_delay
            // 
            this.message_delay.Location = new System.Drawing.Point(215, 136);
            this.message_delay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.message_delay.Name = "message_delay";
            this.message_delay.Size = new System.Drawing.Size(68, 20);
            this.message_delay.TabIndex = 4;
            this.message_delay.ValueChanged += new System.EventHandler(this.message_delay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(215, 80);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(145, 20);
            this.Port.TabIndex = 2;
            this.Port.Text = "1100";
            this.Port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP адрес сервера";
            // 
            // Host
            // 
            this.Host.Location = new System.Drawing.Point(215, 41);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(145, 20);
            this.Host.TabIndex = 0;
            this.Host.Text = "127.0.0.1";
            this.Host.TextChanged += new System.EventHandler(this.Host_TextChanged);
            // 
            // SecurityOptions
            // 
            this.SecurityOptions.Controls.Add(this.btnToBlack);
            this.SecurityOptions.Controls.Add(this.btnToWite);
            this.SecurityOptions.Controls.Add(this.label4);
            this.SecurityOptions.Controls.Add(this.label3);
            this.SecurityOptions.Controls.Add(this.lstBlack);
            this.SecurityOptions.Controls.Add(this.lstWite);
            this.SecurityOptions.Location = new System.Drawing.Point(4, 25);
            this.SecurityOptions.Name = "SecurityOptions";
            this.SecurityOptions.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityOptions.Size = new System.Drawing.Size(382, 289);
            this.SecurityOptions.TabIndex = 2;
            this.SecurityOptions.Text = "Конфиденциальность";
            this.SecurityOptions.UseVisualStyleBackColor = true;
            // 
            // btnToBlack
            // 
            this.btnToBlack.Location = new System.Drawing.Point(142, 104);
            this.btnToBlack.Name = "btnToBlack";
            this.btnToBlack.Size = new System.Drawing.Size(99, 23);
            this.btnToBlack.TabIndex = 5;
            this.btnToBlack.Text = "Запретить>>";
            this.btnToBlack.UseVisualStyleBackColor = true;
            this.btnToBlack.Click += new System.EventHandler(this.btnToBlack_Click);
            // 
            // btnToWite
            // 
            this.btnToWite.Location = new System.Drawing.Point(142, 63);
            this.btnToWite.Name = "btnToWite";
            this.btnToWite.Size = new System.Drawing.Size(99, 23);
            this.btnToWite.TabIndex = 4;
            this.btnToWite.Text = "<<Разрешить";
            this.btnToWite.UseVisualStyleBackColor = true;
            this.btnToWite.Click += new System.EventHandler(this.btnToWite_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Чёрный список";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Белый список";
            // 
            // lstBlack
            // 
            this.lstBlack.FormattingEnabled = true;
            this.lstBlack.Location = new System.Drawing.Point(247, 45);
            this.lstBlack.Name = "lstBlack";
            this.lstBlack.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBlack.Size = new System.Drawing.Size(129, 212);
            this.lstBlack.TabIndex = 1;
            // 
            // lstWite
            // 
            this.lstWite.FormattingEnabled = true;
            this.lstWite.Location = new System.Drawing.Point(6, 45);
            this.lstWite.Name = "lstWite";
            this.lstWite.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWite.Size = new System.Drawing.Size(128, 212);
            this.lstWite.TabIndex = 0;
            // 
            // MChatOptions
            // 
            this.MChatOptions.Controls.Add(this.groupBox1);
            this.MChatOptions.Location = new System.Drawing.Point(4, 25);
            this.MChatOptions.Name = "MChatOptions";
            this.MChatOptions.Size = new System.Drawing.Size(382, 289);
            this.MChatOptions.TabIndex = 3;
            this.MChatOptions.Text = "Главный чат";
            this.MChatOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MChatColorReset);
            this.groupBox1.Controls.Add(this.TimeBackColor);
            this.groupBox1.Controls.Add(this.TimeForeColor);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.MessageTextBackColor);
            this.groupBox1.Controls.Add(this.MessageTextForeColor);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lll);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.MChatOwnBackColor);
            this.groupBox1.Controls.Add(this.MChatUListBackColor);
            this.groupBox1.Controls.Add(this.MChatUserBackColor);
            this.groupBox1.Controls.Add(this.MChatBackColor);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.MChatOwnForeColor);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.MChatUListForeColor);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.MChatUserForeColor);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 283);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            // 
            // MChatColorReset
            // 
            this.MChatColorReset.Location = new System.Drawing.Point(189, 254);
            this.MChatColorReset.Name = "MChatColorReset";
            this.MChatColorReset.Size = new System.Drawing.Size(156, 23);
            this.MChatColorReset.TabIndex = 21;
            this.MChatColorReset.Text = "Восстановить умолчания";
            this.MChatColorReset.UseVisualStyleBackColor = true;
            this.MChatColorReset.Click += new System.EventHandler(this.MChatColorReset_Click);
            // 
            // TimeBackColor
            // 
            this.TimeBackColor.BackColor = System.Drawing.Color.Coral;
            this.TimeBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeBackColor.Location = new System.Drawing.Point(281, 179);
            this.TimeBackColor.Name = "TimeBackColor";
            this.TimeBackColor.Size = new System.Drawing.Size(56, 23);
            this.TimeBackColor.TabIndex = 20;
            this.TimeBackColor.Text = "          ";
            this.TimeBackColor.Click += new System.EventHandler(this.TimeBackColor_Click);
            // 
            // TimeForeColor
            // 
            this.TimeForeColor.BackColor = System.Drawing.Color.Coral;
            this.TimeForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeForeColor.Location = new System.Drawing.Point(182, 178);
            this.TimeForeColor.Name = "TimeForeColor";
            this.TimeForeColor.Size = new System.Drawing.Size(56, 23);
            this.TimeForeColor.TabIndex = 18;
            this.TimeForeColor.Text = "          ";
            this.TimeForeColor.Click += new System.EventHandler(this.TimeForeColor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Время в главном чате";
            // 
            // MessageTextBackColor
            // 
            this.MessageTextBackColor.BackColor = System.Drawing.Color.Coral;
            this.MessageTextBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTextBackColor.Location = new System.Drawing.Point(281, 142);
            this.MessageTextBackColor.Name = "MessageTextBackColor";
            this.MessageTextBackColor.Size = new System.Drawing.Size(56, 23);
            this.MessageTextBackColor.TabIndex = 17;
            this.MessageTextBackColor.Text = "          ";
            this.MessageTextBackColor.Click += new System.EventHandler(this.MessageTextBackColor_Click);
            // 
            // MessageTextForeColor
            // 
            this.MessageTextForeColor.BackColor = System.Drawing.Color.Coral;
            this.MessageTextForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTextForeColor.Location = new System.Drawing.Point(182, 141);
            this.MessageTextForeColor.Name = "MessageTextForeColor";
            this.MessageTextForeColor.Size = new System.Drawing.Size(56, 23);
            this.MessageTextForeColor.TabIndex = 15;
            this.MessageTextForeColor.Text = "          ";
            this.MessageTextForeColor.Click += new System.EventHandler(this.MessageTextForeColor_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Окно ввода сообщений";
            // 
            // lll
            // 
            this.lll.AutoSize = true;
            this.lll.Location = new System.Drawing.Point(278, 11);
            this.lll.Name = "lll";
            this.lll.Size = new System.Drawing.Size(56, 13);
            this.lll.TabIndex = 14;
            this.lll.Text = "BackColor";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(186, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "ForeColor";
            // 
            // MChatOwnBackColor
            // 
            this.MChatOwnBackColor.BackColor = System.Drawing.Color.Coral;
            this.MChatOwnBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatOwnBackColor.Location = new System.Drawing.Point(281, 35);
            this.MChatOwnBackColor.Name = "MChatOwnBackColor";
            this.MChatOwnBackColor.Size = new System.Drawing.Size(56, 23);
            this.MChatOwnBackColor.TabIndex = 9;
            this.MChatOwnBackColor.Text = "          ";
            this.MChatOwnBackColor.Click += new System.EventHandler(this.MChatOwnBackColor_Click);
            // 
            // MChatUListBackColor
            // 
            this.MChatUListBackColor.BackColor = System.Drawing.Color.Coral;
            this.MChatUListBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatUListBackColor.Location = new System.Drawing.Point(281, 107);
            this.MChatUListBackColor.Name = "MChatUListBackColor";
            this.MChatUListBackColor.Size = new System.Drawing.Size(56, 23);
            this.MChatUListBackColor.TabIndex = 10;
            this.MChatUListBackColor.Text = "          ";
            this.MChatUListBackColor.Click += new System.EventHandler(this.MChatUListBackColor_Click);
            // 
            // MChatUserBackColor
            // 
            this.MChatUserBackColor.BackColor = System.Drawing.Color.Coral;
            this.MChatUserBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatUserBackColor.Location = new System.Drawing.Point(281, 71);
            this.MChatUserBackColor.Name = "MChatUserBackColor";
            this.MChatUserBackColor.Size = new System.Drawing.Size(56, 23);
            this.MChatUserBackColor.TabIndex = 11;
            this.MChatUserBackColor.Text = "          ";
            this.MChatUserBackColor.Click += new System.EventHandler(this.MChatUserBackColor_Click);
            // 
            // MChatBackColor
            // 
            this.MChatBackColor.BackColor = System.Drawing.Color.Coral;
            this.MChatBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatBackColor.Location = new System.Drawing.Point(237, 217);
            this.MChatBackColor.Name = "MChatBackColor";
            this.MChatBackColor.Size = new System.Drawing.Size(56, 23);
            this.MChatBackColor.TabIndex = 12;
            this.MChatBackColor.Text = "          ";
            this.MChatBackColor.Click += new System.EventHandler(this.MChatBackColor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Собственные сообщения";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Сообщения пользователей";
            // 
            // MChatOwnForeColor
            // 
            this.MChatOwnForeColor.BackColor = System.Drawing.Color.Coral;
            this.MChatOwnForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatOwnForeColor.Location = new System.Drawing.Point(182, 34);
            this.MChatOwnForeColor.Name = "MChatOwnForeColor";
            this.MChatOwnForeColor.Size = new System.Drawing.Size(56, 23);
            this.MChatOwnForeColor.TabIndex = 1;
            this.MChatOwnForeColor.Text = "          ";
            this.MChatOwnForeColor.Click += new System.EventHandler(this.MChatOwnForeColor_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Фон Главного чата";
            // 
            // MChatUListForeColor
            // 
            this.MChatUListForeColor.BackColor = System.Drawing.Color.Coral;
            this.MChatUListForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatUListForeColor.Location = new System.Drawing.Point(182, 106);
            this.MChatUListForeColor.Name = "MChatUListForeColor";
            this.MChatUListForeColor.Size = new System.Drawing.Size(56, 23);
            this.MChatUListForeColor.TabIndex = 2;
            this.MChatUListForeColor.Text = "          ";
            this.MChatUListForeColor.Click += new System.EventHandler(this.MChatUListForeColor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Список пользователей";
            // 
            // MChatUserForeColor
            // 
            this.MChatUserForeColor.BackColor = System.Drawing.Color.Coral;
            this.MChatUserForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MChatUserForeColor.Location = new System.Drawing.Point(182, 70);
            this.MChatUserForeColor.Name = "MChatUserForeColor";
            this.MChatUserForeColor.Size = new System.Drawing.Size(56, 23);
            this.MChatUserForeColor.TabIndex = 3;
            this.MChatUserForeColor.Text = "          ";
            this.MChatUserForeColor.Click += new System.EventHandler(this.MChatUserForeColor_Click);
            // 
            // Protect
            // 
            this.Protect.BackColor = System.Drawing.SystemColors.ControlText;
            this.Protect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Protect.Controls.Add(this.lblSubWarning);
            this.Protect.Controls.Add(this.lblWarning);
            this.Protect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Protect.ForeColor = System.Drawing.Color.Cornsilk;
            this.Protect.Location = new System.Drawing.Point(0, 0);
            this.Protect.Name = "Protect";
            this.Protect.Size = new System.Drawing.Size(390, 318);
            this.Protect.TabIndex = 5;
            // 
            // lblSubWarning
            // 
            this.lblSubWarning.AutoSize = true;
            this.lblSubWarning.Location = new System.Drawing.Point(85, 135);
            this.lblSubWarning.Name = "lblSubWarning";
            this.lblSubWarning.Size = new System.Drawing.Size(199, 13);
            this.lblSubWarning.TabIndex = 1;
            this.lblSubWarning.Text = "Это не должно занять более 5 секунд";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarning.Location = new System.Drawing.Point(40, 98);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(294, 17);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "Подождите, ожидается ответ сервера";
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.IsSplitterFixed = true;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.Protect);
            this.MainContainer.Panel1.Controls.Add(this.OptionsTab);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.btnOK);
            this.MainContainer.Panel2.Controls.Add(this.btnApply);
            this.MainContainer.Panel2.Controls.Add(this.btnCancel);
            this.MainContainer.Size = new System.Drawing.Size(390, 349);
            this.MainContainer.SplitterDistance = 318;
            this.MainContainer.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(149, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(311, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DlgColor
            // 
            this.DlgColor.FullOpen = true;
            this.DlgColor.SolidColorOnly = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 349);
            this.Controls.Add(this.MainContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Options_KeyDown);
            this.Load += new System.EventHandler(this.Options_Load);
            this.OptionsTab.ResumeLayout(false);
            this.GeneralOptions.ResumeLayout(false);
            this.GeneralOptions.PerformLayout();
            this.gboxProfile.ResumeLayout(false);
            this.gboxProfile.PerformLayout();
            this.ConnectOptionsTab.ResumeLayout(false);
            this.ConnectOptionsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.message_delay)).EndInit();
            this.SecurityOptions.ResumeLayout(false);
            this.SecurityOptions.PerformLayout();
            this.MChatOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Protect.ResumeLayout(false);
            this.Protect.PerformLayout();
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OptionsTab;
        private System.Windows.Forms.TabPage GeneralOptions;
        private System.Windows.Forms.TabPage ConnectOptionsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Host;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.CheckBox Байда;
        private System.Windows.Forms.CheckBox AutoRun;
        private System.Windows.Forms.TabPage SecurityOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.GroupBox gboxProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox lstBlack;
        public System.Windows.Forms.ListBox lstWite;
        public System.Windows.Forms.Button btnToBlack;
        public System.Windows.Forms.Button btnToWite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown message_delay;
        public System.Windows.Forms.Panel Protect;
        public System.Windows.Forms.Label lblSubWarning;
        public System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox chkWatchForce;
        public System.Windows.Forms.Button btnShowWatch;
        private System.Windows.Forms.TabPage MChatOptions;
        private System.Windows.Forms.ColorDialog DlgColor;
        private System.Windows.Forms.Label MChatUserForeColor;
        private System.Windows.Forms.Label MChatUListForeColor;
        private System.Windows.Forms.Label MChatOwnForeColor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lll;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label MChatOwnBackColor;
        private System.Windows.Forms.Label MChatUListBackColor;
        private System.Windows.Forms.Label MChatUserBackColor;
        private System.Windows.Forms.Label MChatBackColor;
        private System.Windows.Forms.Label MessageTextBackColor;
        private System.Windows.Forms.Label MessageTextForeColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label TimeBackColor;
        private System.Windows.Forms.Label TimeForeColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button MChatColorReset;

    }
}