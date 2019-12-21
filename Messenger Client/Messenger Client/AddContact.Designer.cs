namespace Messenger_Client
{
    partial class AddContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddContact));
            this.LoginToAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.GoToFind = new System.Windows.Forms.LinkLabel();
            this.ProtectPanel = new System.Windows.Forms.Panel();
            this.btnCloseForce = new System.Windows.Forms.Button();
            this.lblSubInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ProtectPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginToAdd
            // 
            this.LoginToAdd.Location = new System.Drawing.Point(40, 84);
            this.LoginToAdd.Name = "LoginToAdd";
            this.LoginToAdd.Size = new System.Drawing.Size(271, 20);
            this.LoginToAdd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Добавить пользователя в список контактов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "1. По известному вам логину";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "2. Воспользоваться";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(155, 153);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(236, 153);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // GoToFind
            // 
            this.GoToFind.AutoSize = true;
            this.GoToFind.Location = new System.Drawing.Point(179, 118);
            this.GoToFind.Name = "GoToFind";
            this.GoToFind.Size = new System.Drawing.Size(51, 13);
            this.GoToFind.TabIndex = 7;
            this.GoToFind.TabStop = true;
            this.GoToFind.Text = "поиском";
            // 
            // ProtectPanel
            // 
            this.ProtectPanel.BackColor = System.Drawing.Color.Black;
            this.ProtectPanel.Controls.Add(this.btnCloseForce);
            this.ProtectPanel.Controls.Add(this.lblSubInfo);
            this.ProtectPanel.Controls.Add(this.lblInfo);
            this.ProtectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtectPanel.ForeColor = System.Drawing.Color.Cornsilk;
            this.ProtectPanel.Location = new System.Drawing.Point(0, 0);
            this.ProtectPanel.Name = "ProtectPanel";
            this.ProtectPanel.Size = new System.Drawing.Size(349, 188);
            this.ProtectPanel.TabIndex = 8;
            this.ProtectPanel.Visible = false;
            // 
            // btnCloseForce
            // 
            this.btnCloseForce.BackColor = System.Drawing.Color.Black;
            this.btnCloseForce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForce.ForeColor = System.Drawing.Color.Beige;
            this.btnCloseForce.Location = new System.Drawing.Point(30, 153);
            this.btnCloseForce.Name = "btnCloseForce";
            this.btnCloseForce.Size = new System.Drawing.Size(291, 23);
            this.btnCloseForce.TabIndex = 2;
            this.btnCloseForce.Text = "Закрыть окно не дожидаясь ответа";
            this.btnCloseForce.UseVisualStyleBackColor = false;
            // 
            // lblSubInfo
            // 
            this.lblSubInfo.AutoSize = true;
            this.lblSubInfo.Location = new System.Drawing.Point(75, 91);
            this.lblSubInfo.Name = "lblSubInfo";
            this.lblSubInfo.Size = new System.Drawing.Size(199, 13);
            this.lblSubInfo.TabIndex = 1;
            this.lblSubInfo.Text = "Это не должно занять более 5 секунд";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(27, 54);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(294, 17);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Подождите, ожидается ответ сервера";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.GoToFind);
            this.MainPanel.Controls.Add(this.LoginToAdd);
            this.MainPanel.Controls.Add(this.Cancel);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.Add);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(349, 188);
            this.MainPanel.TabIndex = 9;
            // 
            // AddContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 188);
            this.ControlBox = false;
            this.Controls.Add(this.ProtectPanel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddContact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление контакта";
            this.ProtectPanel.ResumeLayout(false);
            this.ProtectPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.LinkLabel GoToFind;
        public System.Windows.Forms.Button Add;
        public System.Windows.Forms.TextBox LoginToAdd;
        private System.Windows.Forms.Panel MainPanel;
        public System.Windows.Forms.Panel ProtectPanel;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Label lblSubInfo;
        public System.Windows.Forms.Button btnCloseForce;
    }
}