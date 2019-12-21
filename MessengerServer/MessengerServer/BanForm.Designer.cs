namespace MessengerServer
{
    partial class BanForm
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
            this.cbxLogin = new System.Windows.Forms.ComboBox();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userDataSet = new MessengerServer.UserDataSet();
            this.accountTableAdapter = new MessengerServer.UserDataSetTableAdapters.AccountTableAdapter();
            this.cbxEndData = new System.Windows.Forms.DateTimePicker();
            this.chkByIP = new System.Windows.Forms.CheckBox();
            this.cbxReson = new System.Windows.Forms.ComboBox();
            this.banReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banRulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddBanRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.banRulesTableAdapter = new MessengerServer.UserDataSetTableAdapters.BanRulesTableAdapter();
            this.banReasonsTableAdapter = new MessengerServer.UserDataSetTableAdapters.BanReasonsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxLogin
            // 
            this.cbxLogin.DataSource = this.accountBindingSource;
            this.cbxLogin.DisplayMember = "Login";
            this.cbxLogin.FormattingEnabled = true;
            this.cbxLogin.Location = new System.Drawing.Point(109, 30);
            this.cbxLogin.Name = "cbxLogin";
            this.cbxLogin.Size = new System.Drawing.Size(198, 21);
            this.cbxLogin.TabIndex = 0;
            this.cbxLogin.ValueMember = "Id";
            this.cbxLogin.DropDown += new System.EventHandler(this.cbxLogin_DropDown);
            // 
            // accountBindingSource
            // 
            this.accountBindingSource.DataMember = "Account";
            this.accountBindingSource.DataSource = this.userDataSet;
            // 
            // userDataSet
            // 
            this.userDataSet.DataSetName = "UserDataSet";
            this.userDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountTableAdapter
            // 
            this.accountTableAdapter.ClearBeforeFill = true;
            // 
            // cbxEndData
            // 
            this.cbxEndData.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.cbxEndData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbxEndData.Location = new System.Drawing.Point(109, 67);
            this.cbxEndData.Name = "cbxEndData";
            this.cbxEndData.Size = new System.Drawing.Size(198, 20);
            this.cbxEndData.TabIndex = 1;
            // 
            // chkByIP
            // 
            this.chkByIP.AutoSize = true;
            this.chkByIP.Location = new System.Drawing.Point(408, 46);
            this.chkByIP.Name = "chkByIP";
            this.chkByIP.Size = new System.Drawing.Size(73, 17);
            this.chkByIP.TabIndex = 2;
            this.chkByIP.Text = "Ban By IP";
            this.chkByIP.UseVisualStyleBackColor = true;
            // 
            // cbxReson
            // 
            this.cbxReson.DataSource = this.banReasonsBindingSource;
            this.cbxReson.DisplayMember = "Reason";
            this.cbxReson.FormattingEnabled = true;
            this.cbxReson.Location = new System.Drawing.Point(19, 152);
            this.cbxReson.Name = "cbxReson";
            this.cbxReson.Size = new System.Drawing.Size(411, 21);
            this.cbxReson.TabIndex = 3;
            this.cbxReson.ValueMember = "id";
            this.cbxReson.SelectedIndexChanged += new System.EventHandler(this.cbxReson_SelectedIndexChanged);
            // 
            // banReasonsBindingSource
            // 
            this.banReasonsBindingSource.DataMember = "BanReasons";
            this.banReasonsBindingSource.DataSource = this.userDataSet;
            // 
            // banRulesBindingSource
            // 
            this.banRulesBindingSource.DataMember = "BanRules";
            this.banRulesBindingSource.DataSource = this.userDataSet;
            // 
            // btnAddBanRule
            // 
            this.btnAddBanRule.Location = new System.Drawing.Point(447, 150);
            this.btnAddBanRule.Name = "btnAddBanRule";
            this.btnAddBanRule.Size = new System.Drawing.Size(75, 23);
            this.btnAddBanRule.TabIndex = 4;
            this.btnAddBanRule.Text = "New Rule";
            this.btnAddBanRule.UseVisualStyleBackColor = true;
            this.btnAddBanRule.Click += new System.EventHandler(this.btnAddBanRule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nik name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "End date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Reson";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddBanRule);
            this.groupBox1.Controls.Add(this.cbxLogin);
            this.groupBox1.Controls.Add(this.cbxReson);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxEndData);
            this.groupBox1.Controls.Add(this.chkByIP);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 199);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ban options";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(381, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(462, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // banRulesTableAdapter
            // 
            this.banRulesTableAdapter.ClearBeforeFill = true;
            // 
            // banReasonsTableAdapter
            // 
            this.banReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // BanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 247);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BanForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ban";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BanForm_FormClosing);
            this.Load += new System.EventHandler(this.BanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxLogin;
        private UserDataSet userDataSet;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private MessengerServer.UserDataSetTableAdapters.AccountTableAdapter accountTableAdapter;
        private System.Windows.Forms.DateTimePicker cbxEndData;
        private System.Windows.Forms.CheckBox chkByIP;
        private System.Windows.Forms.ComboBox cbxReson;
        private System.Windows.Forms.Button btnAddBanRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource banRulesBindingSource;
        private MessengerServer.UserDataSetTableAdapters.BanRulesTableAdapter banRulesTableAdapter;
        private System.Windows.Forms.BindingSource banReasonsBindingSource;
        private MessengerServer.UserDataSetTableAdapters.BanReasonsTableAdapter banReasonsTableAdapter;
    }
}