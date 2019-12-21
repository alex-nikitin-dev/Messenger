namespace Messenger_Client
{
    partial class FindUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindUserForm));
            this.Login = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.EMail = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FindHelpShow = new System.Windows.Forms.LinkLabel();
            this.EnableEMail = new System.Windows.Forms.CheckBox();
            this.EnableLastName = new System.Windows.Forms.CheckBox();
            this.EnableFirstName = new System.Windows.Forms.CheckBox();
            this.EnableLogin = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.Results = new System.Windows.Forms.ListView();
            this.clnLogin = new System.Windows.Forms.ColumnHeader();
            this.clnFN = new System.Windows.Forms.ColumnHeader();
            this.clnLN = new System.Windows.Forms.ColumnHeader();
            this.clnEMial = new System.Windows.Forms.ColumnHeader();
            this.ResultContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToContacts = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.FindTab = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ResultsTab = new System.Windows.Forms.TabPage();
            this.ResultContainer = new System.Windows.Forms.SplitContainer();
            this.pnlResultsProtect = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultsBackView = new System.Windows.Forms.ListView();
            this.clnLoginBack = new System.Windows.Forms.ColumnHeader();
            this.clnResultBack = new System.Windows.Forms.ColumnHeader();
            this.EnableWatch = new System.Windows.Forms.Timer(this.components);
            this.FindHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ViewTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.ResultContext.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.FindTab.SuspendLayout();
            this.ResultsTab.SuspendLayout();
            this.ResultContainer.Panel1.SuspendLayout();
            this.ResultContainer.Panel2.SuspendLayout();
            this.ResultContainer.SuspendLayout();
            this.pnlResultsProtect.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Enabled = false;
            this.Login.Location = new System.Drawing.Point(105, 41);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(201, 20);
            this.Login.TabIndex = 0;
            // 
            // FirstName
            // 
            this.FirstName.Enabled = false;
            this.FirstName.Location = new System.Drawing.Point(105, 94);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(201, 20);
            this.FirstName.TabIndex = 1;
            // 
            // LastName
            // 
            this.LastName.Enabled = false;
            this.LastName.Location = new System.Drawing.Point(105, 153);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(201, 20);
            this.LastName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Фамилия";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(29, 218);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "E - Mail";
            // 
            // EMail
            // 
            this.EMail.Enabled = false;
            this.EMail.Location = new System.Drawing.Point(105, 211);
            this.EMail.Name = "EMail";
            this.EMail.Size = new System.Drawing.Size(201, 20);
            this.EMail.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FindHelpShow);
            this.groupBox1.Controls.Add(this.EnableEMail);
            this.groupBox1.Controls.Add(this.EnableLastName);
            this.groupBox1.Controls.Add(this.EnableFirstName);
            this.groupBox1.Controls.Add(this.EnableLogin);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.FirstName);
            this.groupBox1.Controls.Add(this.EMail);
            this.groupBox1.Controls.Add(this.LastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 341);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задайте критерии поиска";
            // 
            // FindHelpShow
            // 
            this.FindHelpShow.AutoSize = true;
            this.FindHelpShow.Location = new System.Drawing.Point(15, 318);
            this.FindHelpShow.Name = "FindHelpShow";
            this.FindHelpShow.Size = new System.Drawing.Size(103, 13);
            this.FindHelpShow.TabIndex = 13;
            this.FindHelpShow.TabStop = true;
            this.FindHelpShow.Text = "Помощь по поиску";
            this.FindHelpShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FindHelpShow_LinkClicked);
            // 
            // EnableEMail
            // 
            this.EnableEMail.AutoSize = true;
            this.EnableEMail.Location = new System.Drawing.Point(323, 217);
            this.EnableEMail.Name = "EnableEMail";
            this.EnableEMail.Size = new System.Drawing.Size(15, 14);
            this.EnableEMail.TabIndex = 11;
            this.EnableEMail.UseVisualStyleBackColor = true;
            this.EnableEMail.CheckedChanged += new System.EventHandler(this.EnableEMail_CheckedChanged);
            // 
            // EnableLastName
            // 
            this.EnableLastName.AutoSize = true;
            this.EnableLastName.Location = new System.Drawing.Point(323, 160);
            this.EnableLastName.Name = "EnableLastName";
            this.EnableLastName.Size = new System.Drawing.Size(15, 14);
            this.EnableLastName.TabIndex = 10;
            this.EnableLastName.UseVisualStyleBackColor = true;
            this.EnableLastName.CheckedChanged += new System.EventHandler(this.EnableLastName_CheckedChanged);
            // 
            // EnableFirstName
            // 
            this.EnableFirstName.AutoSize = true;
            this.EnableFirstName.Location = new System.Drawing.Point(323, 100);
            this.EnableFirstName.Name = "EnableFirstName";
            this.EnableFirstName.Size = new System.Drawing.Size(15, 14);
            this.EnableFirstName.TabIndex = 9;
            this.EnableFirstName.UseVisualStyleBackColor = true;
            this.EnableFirstName.CheckedChanged += new System.EventHandler(this.EnableFirstName_CheckedChanged);
            // 
            // EnableLogin
            // 
            this.EnableLogin.AutoSize = true;
            this.EnableLogin.Location = new System.Drawing.Point(323, 44);
            this.EnableLogin.Name = "EnableLogin";
            this.EnableLogin.Size = new System.Drawing.Size(15, 14);
            this.EnableLogin.TabIndex = 8;
            this.EnableLogin.UseVisualStyleBackColor = true;
            this.EnableLogin.CheckedChanged += new System.EventHandler(this.EnableLogin_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(438, 324);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(95, 23);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(438, 288);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(95, 23);
            this.btnGetAll.TabIndex = 10;
            this.btnGetAll.Text = "Весь список";
            this.btnGetAll.UseVisualStyleBackColor = true;
            // 
            // Results
            // 
            this.Results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnLogin,
            this.clnFN,
            this.clnLN,
            this.clnEMial});
            this.Results.ContextMenuStrip = this.ResultContext;
            this.Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results.FullRowSelect = true;
            this.Results.Location = new System.Drawing.Point(0, 0);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(537, 353);
            this.Results.TabIndex = 11;
            this.Results.UseCompatibleStateImageBehavior = false;
            this.Results.View = System.Windows.Forms.View.Details;
            // 
            // clnLogin
            // 
            this.clnLogin.Text = "Логин";
            this.clnLogin.Width = 124;
            // 
            // clnFN
            // 
            this.clnFN.Text = "Имя";
            this.clnFN.Width = 127;
            // 
            // clnLN
            // 
            this.clnLN.Text = "Фамилия";
            this.clnLN.Width = 141;
            // 
            // clnEMial
            // 
            this.clnEMial.Text = "E Mail";
            this.clnEMial.Width = 138;
            // 
            // ResultContext
            // 
            this.ResultContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToContacts});
            this.ResultContext.Name = "ResultContext";
            this.ResultContext.Size = new System.Drawing.Size(237, 26);
            this.ResultContext.Opening += new System.ComponentModel.CancelEventHandler(this.ResultContext_Opening);
            // 
            // AddToContacts
            // 
            this.AddToContacts.Name = "AddToContacts";
            this.AddToContacts.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.AddToContacts.Size = new System.Drawing.Size(236, 22);
            this.AddToContacts.Text = "Добавить в контакты";
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.FindTab);
            this.Tabs.Controls.Add(this.ResultsTab);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(551, 385);
            this.Tabs.TabIndex = 12;
            // 
            // FindTab
            // 
            this.FindTab.Controls.Add(this.btnCancel);
            this.FindTab.Controls.Add(this.groupBox1);
            this.FindTab.Controls.Add(this.btnFind);
            this.FindTab.Controls.Add(this.btnGetAll);
            this.FindTab.Location = new System.Drawing.Point(4, 22);
            this.FindTab.Name = "FindTab";
            this.FindTab.Padding = new System.Windows.Forms.Padding(3);
            this.FindTab.Size = new System.Drawing.Size(543, 359);
            this.FindTab.TabIndex = 0;
            this.FindTab.Text = "Поиск";
            this.FindTab.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(438, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResultsTab
            // 
            this.ResultsTab.Controls.Add(this.ResultContainer);
            this.ResultsTab.Location = new System.Drawing.Point(4, 22);
            this.ResultsTab.Name = "ResultsTab";
            this.ResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResultsTab.Size = new System.Drawing.Size(543, 359);
            this.ResultsTab.TabIndex = 1;
            this.ResultsTab.Text = "Результаты";
            this.ResultsTab.UseVisualStyleBackColor = true;
            // 
            // ResultContainer
            // 
            this.ResultContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultContainer.Location = new System.Drawing.Point(3, 3);
            this.ResultContainer.Name = "ResultContainer";
            this.ResultContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ResultContainer.Panel1
            // 
            this.ResultContainer.Panel1.Controls.Add(this.Results);
            // 
            // ResultContainer.Panel2
            // 
            this.ResultContainer.Panel2.Controls.Add(this.pnlResultsProtect);
            this.ResultContainer.Panel2.Controls.Add(this.ResultsBackView);
            this.ResultContainer.Panel2Collapsed = true;
            this.ResultContainer.Size = new System.Drawing.Size(537, 353);
            this.ResultContainer.SplitterDistance = 250;
            this.ResultContainer.TabIndex = 12;
            // 
            // pnlResultsProtect
            // 
            this.pnlResultsProtect.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnlResultsProtect.Controls.Add(this.label5);
            this.pnlResultsProtect.Controls.Add(this.label4);
            this.pnlResultsProtect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultsProtect.ForeColor = System.Drawing.Color.Cornsilk;
            this.pnlResultsProtect.Location = new System.Drawing.Point(0, 0);
            this.pnlResultsProtect.Name = "pnlResultsProtect";
            this.pnlResultsProtect.Size = new System.Drawing.Size(150, 46);
            this.pnlResultsProtect.TabIndex = 1;
            this.pnlResultsProtect.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Это не должно занять более 5 секунд";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Cornsilk;
            this.label4.Location = new System.Drawing.Point(119, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Подождите... идет обработка запроса";
            // 
            // ResultsBackView
            // 
            this.ResultsBackView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnLoginBack,
            this.clnResultBack});
            this.ResultsBackView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsBackView.FullRowSelect = true;
            this.ResultsBackView.Location = new System.Drawing.Point(0, 0);
            this.ResultsBackView.MultiSelect = false;
            this.ResultsBackView.Name = "ResultsBackView";
            this.ResultsBackView.Size = new System.Drawing.Size(150, 46);
            this.ResultsBackView.TabIndex = 0;
            this.ResultsBackView.UseCompatibleStateImageBehavior = false;
            this.ResultsBackView.View = System.Windows.Forms.View.Details;
            // 
            // clnLoginBack
            // 
            this.clnLoginBack.Text = "Логин";
            this.clnLoginBack.Width = 126;
            // 
            // clnResultBack
            // 
            this.clnResultBack.Text = "Результат запроса на добавление контакта";
            this.clnResultBack.Width = 401;
            // 
            // EnableWatch
            // 
            this.EnableWatch.Enabled = true;
            this.EnableWatch.Tick += new System.EventHandler(this.OnEnableWatch);
            // 
            // FindHelp
            // 
            this.FindHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.FindHelp.ToolTipTitle = "Помощь по поиску";
            // 
            // ViewTimer
            // 
            this.ViewTimer.Interval = 10;
            this.ViewTimer.Tick += new System.EventHandler(this.OnViewTimer);
            // 
            // FindUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 385);
            this.Controls.Add(this.Tabs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск пользователя";
            this.Load += new System.EventHandler(this.FindUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResultContext.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.FindTab.ResumeLayout(false);
            this.ResultsTab.ResumeLayout(false);
            this.ResultContainer.Panel1.ResumeLayout(false);
            this.ResultContainer.Panel2.ResumeLayout(false);
            this.ResultContainer.ResumeLayout(false);
            this.pnlResultsProtect.ResumeLayout(false);
            this.pnlResultsProtect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox EnableEMail;
        private System.Windows.Forms.CheckBox EnableLastName;
        private System.Windows.Forms.CheckBox EnableFirstName;
        private System.Windows.Forms.CheckBox EnableLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer EnableWatch;
        private System.Windows.Forms.ColumnHeader clnLogin;
        private System.Windows.Forms.ColumnHeader clnFN;
        private System.Windows.Forms.ColumnHeader clnLN;
        private System.Windows.Forms.ColumnHeader clnEMial;
        public System.Windows.Forms.Button btnGetAll;
        public System.Windows.Forms.ListView Results;
        public System.Windows.Forms.ContextMenuStrip ResultContext;
        public System.Windows.Forms.ToolStripMenuItem AddToContacts;
        public System.Windows.Forms.TextBox Login;
        public System.Windows.Forms.TextBox FirstName;
        public System.Windows.Forms.TextBox LastName;
        public System.Windows.Forms.TextBox EMail;
        private System.Windows.Forms.LinkLabel FindHelpShow;
        private System.Windows.Forms.ToolTip FindHelp;
        public System.Windows.Forms.TabPage FindTab;
        public System.Windows.Forms.TabPage ResultsTab;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Timer ViewTimer;
        private System.Windows.Forms.ColumnHeader clnLoginBack;
        private System.Windows.Forms.ColumnHeader clnResultBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.SplitContainer ResultContainer;
        public System.Windows.Forms.Panel pnlResultsProtect;
        public System.Windows.Forms.ListView ResultsBackView;
        public System.Windows.Forms.TabControl Tabs;
    }
}