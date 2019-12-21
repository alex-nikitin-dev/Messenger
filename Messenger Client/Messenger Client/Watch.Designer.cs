using SplashScreenLib;
namespace Messenger_Client
{
    partial class Watch
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Принято"}, -1, System.Drawing.Color.Lime, System.Drawing.Color.Empty, new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Отправлено"}, -1, System.Drawing.Color.Red, System.Drawing.Color.Empty, new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))));
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.Receive = new System.Windows.Forms.ListView();
            this.Send = new System.Windows.Forms.ListView();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            SplashScreen.SetStatus("Инициализация компонентов...");
            // 
            // Receive
            // 
            this.Receive.BackColor = System.Drawing.Color.Black;
            this.Receive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Receive.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Receive.ForeColor = System.Drawing.Color.Gainsboro;
            this.Receive.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.Receive.Location = new System.Drawing.Point(0, 0);
            this.Receive.Margin = new System.Windows.Forms.Padding(1);
            this.Receive.Name = "Receive";
            this.Receive.Size = new System.Drawing.Size(136, 531);
            this.Receive.TabIndex = 0;
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.Receive.UseCompatibleStateImageBehavior = false;
            this.Receive.View = System.Windows.Forms.View.List;
            this.Receive.DoubleClick += new System.EventHandler(this.Receive_DoubleClick);
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.Color.Black;
            this.Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Send.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Send.ForeColor = System.Drawing.Color.Gainsboro;
            this.Send.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.Send.Location = new System.Drawing.Point(0, 0);
            this.Send.Margin = new System.Windows.Forms.Padding(1);
            this.Send.Name = "Send";
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.Send.Size = new System.Drawing.Size(134, 531);
            this.Send.TabIndex = 1;
            this.Send.UseCompatibleStateImageBehavior = false;
            this.Send.View = System.Windows.Forms.View.List;
            this.Send.DoubleClick += new System.EventHandler(this.Send_DoubleClick);
            SplashScreen.SetStatus("Инициализация компонентов...");
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            SplashScreen.SetStatus("Инициализация компонентов...");
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.Receive);
            SplashScreen.SetStatus("Инициализация компонентов...");
            // 
            // MainContainer.Panel2
            // 
            SplashScreen.SetStatus("Инициализация компонентов...");
            this.MainContainer.Panel2.Controls.Add(this.Send);
            this.MainContainer.Size = new System.Drawing.Size(271, 531);
            this.MainContainer.SplitterDistance = 136;
            this.MainContainer.SplitterWidth = 1;
            this.MainContainer.TabIndex = 2;
            // 
            // Watch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 531);
            this.Controls.Add(this.MainContainer);
            this.Name = "Watch";
            this.Text = "Watch";
            this.VisibleChanged += new System.EventHandler(this.Watch_VisibleChanged);
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            SplashScreen.SetStatus("Инициализация компонентов...");

        }

        #endregion

        public System.Windows.Forms.ListView Receive;
        public System.Windows.Forms.ListView Send;
        private System.Windows.Forms.SplitContainer MainContainer;

    }
}