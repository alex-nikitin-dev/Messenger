namespace MessengerServer
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
            this.TrayIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_SwitchDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Params = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MChatUserView = new System.Windows.Forms.ListView();
            this.MChat_Nikname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MChat_userEMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MChat_userIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MChat_userDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChatUsrLstContainer = new System.Windows.Forms.SplitContainer();
            this.Chat = new System.Windows.Forms.RichTextBox();
            this.ChatContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CC_NIK = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_SEP = new System.Windows.Forms.ToolStripSeparator();
            this.CC_NikToChat = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_Expand = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_AutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.UserListTab = new System.Windows.Forms.TabControl();
            this.MChatUserTab = new System.Windows.Forms.TabPage();
            this.MChatListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MCLC_RightPanelExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.MCLC_Ban = new System.Windows.Forms.ToolStripMenuItem();
            this.AttachedUsersTab = new System.Windows.Forms.TabPage();
            this.AttachedListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ALC_RightPanelExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.ALC_DetachUser = new System.Windows.Forms.ToolStripMenuItem();
            this.AttachedUsersView = new System.Windows.Forms.ListView();
            this.AttachedView_Login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttachedView_EMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttachedView_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttachedView_Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BaseVewTab = new System.Windows.Forms.TabPage();
            this.BaseViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CxtExpandBaseVew = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AccountGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.WhiteGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BlackGrid = new System.Windows.Forms.DataGridView();
            this.AlertGrid = new System.Windows.Forms.DataGridView();
            this.BanTab = new System.Windows.Forms.TabPage();
            this.BanContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ban_HideMessageWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Ban_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Ban_Set_ByIP = new System.Windows.Forms.ToolStripMenuItem();
            this.Ban_AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.Ban_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.BanView = new System.Windows.Forms.ListView();
            this.clnBanNik = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnBanEndData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnBanByIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnBanReson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.MessageText = new System.Windows.Forms.RichTextBox();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrayContext.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatUsrLstContainer)).BeginInit();
            this.ChatUsrLstContainer.Panel1.SuspendLayout();
            this.ChatUsrLstContainer.Panel2.SuspendLayout();
            this.ChatUsrLstContainer.SuspendLayout();
            this.ChatContext.SuspendLayout();
            this.UserListTab.SuspendLayout();
            this.MChatUserTab.SuspendLayout();
            this.MChatListContext.SuspendLayout();
            this.AttachedUsersTab.SuspendLayout();
            this.AttachedListContext.SuspendLayout();
            this.BaseVewTab.SuspendLayout();
            this.BaseViewContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertGrid)).BeginInit();
            this.BanTab.SuspendLayout();
            this.BanContext.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIco
            // 
            this.TrayIco.ContextMenuStrip = this.TrayContext;
            this.TrayIco.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIco.Icon")));
            this.TrayIco.Text = "Messenger Srv";
            this.TrayIco.Visible = true;
            this.TrayIco.Click += new System.EventHandler(this.TrayIco_Click);
            this.TrayIco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIco_MouseDoubleClick);
            // 
            // TrayContext
            // 
            this.TrayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayShowWindow,
            this.TrayExit});
            this.TrayContext.Name = "TrayContext";
            this.TrayContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrayContext.Size = new System.Drawing.Size(147, 48);
            // 
            // TrayShowWindow
            // 
            this.TrayShowWindow.Name = "TrayShowWindow";
            this.TrayShowWindow.Size = new System.Drawing.Size(146, 22);
            this.TrayShowWindow.Text = "Hide Window";
            this.TrayShowWindow.Click += new System.EventHandler(this.TrayShowWindow_Click);
            // 
            // TrayExit
            // 
            this.TrayExit.Name = "TrayExit";
            this.TrayExit.Size = new System.Drawing.Size(146, 22);
            this.TrayExit.Text = "Exit";
            this.TrayExit.Click += new System.EventHandler(this.TrayExit_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.MM_Options,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(974, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MainExit
            // 
            this.MainExit.Name = "MainExit";
            this.MainExit.Size = new System.Drawing.Size(93, 22);
            this.MainExit.Text = "Exit";
            this.MainExit.Click += new System.EventHandler(this.MainExit_Click);
            // 
            // MM_Options
            // 
            this.MM_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_SwitchDebug,
            this.MM_Params});
            this.MM_Options.Name = "MM_Options";
            this.MM_Options.Size = new System.Drawing.Size(61, 20);
            this.MM_Options.Text = "Options";
            this.MM_Options.DropDownOpening += new System.EventHandler(this.MM_Options_DropDownOpening);
            // 
            // MM_SwitchDebug
            // 
            this.MM_SwitchDebug.Checked = true;
            this.MM_SwitchDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MM_SwitchDebug.Name = "MM_SwitchDebug";
            this.MM_SwitchDebug.Size = new System.Drawing.Size(133, 22);
            this.MM_SwitchDebug.Text = "DEBUG";
            this.MM_SwitchDebug.Click += new System.EventHandler(this.MM_SwitchDebug_Click);
            // 
            // MM_Params
            // 
            this.MM_Params.Name = "MM_Params";
            this.MM_Params.Size = new System.Drawing.Size(133, 22);
            this.MM_Params.Text = "Parametres";
            this.MM_Params.Click += new System.EventHandler(this.MM_Params_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MChatUserView
            // 
            this.MChatUserView.BackColor = System.Drawing.Color.White;
            this.MChatUserView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MChatUserView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MChat_Nikname,
            this.MChat_userEMail,
            this.MChat_userIP,
            this.MChat_userDescription});
            this.MChatUserView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MChatUserView.ForeColor = System.Drawing.Color.White;
            this.MChatUserView.FullRowSelect = true;
            this.MChatUserView.HideSelection = false;
            this.MChatUserView.Location = new System.Drawing.Point(1, 1);
            this.MChatUserView.Margin = new System.Windows.Forms.Padding(1);
            this.MChatUserView.Name = "MChatUserView";
            this.MChatUserView.Size = new System.Drawing.Size(506, 505);
            this.MChatUserView.TabIndex = 4;
            this.MChatUserView.UseCompatibleStateImageBehavior = false;
            this.MChatUserView.View = System.Windows.Forms.View.Details;
            // 
            // MChat_Nikname
            // 
            this.MChat_Nikname.Text = "Nickname";
            this.MChat_Nikname.Width = 113;
            // 
            // MChat_userEMail
            // 
            this.MChat_userEMail.Text = "E Mail";
            this.MChat_userEMail.Width = 136;
            // 
            // MChat_userIP
            // 
            this.MChat_userIP.Text = "Ip";
            this.MChat_userIP.Width = 131;
            // 
            // MChat_userDescription
            // 
            this.MChat_userDescription.Text = "Description";
            this.MChat_userDescription.Width = 114;
            // 
            // ChatUsrLstContainer
            // 
            this.ChatUsrLstContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatUsrLstContainer.Location = new System.Drawing.Point(0, 0);
            this.ChatUsrLstContainer.Name = "ChatUsrLstContainer";
            // 
            // ChatUsrLstContainer.Panel1
            // 
            this.ChatUsrLstContainer.Panel1.Controls.Add(this.Chat);
            // 
            // ChatUsrLstContainer.Panel2
            // 
            this.ChatUsrLstContainer.Panel2.Controls.Add(this.UserListTab);
            this.ChatUsrLstContainer.Size = new System.Drawing.Size(974, 536);
            this.ChatUsrLstContainer.SplitterDistance = 457;
            this.ChatUsrLstContainer.SplitterWidth = 1;
            this.ChatUsrLstContainer.TabIndex = 5;
            // 
            // Chat
            // 
            this.Chat.AutoWordSelection = true;
            this.Chat.BackColor = System.Drawing.Color.White;
            this.Chat.ContextMenuStrip = this.ChatContext;
            this.Chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chat.ForeColor = System.Drawing.Color.White;
            this.Chat.Location = new System.Drawing.Point(0, 0);
            this.Chat.Name = "Chat";
            this.Chat.ReadOnly = true;
            this.Chat.Size = new System.Drawing.Size(457, 536);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "";
            // 
            // ChatContext
            // 
            this.ChatContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CC_NIK,
            this.CC_SEP,
            this.CC_NikToChat,
            this.CC_Clear,
            this.CC_Expand,
            this.CC_AutoScroll});
            this.ChatContext.Name = "ChatContext";
            this.ChatContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ChatContext.Size = new System.Drawing.Size(252, 120);
            this.ChatContext.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ChatContext_Closed);
            // 
            // CC_NIK
            // 
            this.CC_NIK.Enabled = false;
            this.CC_NIK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.CC_NIK.Name = "CC_NIK";
            this.CC_NIK.Size = new System.Drawing.Size(251, 22);
            this.CC_NIK.Text = "NIK";
            this.CC_NIK.Visible = false;
            // 
            // CC_SEP
            // 
            this.CC_SEP.Name = "CC_SEP";
            this.CC_SEP.Size = new System.Drawing.Size(248, 6);
            this.CC_SEP.Visible = false;
            // 
            // CC_NikToChat
            // 
            this.CC_NikToChat.Name = "CC_NikToChat";
            this.CC_NikToChat.Size = new System.Drawing.Size(251, 22);
            this.CC_NikToChat.Text = "Ник в чат";
            this.CC_NikToChat.Visible = false;
            this.CC_NikToChat.Click += new System.EventHandler(this.CC_NikToChat_Click);
            // 
            // CC_Clear
            // 
            this.CC_Clear.Name = "CC_Clear";
            this.CC_Clear.Size = new System.Drawing.Size(251, 22);
            this.CC_Clear.Text = "Очистить окно сообщений";
            this.CC_Clear.Click += new System.EventHandler(this.CC_Clear_Click);
            // 
            // CC_Expand
            // 
            this.CC_Expand.Name = "CC_Expand";
            this.CC_Expand.Size = new System.Drawing.Size(251, 22);
            this.CC_Expand.Text = "Спрятать список пользователей";
            this.CC_Expand.Click += new System.EventHandler(this.CC_Expand_Click);
            // 
            // CC_AutoScroll
            // 
            this.CC_AutoScroll.Checked = true;
            this.CC_AutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CC_AutoScroll.Name = "CC_AutoScroll";
            this.CC_AutoScroll.Size = new System.Drawing.Size(251, 22);
            this.CC_AutoScroll.Text = "Автопрокрутка чата";
            this.CC_AutoScroll.Click += new System.EventHandler(this.CC_AutoScroll_Click);
            // 
            // UserListTab
            // 
            this.UserListTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.UserListTab.Controls.Add(this.MChatUserTab);
            this.UserListTab.Controls.Add(this.AttachedUsersTab);
            this.UserListTab.Controls.Add(this.BaseVewTab);
            this.UserListTab.Controls.Add(this.BanTab);
            this.UserListTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserListTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserListTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserListTab.Location = new System.Drawing.Point(0, 0);
            this.UserListTab.Multiline = true;
            this.UserListTab.Name = "UserListTab";
            this.UserListTab.SelectedIndex = 0;
            this.UserListTab.Size = new System.Drawing.Size(516, 536);
            this.UserListTab.TabIndex = 5;
            this.UserListTab.SelectedIndexChanged += new System.EventHandler(this.UserListTab_SelectedIndexChanged);
            // 
            // MChatUserTab
            // 
            this.MChatUserTab.ContextMenuStrip = this.MChatListContext;
            this.MChatUserTab.Controls.Add(this.MChatUserView);
            this.MChatUserTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MChatUserTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MChatUserTab.Location = new System.Drawing.Point(4, 25);
            this.MChatUserTab.Margin = new System.Windows.Forms.Padding(1);
            this.MChatUserTab.Name = "MChatUserTab";
            this.MChatUserTab.Padding = new System.Windows.Forms.Padding(1);
            this.MChatUserTab.Size = new System.Drawing.Size(508, 507);
            this.MChatUserTab.TabIndex = 0;
            this.MChatUserTab.Text = "Main Chat Users";
            this.MChatUserTab.UseVisualStyleBackColor = true;
            // 
            // MChatListContext
            // 
            this.MChatListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MCLC_RightPanelExpand,
            this.MCLC_Ban});
            this.MChatListContext.Name = "MChatListContext";
            this.MChatListContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MChatListContext.Size = new System.Drawing.Size(196, 48);
            this.MChatListContext.Opening += new System.ComponentModel.CancelEventHandler(this.MChatListContext_Opening);
            // 
            // MCLC_RightPanelExpand
            // 
            this.MCLC_RightPanelExpand.Name = "MCLC_RightPanelExpand";
            this.MCLC_RightPanelExpand.Size = new System.Drawing.Size(195, 22);
            this.MCLC_RightPanelExpand.Text = "Hide Message Window";
            this.MCLC_RightPanelExpand.Click += new System.EventHandler(this.MCLC_RightPanelExpand_Click);
            // 
            // MCLC_Ban
            // 
            this.MCLC_Ban.Name = "MCLC_Ban";
            this.MCLC_Ban.Size = new System.Drawing.Size(195, 22);
            this.MCLC_Ban.Text = "Ban";
            this.MCLC_Ban.Click += new System.EventHandler(this.MCLC_Ban_Click);
            // 
            // AttachedUsersTab
            // 
            this.AttachedUsersTab.ContextMenuStrip = this.AttachedListContext;
            this.AttachedUsersTab.Controls.Add(this.AttachedUsersView);
            this.AttachedUsersTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachedUsersTab.Location = new System.Drawing.Point(4, 25);
            this.AttachedUsersTab.Margin = new System.Windows.Forms.Padding(1);
            this.AttachedUsersTab.Name = "AttachedUsersTab";
            this.AttachedUsersTab.Padding = new System.Windows.Forms.Padding(1);
            this.AttachedUsersTab.Size = new System.Drawing.Size(508, 507);
            this.AttachedUsersTab.TabIndex = 1;
            this.AttachedUsersTab.Text = "Attached Users";
            this.AttachedUsersTab.UseVisualStyleBackColor = true;
            // 
            // AttachedListContext
            // 
            this.AttachedListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ALC_RightPanelExpand,
            this.ALC_DetachUser});
            this.AttachedListContext.Name = "AttachedListContext";
            this.AttachedListContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.AttachedListContext.Size = new System.Drawing.Size(196, 48);
            this.AttachedListContext.Opening += new System.ComponentModel.CancelEventHandler(this.AttachedListContext_Opening);
            // 
            // ALC_RightPanelExpand
            // 
            this.ALC_RightPanelExpand.Name = "ALC_RightPanelExpand";
            this.ALC_RightPanelExpand.Size = new System.Drawing.Size(195, 22);
            this.ALC_RightPanelExpand.Text = "Hide Message Window";
            this.ALC_RightPanelExpand.Click += new System.EventHandler(this.ALC_RightPanelExpand_Click);
            // 
            // ALC_DetachUser
            // 
            this.ALC_DetachUser.Name = "ALC_DetachUser";
            this.ALC_DetachUser.Size = new System.Drawing.Size(195, 22);
            this.ALC_DetachUser.Text = "Detach user";
            this.ALC_DetachUser.Click += new System.EventHandler(this.ALC_DetachUser_Click);
            // 
            // AttachedUsersView
            // 
            this.AttachedUsersView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AttachedUsersView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AttachedUsersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttachedView_Login,
            this.AttachedView_EMail,
            this.AttachedView_IP,
            this.AttachedView_Desc});
            this.AttachedUsersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttachedUsersView.ForeColor = System.Drawing.Color.White;
            this.AttachedUsersView.FullRowSelect = true;
            this.AttachedUsersView.HideSelection = false;
            this.AttachedUsersView.Location = new System.Drawing.Point(1, 1);
            this.AttachedUsersView.Margin = new System.Windows.Forms.Padding(1);
            this.AttachedUsersView.Name = "AttachedUsersView";
            this.AttachedUsersView.Size = new System.Drawing.Size(506, 505);
            this.AttachedUsersView.TabIndex = 5;
            this.AttachedUsersView.UseCompatibleStateImageBehavior = false;
            this.AttachedUsersView.View = System.Windows.Forms.View.Details;
            // 
            // AttachedView_Login
            // 
            this.AttachedView_Login.Text = "Nickname";
            this.AttachedView_Login.Width = 113;
            // 
            // AttachedView_EMail
            // 
            this.AttachedView_EMail.Text = "E Mail";
            this.AttachedView_EMail.Width = 136;
            // 
            // AttachedView_IP
            // 
            this.AttachedView_IP.Text = "Ip";
            this.AttachedView_IP.Width = 131;
            // 
            // AttachedView_Desc
            // 
            this.AttachedView_Desc.Text = "Description";
            this.AttachedView_Desc.Width = 108;
            // 
            // BaseVewTab
            // 
            this.BaseVewTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BaseVewTab.ContextMenuStrip = this.BaseViewContext;
            this.BaseVewTab.Controls.Add(this.splitContainer1);
            this.BaseVewTab.Location = new System.Drawing.Point(4, 25);
            this.BaseVewTab.Name = "BaseVewTab";
            this.BaseVewTab.Size = new System.Drawing.Size(508, 507);
            this.BaseVewTab.TabIndex = 2;
            this.BaseVewTab.Text = "Base Vew";
            this.BaseVewTab.UseVisualStyleBackColor = true;
            // 
            // BaseViewContext
            // 
            this.BaseViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CxtExpandBaseVew});
            this.BaseViewContext.Name = "BaseViewContext";
            this.BaseViewContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BaseViewContext.Size = new System.Drawing.Size(196, 26);
            // 
            // CxtExpandBaseVew
            // 
            this.CxtExpandBaseVew.Name = "CxtExpandBaseVew";
            this.CxtExpandBaseVew.Size = new System.Drawing.Size(195, 22);
            this.CxtExpandBaseVew.Text = "Hide Message Window";
            this.CxtExpandBaseVew.Click += new System.EventHandler(this.CxtExpandBaseVew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AccountGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(508, 507);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // AccountGrid
            // 
            this.AccountGrid.AllowUserToAddRows = false;
            this.AccountGrid.AllowUserToDeleteRows = false;
            this.AccountGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AccountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountGrid.Location = new System.Drawing.Point(0, 0);
            this.AccountGrid.Name = "AccountGrid";
            this.AccountGrid.ReadOnly = true;
            this.AccountGrid.Size = new System.Drawing.Size(508, 253);
            this.AccountGrid.TabIndex = 0;
            this.AccountGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.AccountGrid_ColumnAdded);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.WhiteGrid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(508, 253);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // WhiteGrid
            // 
            this.WhiteGrid.AllowUserToAddRows = false;
            this.WhiteGrid.AllowUserToDeleteRows = false;
            this.WhiteGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.WhiteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WhiteGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhiteGrid.Location = new System.Drawing.Point(0, 0);
            this.WhiteGrid.Name = "WhiteGrid";
            this.WhiteGrid.ReadOnly = true;
            this.WhiteGrid.Size = new System.Drawing.Size(175, 253);
            this.WhiteGrid.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BlackGrid);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.AlertGrid);
            this.splitContainer3.Size = new System.Drawing.Size(332, 253);
            this.splitContainer3.SplitterDistance = 152;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // BlackGrid
            // 
            this.BlackGrid.AllowUserToAddRows = false;
            this.BlackGrid.AllowUserToDeleteRows = false;
            this.BlackGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BlackGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlackGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlackGrid.Location = new System.Drawing.Point(0, 0);
            this.BlackGrid.Name = "BlackGrid";
            this.BlackGrid.ReadOnly = true;
            this.BlackGrid.Size = new System.Drawing.Size(152, 253);
            this.BlackGrid.TabIndex = 2;
            // 
            // AlertGrid
            // 
            this.AlertGrid.AllowUserToAddRows = false;
            this.AlertGrid.AllowUserToDeleteRows = false;
            this.AlertGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AlertGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlertGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertGrid.Location = new System.Drawing.Point(0, 0);
            this.AlertGrid.Name = "AlertGrid";
            this.AlertGrid.ReadOnly = true;
            this.AlertGrid.Size = new System.Drawing.Size(179, 253);
            this.AlertGrid.TabIndex = 3;
            // 
            // BanTab
            // 
            this.BanTab.ContextMenuStrip = this.BanContext;
            this.BanTab.Controls.Add(this.BanView);
            this.BanTab.Location = new System.Drawing.Point(4, 25);
            this.BanTab.Name = "BanTab";
            this.BanTab.Size = new System.Drawing.Size(508, 507);
            this.BanTab.TabIndex = 3;
            this.BanTab.Text = "Banned users";
            this.BanTab.UseVisualStyleBackColor = true;
            // 
            // BanContext
            // 
            this.BanContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ban_HideMessageWindow,
            this.toolStripSeparator1,
            this.Ban_Delete,
            this.Ban_Set_ByIP,
            this.Ban_AddUser,
            this.Ban_Edit});
            this.BanContext.Name = "BanContext";
            this.BanContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BanContext.Size = new System.Drawing.Size(196, 120);
            this.BanContext.Opening += new System.ComponentModel.CancelEventHandler(this.BanContext_Opening);
            // 
            // Ban_HideMessageWindow
            // 
            this.Ban_HideMessageWindow.Name = "Ban_HideMessageWindow";
            this.Ban_HideMessageWindow.Size = new System.Drawing.Size(195, 22);
            this.Ban_HideMessageWindow.Text = "Hide Message Window";
            this.Ban_HideMessageWindow.Click += new System.EventHandler(this.Ban_HideMessageWindow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // Ban_Delete
            // 
            this.Ban_Delete.Name = "Ban_Delete";
            this.Ban_Delete.Size = new System.Drawing.Size(195, 22);
            this.Ban_Delete.Text = "Delete";
            this.Ban_Delete.Click += new System.EventHandler(this.Ban_Delete_Click);
            // 
            // Ban_Set_ByIP
            // 
            this.Ban_Set_ByIP.Name = "Ban_Set_ByIP";
            this.Ban_Set_ByIP.Size = new System.Drawing.Size(195, 22);
            this.Ban_Set_ByIP.Text = "By IP";
            this.Ban_Set_ByIP.Click += new System.EventHandler(this.Ban_Set_ByIP_Click);
            // 
            // Ban_AddUser
            // 
            this.Ban_AddUser.Name = "Ban_AddUser";
            this.Ban_AddUser.Size = new System.Drawing.Size(195, 22);
            this.Ban_AddUser.Text = "Add User";
            this.Ban_AddUser.Click += new System.EventHandler(this.Ban_AddUser_Click);
            // 
            // Ban_Edit
            // 
            this.Ban_Edit.Name = "Ban_Edit";
            this.Ban_Edit.Size = new System.Drawing.Size(195, 22);
            this.Ban_Edit.Text = "Edit";
            this.Ban_Edit.Click += new System.EventHandler(this.Ban_Edit_Click);
            // 
            // BanView
            // 
            this.BanView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BanView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnBanNik,
            this.clnBanEndData,
            this.clnBanByIP,
            this.clnBanReson});
            this.BanView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BanView.ForeColor = System.Drawing.Color.White;
            this.BanView.FullRowSelect = true;
            this.BanView.HideSelection = false;
            this.BanView.Location = new System.Drawing.Point(0, 0);
            this.BanView.Name = "BanView";
            this.BanView.Size = new System.Drawing.Size(508, 507);
            this.BanView.TabIndex = 0;
            this.BanView.UseCompatibleStateImageBehavior = false;
            this.BanView.View = System.Windows.Forms.View.Details;
            // 
            // clnBanNik
            // 
            this.clnBanNik.Text = "Nik name";
            this.clnBanNik.Width = 121;
            // 
            // clnBanEndData
            // 
            this.clnBanEndData.Text = "End date";
            this.clnBanEndData.Width = 125;
            // 
            // clnBanByIP
            // 
            this.clnBanByIP.Text = "Ban by IP";
            this.clnBanByIP.Width = 123;
            // 
            // clnBanReson
            // 
            this.clnBanReson.Text = "Reson";
            this.clnBanReson.Width = 297;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Info,
            this.Progress});
            this.StatusBar.Location = new System.Drawing.Point(0, 628);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(974, 22);
            this.StatusBar.TabIndex = 6;
            this.StatusBar.Text = "statusStrip1";
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(39, 17);
            this.Info.Text = "Ready";
            this.Info.DoubleClick += new System.EventHandler(this.Info_DoubleClick);
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            this.Progress.Visible = false;
            // 
            // MessageText
            // 
            this.MessageText.BackColor = System.Drawing.Color.White;
            this.MessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageText.EnableAutoDragDrop = true;
            this.MessageText.ForeColor = System.Drawing.Color.White;
            this.MessageText.Location = new System.Drawing.Point(0, 0);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(974, 65);
            this.MessageText.TabIndex = 7;
            this.MessageText.Text = "";
            this.MessageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageText_KeyDown);
            // 
            // MainSplit
            // 
            this.MainSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplit.Location = new System.Drawing.Point(0, 24);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.ChatUsrLstContainer);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.MessageText);
            this.MainSplit.Size = new System.Drawing.Size(974, 604);
            this.MainSplit.SplitterDistance = 536;
            this.MainSplit.SplitterWidth = 3;
            this.MainSplit.TabIndex = 8;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nickname";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "E Mail";
            this.columnHeader3.Width = 148;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 650);
            this.Controls.Add(this.MainSplit);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Messenger Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TrayContext.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ChatUsrLstContainer.Panel1.ResumeLayout(false);
            this.ChatUsrLstContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatUsrLstContainer)).EndInit();
            this.ChatUsrLstContainer.ResumeLayout(false);
            this.ChatContext.ResumeLayout(false);
            this.UserListTab.ResumeLayout(false);
            this.MChatUserTab.ResumeLayout(false);
            this.MChatListContext.ResumeLayout(false);
            this.AttachedUsersTab.ResumeLayout(false);
            this.AttachedListContext.ResumeLayout(false);
            this.BaseVewTab.ResumeLayout(false);
            this.BaseViewContext.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccountGrid)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WhiteGrid)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlackGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertGrid)).EndInit();
            this.BanTab.ResumeLayout(false);
            this.BanContext.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIco;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ListView MChatUserView;
        private System.Windows.Forms.SplitContainer ChatUsrLstContainer;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel Info;
        private System.Windows.Forms.RichTextBox MessageText;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripMenuItem MainExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TrayContext;
        private System.Windows.Forms.ToolStripMenuItem TrayExit;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.ColumnHeader MChat_Nikname;
        private System.Windows.Forms.RichTextBox Chat;
        private System.Windows.Forms.ToolStripMenuItem TrayShowWindow;
        private System.Windows.Forms.ColumnHeader MChat_userDescription;
        private System.Windows.Forms.ColumnHeader MChat_userEMail;
        private System.Windows.Forms.ToolStripMenuItem MM_Options;
        private System.Windows.Forms.ToolStripMenuItem MM_SwitchDebug;
        private System.Windows.Forms.TabControl UserListTab;
        private System.Windows.Forms.TabPage MChatUserTab;
        private System.Windows.Forms.TabPage AttachedUsersTab;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader MChat_userIP;
        private System.Windows.Forms.ListView AttachedUsersView;
        private System.Windows.Forms.ColumnHeader AttachedView_Login;
        private System.Windows.Forms.ColumnHeader AttachedView_Desc;
        private System.Windows.Forms.ColumnHeader AttachedView_EMail;
        private System.Windows.Forms.ColumnHeader AttachedView_IP;
        private System.Windows.Forms.ToolStripMenuItem MM_Params;
        private System.Windows.Forms.TabPage BaseVewTab;
        private System.Windows.Forms.DataGridView AlertGrid;
        private System.Windows.Forms.DataGridView BlackGrid;
        private System.Windows.Forms.DataGridView WhiteGrid;
        private System.Windows.Forms.DataGridView AccountGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ContextMenuStrip BaseViewContext;
        private System.Windows.Forms.ToolStripMenuItem CxtExpandBaseVew;
        private System.Windows.Forms.ContextMenuStrip ChatContext;
        private System.Windows.Forms.ToolStripMenuItem CC_NIK;
        private System.Windows.Forms.ToolStripSeparator CC_SEP;
        private System.Windows.Forms.ToolStripMenuItem CC_NikToChat;
        private System.Windows.Forms.ToolStripMenuItem CC_Clear;
        private System.Windows.Forms.ToolStripMenuItem CC_Expand;
        private System.Windows.Forms.ToolStripMenuItem CC_AutoScroll;
        private System.Windows.Forms.TabPage BanTab;
        private System.Windows.Forms.ListView BanView;
        private System.Windows.Forms.ColumnHeader clnBanNik;
        private System.Windows.Forms.ColumnHeader clnBanEndData;
        private System.Windows.Forms.ColumnHeader clnBanByIP;
        private System.Windows.Forms.ContextMenuStrip BanContext;
        private System.Windows.Forms.ToolStripMenuItem Ban_Delete;
        private System.Windows.Forms.ToolStripMenuItem Ban_Set_ByIP;
        private System.Windows.Forms.ToolStripMenuItem Ban_AddUser;
        private System.Windows.Forms.ColumnHeader clnBanReson;
        private System.Windows.Forms.ToolStripMenuItem Ban_Edit;
        private System.Windows.Forms.ContextMenuStrip MChatListContext;
        private System.Windows.Forms.ContextMenuStrip AttachedListContext;
        private System.Windows.Forms.ToolStripMenuItem MCLC_RightPanelExpand;
        private System.Windows.Forms.ToolStripMenuItem ALC_RightPanelExpand;
        private System.Windows.Forms.ToolStripMenuItem MCLC_Ban;
        private System.Windows.Forms.ToolStripMenuItem ALC_DetachUser;
        private System.Windows.Forms.ToolStripMenuItem Ban_HideMessageWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

