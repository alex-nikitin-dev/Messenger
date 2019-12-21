namespace SetupUI
{
    partial class Welcome
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
            this.lblShowDescription = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProductName1 = new System.Windows.Forms.Label();
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
            this.MainContainer.TabIndex = 0;
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
            this.SubContainer.Panel2.Controls.Add(this.lblShowDescription);
            this.SubContainer.Panel2.Controls.Add(this.label1);
            this.SubContainer.Panel2.Controls.Add(this.txtDescription);
            this.SubContainer.Panel2.Controls.Add(this.label4);
            this.SubContainer.Panel2.Controls.Add(this.lblProductName1);
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
            // lblShowDescription
            // 
            this.lblShowDescription.AutoSize = true;
            this.lblShowDescription.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lblShowDescription.Location = new System.Drawing.Point(16, 69);
            this.lblShowDescription.Name = "lblShowDescription";
            this.lblShowDescription.Size = new System.Drawing.Size(69, 13);
            this.lblShowDescription.TabIndex = 5;
            this.lblShowDescription.TabStop = true;
            this.lblShowDescription.Text = "Описание>>";
            this.lblShowDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowDescription_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(46, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Нажмите кнопку \'Вперёд\' для продолжения";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDescription.Location = new System.Drawing.Point(19, 85);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(280, 157);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "Программа предназначена для ...";
            this.txtDescription.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(36, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Вас приветствует мастер установки";
            // 
            // lblProductName1
            // 
            this.lblProductName1.AutoSize = true;
            this.lblProductName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductName1.Location = new System.Drawing.Point(108, 46);
            this.lblProductName1.Name = "lblProductName1";
            this.lblProductName1.Size = new System.Drawing.Size(102, 17);
            this.lblProductName1.TabIndex = 1;
            this.lblProductName1.Text = "Product Name ";
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
            this.btnNext.Text = "Вперед >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 353);
            this.ControlBox = false;
            this.Controls.Add(this.MainContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Name v 1.0";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.Load += new System.EventHandler(this.Welcome_Load);
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProductName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.LinkLabel lblShowDescription;
    }
}