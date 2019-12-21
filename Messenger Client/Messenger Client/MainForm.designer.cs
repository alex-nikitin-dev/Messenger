using SplashScreenLib;
namespace Messenger_Client
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Белый список", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Чёрный Список", System.Windows.Forms.HorizontalAlignment.Left);
            this.TrayIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.TC_State = new System.Windows.Forms.ToolStripMenuItem();
            this.Tray_MChat_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MM_File0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_ShutDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Collect = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Net0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_State = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_ShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Contact0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Add_Contact = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Find_Contact = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_View0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Topmost = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MM_MainChat = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Params = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PullOut = new System.Windows.Forms.ToolStripMenuItem();
            this.Push = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Help0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_About = new System.Windows.Forms.ToolStripMenuItem();
            this.UserView = new System.Windows.Forms.ListView();
            this.UserNickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UVC_SendPrivate = new System.Windows.Forms.ToolStripMenuItem();
            this.UVC_SendMail = new System.Windows.Forms.ToolStripMenuItem();
            this.UVC_MoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.UVC_AddContact = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectTimer = new System.Windows.Forms.Timer(this.components);
            this.ProtectionPanel = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.CreateAccount = new System.Windows.Forms.LinkLabel();
            this.SavePassword = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.MM_CreateRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayContext.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.UserViewContext.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ProtectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIco
            // 
            this.TrayIco.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIco.BalloonTipTitle = "Messenger";
            this.TrayIco.ContextMenuStrip = this.TrayContext;
            this.TrayIco.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIco.Icon")));
            this.TrayIco.Text = "Messenger";
            this.TrayIco.Visible = true;
            this.TrayIco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIco_MouseDoubleClick);
            // 
            // TrayContext
            // 
            this.TrayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayShowWindow,
            this.TC_State,
            this.Tray_MChat_Login,
            this.TrayExit});
            this.TrayContext.Name = "TrayContext";
            this.TrayContext.Size = new System.Drawing.Size(188, 92);
            // 
            // TrayShowWindow
            // 
            this.TrayShowWindow.Name = "TrayShowWindow";
            this.TrayShowWindow.Size = new System.Drawing.Size(187, 22);
            this.TrayShowWindow.Text = "Спрятать";
            this.TrayShowWindow.Click += new System.EventHandler(this.TrayShowWindow_Click);
            // 
            // TC_State
            // 
            this.TC_State.Name = "TC_State";
            this.TC_State.Size = new System.Drawing.Size(187, 22);
            this.TC_State.Text = "Состояние";
            // 
            // Tray_MChat_Login
            // 
            this.Tray_MChat_Login.Name = "Tray_MChat_Login";
            this.Tray_MChat_Login.Size = new System.Drawing.Size(187, 22);
            this.Tray_MChat_Login.Text = "Войти в главный чат";
            this.Tray_MChat_Login.Click += new System.EventHandler(this.Tray_MChat_Login_Click);
            // 
            // TrayExit
            // 
            this.TrayExit.Name = "TrayExit";
            this.TrayExit.Size = new System.Drawing.Size(187, 22);
            this.TrayExit.Text = "Завершить работу";
            this.TrayExit.Click += new System.EventHandler(this.TrayExit_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_File0,
            this.MM_Net0,
            this.MM_Contact0,
            this.MM_View0,
            this.MM_Help0});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(287, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "MainMenu";
            // 
            // MM_File0
            // 
            this.MM_File0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_ShutDown,
            this.MM_Collect});
            this.MM_File0.Name = "MM_File0";
            this.MM_File0.Size = new System.Drawing.Size(48, 20);
            this.MM_File0.Text = "Файл";
            this.MM_File0.DropDownOpening += new System.EventHandler(this.MM_File0_DropDownOpening);
            // 
            // MM_ShutDown
            // 
            this.MM_ShutDown.Name = "MM_ShutDown";
            this.MM_ShutDown.Size = new System.Drawing.Size(111, 22);
            this.MM_ShutDown.Text = "Выход";
            this.MM_ShutDown.Click += new System.EventHandler(this.MM_ShutDown_Click);
            // 
            // MM_Collect
            // 
            this.MM_Collect.Name = "MM_Collect";
            this.MM_Collect.Size = new System.Drawing.Size(111, 22);
            this.MM_Collect.Text = "Collect";
            this.MM_Collect.Click += new System.EventHandler(this.MM_Collect_Click);
            // 
            // MM_Net0
            // 
            this.MM_Net0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_Logout,
            this.MM_State,
            this.MM_ShowLog});
            this.MM_Net0.Name = "MM_Net0";
            this.MM_Net0.Size = new System.Drawing.Size(44, 20);
            this.MM_Net0.Text = "Сеть";
            // 
            // MM_Logout
            // 
            this.MM_Logout.Name = "MM_Logout";
            this.MM_Logout.Size = new System.Drawing.Size(142, 22);
            this.MM_Logout.Text = "Выход";
            this.MM_Logout.Click += new System.EventHandler(this.MM_Logout_Click);
            // 
            // MM_State
            // 
            this.MM_State.Name = "MM_State";
            this.MM_State.Size = new System.Drawing.Size(142, 22);
            this.MM_State.Text = "Состояние";
            // 
            // MM_ShowLog
            // 
            this.MM_ShowLog.Name = "MM_ShowLog";
            this.MM_ShowLog.Size = new System.Drawing.Size(142, 22);
            this.MM_ShowLog.Text = "Лог ошибок";
            this.MM_ShowLog.Click += new System.EventHandler(this.MM_ShowLog_Click);
            // 
            // MM_Contact0
            // 
            this.MM_Contact0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_Add_Contact,
            this.MM_Find_Contact,
            this.MM_CreateRoom});
            this.MM_Contact0.Name = "MM_Contact0";
            this.MM_Contact0.Size = new System.Drawing.Size(62, 20);
            this.MM_Contact0.Text = "Контакт";
            // 
            // MM_Add_Contact
            // 
            this.MM_Add_Contact.Name = "MM_Add_Contact";
            this.MM_Add_Contact.Size = new System.Drawing.Size(180, 22);
            this.MM_Add_Contact.Text = "Добавить контакт";
            this.MM_Add_Contact.Click += new System.EventHandler(this.MM_Add_Contact_Click);
            // 
            // MM_Find_Contact
            // 
            this.MM_Find_Contact.Name = "MM_Find_Contact";
            this.MM_Find_Contact.Size = new System.Drawing.Size(180, 22);
            this.MM_Find_Contact.Text = "Поиск";
            this.MM_Find_Contact.Click += new System.EventHandler(this.MM_Find_Contact_Click);
            // 
            // MM_View0
            // 
            this.MM_View0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_Topmost,
            this.MM_Hide,
            this.toolStripSeparator1,
            this.MM_MainChat,
            this.MM_Params,
            this.toolStripSeparator3,
            this.PullOut,
            this.Push});
            this.MM_View0.Name = "MM_View0";
            this.MM_View0.Size = new System.Drawing.Size(39, 20);
            this.MM_View0.Text = "Вид";
            this.MM_View0.DropDownOpening += new System.EventHandler(this.MM_View_DropDownOpening);
            // 
            // MM_Topmost
            // 
            this.MM_Topmost.Name = "MM_Topmost";
            this.MM_Topmost.Size = new System.Drawing.Size(162, 22);
            this.MM_Topmost.Text = "Поверх всех";
            this.MM_Topmost.Click += new System.EventHandler(this.MM_Topmost_Click);
            // 
            // MM_Hide
            // 
            this.MM_Hide.Name = "MM_Hide";
            this.MM_Hide.Size = new System.Drawing.Size(162, 22);
            this.MM_Hide.Text = "Свернуть в трей";
            this.MM_Hide.Click += new System.EventHandler(this.MM_Hide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // MM_MainChat
            // 
            this.MM_MainChat.Name = "MM_MainChat";
            this.MM_MainChat.Size = new System.Drawing.Size(162, 22);
            this.MM_MainChat.Text = "Главный чат";
            this.MM_MainChat.Click += new System.EventHandler(this.MM_MainChat_Click);
            // 
            // MM_Params
            // 
            this.MM_Params.Name = "MM_Params";
            this.MM_Params.Size = new System.Drawing.Size(162, 22);
            this.MM_Params.Text = "Параметры";
            this.MM_Params.Click += new System.EventHandler(this.MM_Params_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(159, 6);
            // 
            // PullOut
            // 
            this.PullOut.Name = "PullOut";
            this.PullOut.Size = new System.Drawing.Size(162, 22);
            this.PullOut.Text = "Выдвинуть";
            this.PullOut.Click += new System.EventHandler(this.PullOut_Click);
            // 
            // Push
            // 
            this.Push.Name = "Push";
            this.Push.Size = new System.Drawing.Size(162, 22);
            this.Push.Text = "Задвинуть";
            this.Push.Click += new System.EventHandler(this.Push_Click);
            // 
            // MM_Help0
            // 
            this.MM_Help0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_About});
            this.MM_Help0.Name = "MM_Help0";
            this.MM_Help0.Size = new System.Drawing.Size(68, 20);
            this.MM_Help0.Text = "Помощь";
            // 
            // MM_About
            // 
            this.MM_About.Name = "MM_About";
            this.MM_About.Size = new System.Drawing.Size(149, 22);
            this.MM_About.Text = "О программе";
            this.MM_About.Click += new System.EventHandler(this.MM_About_Click);
            // 
            // UserView
            // 
            this.UserView.AllowDrop = true;
            this.UserView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserView.BackColor = System.Drawing.Color.Beige;
            this.UserView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserNickName,
            this.UserStatus});
            this.UserView.ContextMenuStrip = this.UserViewContext;
            this.UserView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.UserView.FullRowSelect = true;
            listViewGroup1.Header = "Белый список";
            listViewGroup1.Name = "WhiteGroup";
            listViewGroup2.Header = "Чёрный Список";
            listViewGroup2.Name = "BlackGroup";
            this.UserView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.UserView.Location = new System.Drawing.Point(12, 27);
            this.UserView.MultiSelect = false;
            this.UserView.Name = "UserView";
            this.UserView.Size = new System.Drawing.Size(264, 479);
            this.UserView.TabIndex = 3;
            this.UserView.UseCompatibleStateImageBehavior = false;
            this.UserView.View = System.Windows.Forms.View.Details;
            this.UserView.SizeChanged += new System.EventHandler(this.UserView_SizeChanged);
            this.UserView.DoubleClick += new System.EventHandler(this.UserView_DoubleClick);
            // 
            // UserNickName
            // 
            this.UserNickName.Text = "Имя пользователя";
            this.UserNickName.Width = 116;
            // 
            // UserStatus
            // 
            this.UserStatus.Text = "Статус";
            this.UserStatus.Width = 145;
            // 
            // UserViewContext
            // 
            this.UserViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UVC_SendPrivate,
            this.UVC_SendMail,
            this.UVC_MoveUser,
            this.UVC_AddContact});
            this.UserViewContext.Name = "UserViewContext";
            this.UserViewContext.Size = new System.Drawing.Size(270, 92);
            this.UserViewContext.Opening += new System.ComponentModel.CancelEventHandler(this.UserViewContext_Opening);
            // 
            // UVC_SendPrivate
            // 
            this.UVC_SendPrivate.Name = "UVC_SendPrivate";
            this.UVC_SendPrivate.Size = new System.Drawing.Size(269, 22);
            this.UVC_SendPrivate.Text = "Отправить мгновенное сообщение";
            this.UVC_SendPrivate.Click += new System.EventHandler(this.UVC_SendPrivate_Click);
            // 
            // UVC_SendMail
            // 
            this.UVC_SendMail.Name = "UVC_SendMail";
            this.UVC_SendMail.Size = new System.Drawing.Size(269, 22);
            this.UVC_SendMail.Text = "Отправить почту";
            this.UVC_SendMail.Click += new System.EventHandler(this.UVC_SendMail_Click);
            // 
            // UVC_MoveUser
            // 
            this.UVC_MoveUser.Name = "UVC_MoveUser";
            this.UVC_MoveUser.Size = new System.Drawing.Size(269, 22);
            this.UVC_MoveUser.Text = "Запретить";
            this.UVC_MoveUser.Click += new System.EventHandler(this.UVC_MoveUser_Click);
            // 
            // UVC_AddContact
            // 
            this.UVC_AddContact.Name = "UVC_AddContact";
            this.UVC_AddContact.Size = new System.Drawing.Size(269, 22);
            this.UVC_AddContact.Text = "Добавить контакт";
            this.UVC_AddContact.Click += new System.EventHandler(this.UVC_AddContact_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusInfo});
            this.StatusBar.Location = new System.Drawing.Point(0, 509);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(287, 22);
            this.StatusBar.TabIndex = 5;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusInfo
            // 
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.Size = new System.Drawing.Size(72, 17);
            this.StatusInfo.Text = "Отсоеденён";
            // 
            // ConnectTimer
            // 
            this.ConnectTimer.Interval = 5000;
            this.ConnectTimer.Tick += new System.EventHandler(this.DoConnect);
            // 
            // ProtectionPanel
            // 
            this.ProtectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProtectionPanel.BackgroundImage = global::Messenger_Client.Properties.Resources.mianbgnd1;
            this.ProtectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProtectionPanel.Controls.Add(this.btnUser);
            this.ProtectionPanel.Controls.Add(this.btnDefault);
            this.ProtectionPanel.Controls.Add(this.CreateAccount);
            this.ProtectionPanel.Controls.Add(this.SavePassword);
            this.ProtectionPanel.Controls.Add(this.lblPassword);
            this.ProtectionPanel.Controls.Add(this.lblLogin);
            this.ProtectionPanel.Controls.Add(this.Password);
            this.ProtectionPanel.Controls.Add(this.Login);
            this.ProtectionPanel.Controls.Add(this.btnLogin);
            this.ProtectionPanel.Location = new System.Drawing.Point(0, 27);
            this.ProtectionPanel.Name = "ProtectionPanel";
            this.ProtectionPanel.Size = new System.Drawing.Size(287, 479);
            this.ProtectionPanel.TabIndex = 4;
            this.ProtectionPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.MainLayout);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUser.ForeColor = System.Drawing.Color.Navy;
            this.btnUser.Location = new System.Drawing.Point(91, 303);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(105, 23);
            this.btnUser.TabIndex = 8;
            this.btnUser.Text = "User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Visible = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDefault.ForeColor = System.Drawing.Color.Red;
            this.btnDefault.Location = new System.Drawing.Point(91, 258);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(105, 23);
            this.btnDefault.TabIndex = 7;
            this.btnDefault.Text = "Administrator";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Visible = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // CreateAccount
            // 
            this.CreateAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreateAccount.AutoSize = true;
            this.CreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateAccount.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.CreateAccount.Location = new System.Drawing.Point(100, 447);
            this.CreateAccount.Name = "CreateAccount";
            this.CreateAccount.Size = new System.Drawing.Size(165, 13);
            this.CreateAccount.TabIndex = 6;
            this.CreateAccount.TabStop = true;
            this.CreateAccount.Text = "Создать новую учетную запись";
            this.CreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateAccount_LinkClicked);
            // 
            // SavePassword
            // 
            this.SavePassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SavePassword.Location = new System.Drawing.Point(60, 176);
            this.SavePassword.Name = "SavePassword";
            this.SavePassword.Size = new System.Drawing.Size(121, 17);
            this.SavePassword.TabIndex = 5;
            this.SavePassword.Text = "Запомнить меня";
            this.SavePassword.UseVisualStyleBackColor = true;
            this.SavePassword.CheckedChanged += new System.EventHandler(this.SavePassword_CheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(57, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль";
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(57, 60);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Логин";
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Password.Location = new System.Drawing.Point(65, 129);
            this.Password.MaximumSize = new System.Drawing.Size(200, 20);
            this.Password.MinimumSize = new System.Drawing.Size(80, 20);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(157, 20);
            this.Password.TabIndex = 2;
            this.Password.UseSystemPasswordChar = true;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // Login
            // 
            this.Login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Login.Location = new System.Drawing.Point(65, 76);
            this.Login.MaximumSize = new System.Drawing.Size(200, 20);
            this.Login.MinimumSize = new System.Drawing.Size(80, 20);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(157, 20);
            this.Login.TabIndex = 1;
            this.Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.Location = new System.Drawing.Point(91, 213);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // MM_CreateRoom
            // 
            this.MM_CreateRoom.Name = "MM_CreateRoom";
            this.MM_CreateRoom.Size = new System.Drawing.Size(180, 22);
            this.MM_CreateRoom.Text = "Создать комнату";
            this.MM_CreateRoom.Click += new System.EventHandler(this.MM_CreateRoom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 531);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.ProtectionPanel);
            this.Controls.Add(this.UserView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messenger";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.TrayContext.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.UserViewContext.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ProtectionPanel.ResumeLayout(false);
            this.ProtectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIco;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MM_Help0;
        private System.Windows.Forms.ToolStripMenuItem MM_About;
        private System.Windows.Forms.ContextMenuStrip TrayContext;
        private System.Windows.Forms.ToolStripMenuItem TrayExit;
        private System.Windows.Forms.ToolStripMenuItem TrayShowWindow;
        private System.Windows.Forms.ListView UserView;
        private System.Windows.Forms.ColumnHeader UserNickName;
        private System.Windows.Forms.ColumnHeader UserStatus;
        private System.Windows.Forms.ToolStripMenuItem MM_Contact0;
        private System.Windows.Forms.ToolStripMenuItem MM_Add_Contact;
        private System.Windows.Forms.ToolStripMenuItem MM_Find_Contact;
        private System.Windows.Forms.ToolStripMenuItem MM_View0;
        private System.Windows.Forms.ToolStripMenuItem MM_Topmost;
        private System.Windows.Forms.ToolStripMenuItem MM_Hide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MM_MainChat;
        private System.Windows.Forms.ToolStripMenuItem MM_Params;
        private System.Windows.Forms.ToolStripMenuItem MM_Net0;
        private System.Windows.Forms.ToolStripMenuItem MM_Logout;
        private System.Windows.Forms.ToolStripMenuItem MM_State;
        private System.Windows.Forms.ToolStripMenuItem MM_File0;
        private System.Windows.Forms.ToolStripMenuItem MM_ShutDown;
        private System.Windows.Forms.ToolStripMenuItem Tray_MChat_Login;
        private System.Windows.Forms.Panel ProtectionPanel;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckBox SavePassword;
        private System.Windows.Forms.LinkLabel CreateAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem PullOut;
        private System.Windows.Forms.ToolStripMenuItem Push;
        public System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.ToolStripMenuItem MM_ShowLog;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusInfo;
        private System.Windows.Forms.Timer ConnectTimer;
        private System.Windows.Forms.ToolStripMenuItem MM_Collect;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.ToolStripMenuItem TC_State;
        private System.Windows.Forms.ContextMenuStrip UserViewContext;
        private System.Windows.Forms.ToolStripMenuItem UVC_SendPrivate;
        private System.Windows.Forms.ToolStripMenuItem UVC_SendMail;
        private System.Windows.Forms.ToolStripMenuItem UVC_MoveUser;
        private System.Windows.Forms.ToolStripMenuItem UVC_AddContact;
        private System.Windows.Forms.ToolStripMenuItem MM_CreateRoom;
    }
}

