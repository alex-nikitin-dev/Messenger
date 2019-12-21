using SplashScreenLib;
namespace Messenger_Client
{
    partial class Alert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            this.MainContaiter = new System.Windows.Forms.SplitContainer();
            this.ListContainer = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lstGuests = new System.Windows.Forms.ListView();
            this.clnGuest = new System.Windows.Forms.ColumnHeader();
            this.clnState = new System.Windows.Forms.ColumnHeader();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.MainContaiter.Panel1.SuspendLayout();
            this.MainContaiter.Panel2.SuspendLayout();
            this.MainContaiter.SuspendLayout();
            this.ListContainer.Panel1.SuspendLayout();
            this.ListContainer.Panel2.SuspendLayout();
            this.ListContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContaiter
            // 
            this.MainContaiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContaiter.Location = new System.Drawing.Point(0, 0);
            this.MainContaiter.Name = "MainContaiter";
            this.MainContaiter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContaiter.Panel1
            // 
            this.MainContaiter.Panel1.Controls.Add(this.ListContainer);
            // 
            // MainContaiter.Panel2
            // 
            this.MainContaiter.Panel2.Controls.Add(this.Cancel);
            this.MainContaiter.Panel2.Controls.Add(this.OK);
            this.MainContaiter.Size = new System.Drawing.Size(344, 506);
            this.MainContaiter.SplitterDistance = 464;
            this.MainContaiter.TabIndex = 0;
            // 
            // ListContainer
            // 
            this.ListContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListContainer.IsSplitterFixed = true;
            this.ListContainer.Location = new System.Drawing.Point(0, 0);
            this.ListContainer.Name = "ListContainer";
            this.ListContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ListContainer.Panel1
            // 
            this.ListContainer.Panel1.Controls.Add(this.label1);
            // 
            // ListContainer.Panel2
            // 
            this.ListContainer.Panel2.Controls.Add(this.lstGuests);
            this.ListContainer.Size = new System.Drawing.Size(344, 464);
            this.ListContainer.SplitterDistance = 89;
            this.ListContainer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Следующие пользователи\r\nдобавили вас себе в список контактов\r\nвыберите тех, кому " +
                "вы разрешите видеть \r\nсвоё состояние и присылать вам личные сообщения";
            // 
            // lstGuests
            // 
            this.lstGuests.BackColor = System.Drawing.Color.Cornsilk;
            this.lstGuests.CheckBoxes = true;
            this.lstGuests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnGuest,
            this.clnState});
            this.lstGuests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGuests.FullRowSelect = true;
            this.lstGuests.Location = new System.Drawing.Point(0, 0);
            this.lstGuests.Name = "lstGuests";
            this.lstGuests.Size = new System.Drawing.Size(344, 371);
            this.lstGuests.TabIndex = 0;
            this.lstGuests.UseCompatibleStateImageBehavior = false;
            this.lstGuests.View = System.Windows.Forms.View.Details;
            this.lstGuests.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstGuests_ItemChecked);
            // 
            // clnGuest
            // 
            this.clnGuest.Text = "Пользователь";
            this.clnGuest.Width = 143;
            // 
            // clnState
            // 
            this.clnState.Text = "Состояние";
            this.clnState.Width = 194;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(221, 8);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(111, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(92, 8);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(110, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 506);
            this.Controls.Add(this.MainContaiter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alert";
            this.Text = "Уведомление";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Alert_Load);
            this.MainContaiter.Panel1.ResumeLayout(false);
            this.MainContaiter.Panel2.ResumeLayout(false);
            this.MainContaiter.ResumeLayout(false);
            this.ListContainer.Panel1.ResumeLayout(false);
            this.ListContainer.Panel1.PerformLayout();
            this.ListContainer.Panel2.ResumeLayout(false);
            this.ListContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainContaiter;
        private System.Windows.Forms.SplitContainer ListContainer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button OK;
        public System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListView lstGuests;
        private System.Windows.Forms.ColumnHeader clnGuest;
        private System.Windows.Forms.ColumnHeader clnState;
    }
}