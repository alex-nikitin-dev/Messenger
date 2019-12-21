namespace SetupUI
{
    partial class Finish
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
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.SubContainer = new System.Windows.Forms.SplitContainer();
            this.lblProductName = new System.Windows.Forms.Label();
            this.chkFirstRun = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSubInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SubContainer.Panel1.SuspendLayout();
            this.SubContainer.Panel2.SuspendLayout();
            this.SubContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.MainContainer.Panel1.Controls.Add(this.SubContainer);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.btnCancel);
            this.MainContainer.Panel2.Controls.Add(this.btnPrev);
            this.MainContainer.Panel2.Controls.Add(this.btnNext);
            this.MainContainer.Size = new System.Drawing.Size(486, 353);
            this.MainContainer.SplitterDistance = 312;
            this.MainContainer.TabIndex = 2;
            // 
            // SubContainer
            // 
            this.SubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubContainer.IsSplitterFixed = true;
            this.SubContainer.Location = new System.Drawing.Point(0, 0);
            this.SubContainer.Name = "SubContainer";
            // 
            // SubContainer.Panel1
            // 
            this.SubContainer.Panel1.BackgroundImage = global::SetupUI.Properties.Resources.mianbgnd1;
            this.SubContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubContainer.Panel1.Controls.Add(this.lblProductName);
            // 
            // SubContainer.Panel2
            // 
            this.SubContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.SubContainer.Panel2.Controls.Add(this.chkFirstRun);
            this.SubContainer.Panel2.Controls.Add(this.label1);
            this.SubContainer.Panel2.Controls.Add(this.lblInfo);
            this.SubContainer.Panel2.Controls.Add(this.lblSubInfo);
            this.SubContainer.Size = new System.Drawing.Size(486, 312);
            this.SubContainer.SplitterDistance = 167;
            this.SubContainer.SplitterWidth = 1;
            this.SubContainer.TabIndex = 0;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(12, 24);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(143, 24);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // chkFirstRun
            // 
            this.chkFirstRun.AutoSize = true;
            this.chkFirstRun.Enabled = false;
            this.chkFirstRun.Location = new System.Drawing.Point(26, 220);
            this.chkFirstRun.Name = "chkFirstRun";
            this.chkFirstRun.Size = new System.Drawing.Size(268, 17);
            this.chkFirstRun.TabIndex = 5;
            this.chkFirstRun.Text = "Запустить программу после закрытия мастера";
            this.chkFirstRun.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(46, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Нажмите кнопку \'Закрыть\' для выхода ";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(38, 24);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(242, 17);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Установка успешно завершена";
            // 
            // lblSubInfo
            // 
            this.lblSubInfo.AutoSize = true;
            this.lblSubInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubInfo.Location = new System.Drawing.Point(110, 58);
            this.lblSubInfo.Name = "lblSubInfo";
            this.lblSubInfo.Size = new System.Drawing.Size(99, 13);
            this.lblSubInfo.TabIndex = 1;
            this.lblSubInfo.Text = "Все установилось";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(9, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(280, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(95, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "< Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(381, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(93, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Закрыть";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Finish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 353);
            this.ControlBox = false;
            this.Controls.Add(this.MainContainer);
            this.Name = "Finish";
            this.ShowIcon = false;
            this.Text = "Завершение установки";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.ResumeLayout(false);
            this.SubContainer.Panel1.ResumeLayout(false);
            this.SubContainer.Panel1.PerformLayout();
            this.SubContainer.Panel2.ResumeLayout(false);
            this.SubContainer.Panel2.PerformLayout();
            this.SubContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.SplitContainer SubContainer;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSubInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.CheckBox chkFirstRun;

    }
}