namespace Messenger_Client
{
    partial class MainChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainChat));
            this.UserList = new System.Windows.Forms.ListView();
            this.Nikname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserEMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ULC_NIK = new System.Windows.Forms.ToolStripMenuItem();
            this.ULC_SEP = new System.Windows.Forms.ToolStripSeparator();
            this.ULC_NikToChat = new System.Windows.Forms.ToolStripMenuItem();
            this.ChatUsrLstContainer = new System.Windows.Forms.SplitContainer();
            this.Chat = new System.Windows.Forms.RichTextBox();
            this.ChatContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CC_NIK = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_SEP = new System.Windows.Forms.ToolStripSeparator();
            this.CC_NikToChat = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_Expand = new System.Windows.Forms.ToolStripMenuItem();
            this.CC_AutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageText = new System.Windows.Forms.RichTextBox();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.вижToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Topmost = new System.Windows.Forms.ToolStripMenuItem();
            this.MM_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.MChatTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TM_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.UserListContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatUsrLstContainer)).BeginInit();
            this.ChatUsrLstContainer.Panel1.SuspendLayout();
            this.ChatUsrLstContainer.Panel2.SuspendLayout();
            this.ChatUsrLstContainer.SuspendLayout();
            this.ChatContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nikname,
            this.UserDesc,
            this.UserEMail});
            this.UserList.ContextMenuStrip = this.UserListContext;
            this.UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserList.ForeColor = System.Drawing.Color.White;
            this.UserList.Location = new System.Drawing.Point(0, 0);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(441, 478);
            this.UserList.TabIndex = 4;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.Details;
            // 
            // Nikname
            // 
            this.Nikname.Text = "Nickname";
            this.Nikname.Width = 135;
            // 
            // UserDesc
            // 
            this.UserDesc.Text = "Description";
            this.UserDesc.Width = 168;
            // 
            // UserEMail
            // 
            this.UserEMail.Text = "E Mail";
            this.UserEMail.Width = 116;
            // 
            // UserListContext
            // 
            this.UserListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ULC_NIK,
            this.ULC_SEP,
            this.ULC_NikToChat});
            this.UserListContext.Name = "UserListContext";
            this.UserListContext.Size = new System.Drawing.Size(127, 54);
            this.UserListContext.Opening += new System.ComponentModel.CancelEventHandler(this.UserListContext_Opening);
            // 
            // ULC_NIK
            // 
            this.ULC_NIK.Enabled = false;
            this.ULC_NIK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ULC_NIK.Name = "ULC_NIK";
            this.ULC_NIK.Size = new System.Drawing.Size(126, 22);
            this.ULC_NIK.Text = "NIK";
            // 
            // ULC_SEP
            // 
            this.ULC_SEP.Name = "ULC_SEP";
            this.ULC_SEP.Size = new System.Drawing.Size(123, 6);
            // 
            // ULC_NikToChat
            // 
            this.ULC_NikToChat.Name = "ULC_NikToChat";
            this.ULC_NikToChat.Size = new System.Drawing.Size(126, 22);
            this.ULC_NikToChat.Text = "Ник в чат";
            this.ULC_NikToChat.Click += new System.EventHandler(this.ULC_NikToChat_Click);
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
            this.ChatUsrLstContainer.Panel2.Controls.Add(this.UserList);
            this.ChatUsrLstContainer.Size = new System.Drawing.Size(892, 478);
            this.ChatUsrLstContainer.SplitterDistance = 447;
            this.ChatUsrLstContainer.TabIndex = 5;
            // 
            // Chat
            // 
            this.Chat.AutoWordSelection = true;
            this.Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Chat.ContextMenuStrip = this.ChatContext;
            this.Chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chat.ForeColor = System.Drawing.Color.White;
            this.Chat.Location = new System.Drawing.Point(0, 0);
            this.Chat.Name = "Chat";
            this.Chat.ReadOnly = true;
            this.Chat.Size = new System.Drawing.Size(447, 478);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "";
            this.Chat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chat_MouseDown);
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
            this.CC_Clear.Text = "Очистить чат";
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
            // MessageText
            // 
            this.MessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.MessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageText.EnableAutoDragDrop = true;
            this.MessageText.ForeColor = System.Drawing.Color.White;
            this.MessageText.Location = new System.Drawing.Point(0, 0);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(892, 90);
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
            this.MainSplit.Size = new System.Drawing.Size(892, 572);
            this.MainSplit.SplitterDistance = 478;
            this.MainSplit.TabIndex = 8;
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(39, 17);
            this.Info.Text = "Ready";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            this.Progress.Visible = false;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Info,
            this.Progress});
            this.StatusBar.Location = new System.Drawing.Point(0, 596);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(892, 22);
            this.StatusBar.TabIndex = 6;
            this.StatusBar.Text = "statusStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // MainExit
            // 
            this.MainExit.Name = "MainExit";
            this.MainExit.Size = new System.Drawing.Size(108, 22);
            this.MainExit.Text = "Выход";
            this.MainExit.Click += new System.EventHandler(this.MainExit_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.вижToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(892, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "MainMenu";
            // 
            // вижToolStripMenuItem
            // 
            this.вижToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_Topmost,
            this.MM_Hide});
            this.вижToolStripMenuItem.Name = "вижToolStripMenuItem";
            this.вижToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.вижToolStripMenuItem.Text = "Вид";
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
            // MChatTray
            // 
            this.MChatTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MChatTray.BalloonTipText = "Окно главного чата";
            this.MChatTray.ContextMenuStrip = this.TrayMenu;
            this.MChatTray.Icon = ((System.Drawing.Icon)(resources.GetObject("MChatTray.Icon")));
            this.MChatTray.Text = "Главный чат";
            this.MChatTray.Visible = true;
            this.MChatTray.DoubleClick += new System.EventHandler(this.MChatTray_DoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TM_Show,
            this.TM_Exit});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(188, 48);
            // 
            // TM_Show
            // 
            this.TM_Show.Name = "TM_Show";
            this.TM_Show.Size = new System.Drawing.Size(187, 22);
            this.TM_Show.Text = "Скрыть Главный чат";
            this.TM_Show.Click += new System.EventHandler(this.TM_Show_Click);
            // 
            // TM_Exit
            // 
            this.TM_Exit.Name = "TM_Exit";
            this.TM_Exit.Size = new System.Drawing.Size(187, 22);
            this.TM_Exit.Text = "Выход";
            this.TM_Exit.Click += new System.EventHandler(this.TM_Exit_Click);
            // 
            // MainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 618);
            this.Controls.Add(this.MainSplit);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainChat_FormClosing);
            this.Load += new System.EventHandler(this.MainChat_Load);
            this.UserListContext.ResumeLayout(false);
            this.ChatUsrLstContainer.Panel1.ResumeLayout(false);
            this.ChatUsrLstContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatUsrLstContainer)).EndInit();
            this.ChatUsrLstContainer.ResumeLayout(false);
            this.ChatContext.ResumeLayout(false);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ChatUsrLstContainer;
        private System.Windows.Forms.RichTextBox MessageText;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.RichTextBox Chat;
        private System.Windows.Forms.ToolStripStatusLabel Info;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainExit;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem вижToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MM_Topmost;
        private System.Windows.Forms.ToolStripMenuItem MM_Hide;
        private System.Windows.Forms.NotifyIcon MChatTray;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem TM_Show;
        private System.Windows.Forms.ToolStripMenuItem TM_Exit;
        public System.Windows.Forms.ListView UserList;
        public System.Windows.Forms.ColumnHeader Nikname;
        private System.Windows.Forms.ColumnHeader UserDesc;
        private System.Windows.Forms.ColumnHeader UserEMail;
        private System.Windows.Forms.ContextMenuStrip ChatContext;
        private System.Windows.Forms.ToolStripMenuItem CC_NikToChat;
        private System.Windows.Forms.ToolStripMenuItem CC_Clear;
        private System.Windows.Forms.ToolStripMenuItem CC_Expand;
        private System.Windows.Forms.ToolStripMenuItem CC_AutoScroll;
        private System.Windows.Forms.ToolStripMenuItem CC_NIK;
        private System.Windows.Forms.ToolStripSeparator CC_SEP;
        private System.Windows.Forms.ContextMenuStrip UserListContext;
        private System.Windows.Forms.ToolStripMenuItem ULC_NikToChat;
        private System.Windows.Forms.ToolStripMenuItem ULC_NIK;
        private System.Windows.Forms.ToolStripSeparator ULC_SEP;
    }
}

