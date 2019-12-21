namespace SetupUI
{
    partial class SetupOption
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStartGroup = new System.Windows.Forms.CheckBox();
            this.chkLinkQuickRun = new System.Windows.Forms.CheckBox();
            this.chkLinkDesktop = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.DlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.MainContainer.Panel1.Controls.Add(this.groupBox1);
            this.MainContainer.Panel1.Controls.Add(this.label1);
            this.MainContainer.Panel1.Controls.Add(this.txtPath);
            this.MainContainer.Panel1.Controls.Add(this.btnBrowse);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.btnCancel);
            this.MainContainer.Panel2.Controls.Add(this.btnPrev);
            this.MainContainer.Panel2.Controls.Add(this.btnNext);
            this.MainContainer.Size = new System.Drawing.Size(486, 353);
            this.MainContainer.SplitterDistance = 312;
            this.MainContainer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStartGroup);
            this.groupBox1.Controls.Add(this.chkLinkQuickRun);
            this.groupBox1.Controls.Add(this.chkLinkDesktop);
            this.groupBox1.Location = new System.Drawing.Point(15, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 187);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создать ярлыки";
            // 
            // chkStartGroup
            // 
            this.chkStartGroup.AutoSize = true;
            this.chkStartGroup.Location = new System.Drawing.Point(29, 138);
            this.chkStartGroup.Name = "chkStartGroup";
            this.chkStartGroup.Size = new System.Drawing.Size(127, 17);
            this.chkStartGroup.TabIndex = 4;
            this.chkStartGroup.Text = "Группа в меню пуск";
            this.chkStartGroup.UseVisualStyleBackColor = true;
            // 
            // chkLinkQuickRun
            // 
            this.chkLinkQuickRun.AutoSize = true;
            this.chkLinkQuickRun.Location = new System.Drawing.Point(29, 96);
            this.chkLinkQuickRun.Name = "chkLinkQuickRun";
            this.chkLinkQuickRun.Size = new System.Drawing.Size(205, 17);
            this.chkLinkQuickRun.TabIndex = 5;
            this.chkLinkQuickRun.Text = "Значек в панели быстрой загрузки";
            this.chkLinkQuickRun.UseVisualStyleBackColor = true;
            // 
            // chkLinkDesktop
            // 
            this.chkLinkDesktop.AutoSize = true;
            this.chkLinkDesktop.Location = new System.Drawing.Point(29, 50);
            this.chkLinkDesktop.Name = "chkLinkDesktop";
            this.chkLinkDesktop.Size = new System.Drawing.Size(155, 17);
            this.chkLinkDesktop.TabIndex = 3;
            this.chkLinkDesktop.Text = "Значек на рабочем столе";
            this.chkLinkDesktop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь установки:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(107, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(291, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(404, 35);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Обзор";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(9, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(280, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(95, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "< Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.Location = new System.Drawing.Point(381, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(93, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Установка >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // SetupOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 353);
            this.ControlBox = false;
            this.Controls.Add(this.MainContainer);
            this.Name = "SetupOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Опции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupOption_FormClosing);
            this.Load += new System.EventHandler(this.SetupOption_Load);
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog DlgBrowse;
        private System.Windows.Forms.CheckBox chkLinkQuickRun;
        private System.Windows.Forms.CheckBox chkStartGroup;
        private System.Windows.Forms.CheckBox chkLinkDesktop;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}