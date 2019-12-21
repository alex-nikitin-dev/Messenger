namespace MessengerServer
{
    partial class BanRuleForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.banReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userDataSet = new MessengerServer.UserDataSet();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BanRulesGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banRulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banRulesTableAdapter = new MessengerServer.UserDataSetTableAdapters.BanRulesTableAdapter();
            this.banRulesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.banReasonsTableAdapter = new MessengerServer.UserDataSetTableAdapters.BanReasonsTableAdapter();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BanRulesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "sec.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Reson";
            // 
            // txtSeconds
            // 
            this.txtSeconds.Location = new System.Drawing.Point(396, 127);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(86, 20);
            this.txtSeconds.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(567, 178);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add new rule";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(396, 91);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(86, 20);
            this.txtMinutes.TabIndex = 15;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(195, 127);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(86, 20);
            this.txtHours.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "hours";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "days";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(196, 93);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(86, 20);
            this.txtDays.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSeconds);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtDays);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMinutes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHours);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 216);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Rule";
            // 
            // banReasonsBindingSource
            // 
            this.banReasonsBindingSource.DataMember = "BanReasons";
            this.banReasonsBindingSource.DataSource = this.userDataSet;
            // 
            // userDataSet
            // 
            this.userDataSet.DataSetName = "UserDataSet";
            this.userDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(567, 149);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(138, 23);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Time";
            // 
            // BanRulesGrid
            // 
            this.BanRulesGrid.AllowUserToAddRows = false;
            this.BanRulesGrid.AllowUserToOrderColumns = true;
            this.BanRulesGrid.AutoGenerateColumns = false;
            this.BanRulesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BanRulesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Reason,
            this.ReasonName,
            this.generalTimeDataGridViewTextBoxColumn,
            this.timeViewDataGridViewTextBoxColumn});
            this.BanRulesGrid.DataSource = this.banRulesBindingSource;
            this.BanRulesGrid.Location = new System.Drawing.Point(12, 12);
            this.BanRulesGrid.MultiSelect = false;
            this.BanRulesGrid.Name = "BanRulesGrid";
            this.BanRulesGrid.ReadOnly = true;
            this.BanRulesGrid.Size = new System.Drawing.Size(721, 171);
            this.BanRulesGrid.TabIndex = 22;
            this.BanRulesGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.BanRulesGrid_DataBindingComplete);
            this.BanRulesGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BanRulesGrid_RowsRemoved);
            this.BanRulesGrid.SelectionChanged += new System.EventHandler(this.BanRulesGrid_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.HeaderText = "Reason Id";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            this.Reason.Visible = false;
            // 
            // ReasonName
            // 
            this.ReasonName.HeaderText = "Reason Name";
            this.ReasonName.Name = "ReasonName";
            this.ReasonName.ReadOnly = true;
            this.ReasonName.Width = 400;
            // 
            // generalTimeDataGridViewTextBoxColumn
            // 
            this.generalTimeDataGridViewTextBoxColumn.DataPropertyName = "GeneralTime";
            this.generalTimeDataGridViewTextBoxColumn.HeaderText = "GeneralTime";
            this.generalTimeDataGridViewTextBoxColumn.Name = "generalTimeDataGridViewTextBoxColumn";
            this.generalTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.generalTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // timeViewDataGridViewTextBoxColumn
            // 
            this.timeViewDataGridViewTextBoxColumn.DataPropertyName = "TimeView";
            this.timeViewDataGridViewTextBoxColumn.HeaderText = "TimeView";
            this.timeViewDataGridViewTextBoxColumn.Name = "timeViewDataGridViewTextBoxColumn";
            this.timeViewDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeViewDataGridViewTextBoxColumn.Width = 270;
            // 
            // banRulesBindingSource
            // 
            this.banRulesBindingSource.DataMember = "BanRules";
            this.banRulesBindingSource.DataSource = this.userDataSet;
            // 
            // banRulesTableAdapter
            // 
            this.banRulesTableAdapter.ClearBeforeFill = true;
            // 
            // banRulesBindingSource1
            // 
            this.banRulesBindingSource1.DataMember = "BanRules";
            this.banRulesBindingSource1.DataSource = this.userDataSet;
            // 
            // banReasonsTableAdapter
            // 
            this.banReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(172, 38);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(349, 20);
            this.txtReason.TabIndex = 23;
            // 
            // BanRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BanRulesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BanRuleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ban Rules";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BanRuleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BanRulesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banRulesBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView BanRulesGrid;
        private UserDataSet userDataSet;
        private System.Windows.Forms.BindingSource banRulesBindingSource;
        private MessengerServer.UserDataSetTableAdapters.BanRulesTableAdapter banRulesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn resonDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource banRulesBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn generalTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource banReasonsBindingSource;
        private MessengerServer.UserDataSetTableAdapters.BanReasonsTableAdapter banReasonsTableAdapter;
        private System.Windows.Forms.TextBox txtReason;
    }
}