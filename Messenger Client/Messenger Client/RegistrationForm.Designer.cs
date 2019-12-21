namespace Messenger_Client
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.HiddenInfo = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.Label();
            this.btnSendFirst = new System.Windows.Forms.Button();
            this.ConnectTimer = new System.Windows.Forms.Timer(this.components);
            this.lblResultAdditionInfo = new System.Windows.Forms.Label();
            this.lblResultInfo = new System.Windows.Forms.Label();
            this.LoginTT = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSend.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSend.BackgroundImage = global::Messenger_Client.Properties.Resources.butt4;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Location = new System.Drawing.Point(354, 367);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 35);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "регистрация";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.Send_Click);
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLastname.Location = new System.Drawing.Point(129, 278);
            this.txtLastname.MaxLength = 50;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(150, 20);
            this.txtLastname.TabIndex = 5;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFirstname.Location = new System.Drawing.Point(129, 233);
            this.txtFirstname.MaxLength = 50;
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(150, 20);
            this.txtFirstname.TabIndex = 4;
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLogin.Location = new System.Drawing.Point(129, 93);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(150, 20);
            this.txtLogin.TabIndex = 1;
            this.LoginTT.SetToolTip(this.txtLogin, "Логин не может быть пустым и не может содержать\r\nспециальые символы");
            // 
            // txtEMail
            // 
            this.txtEMail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEMail.Location = new System.Drawing.Point(129, 325);
            this.txtEMail.MaxLength = 50;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(150, 20);
            this.txtEMail.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(13, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "EMail";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Пароль";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.Location = new System.Drawing.Point(129, 139);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(13, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Подтверждение";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConfirm.Location = new System.Drawing.Point(129, 187);
            this.txtConfirm.MaxLength = 50;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(150, 20);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCaption.AutoSize = true;
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(76, 23);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(461, 17);
            this.lblCaption.TabIndex = 13;
            this.lblCaption.Text = "Для отправки регистрационных данных заполните все поля";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescription.Location = new System.Drawing.Point(311, 139);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(270, 114);
            this.txtDescription.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(371, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Краткое описание";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(126, 65);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(31, 17);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = "Info";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.BackgroundImage = global::Messenger_Client.Properties.Resources.butt4;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(484, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 35);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // HiddenInfo
            // 
            this.HiddenInfo.AutoSize = true;
            this.HiddenInfo.BackColor = System.Drawing.Color.Transparent;
            this.HiddenInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HiddenInfo.ForeColor = System.Drawing.Color.Navy;
            this.HiddenInfo.Location = new System.Drawing.Point(171, 125);
            this.HiddenInfo.Name = "HiddenInfo";
            this.HiddenInfo.Size = new System.Drawing.Size(270, 17);
            this.HiddenInfo.TabIndex = 17;
            this.HiddenInfo.Text = "Подождите, выполняется подключение";
            this.HiddenInfo.Visible = false;
            // 
            // Progress
            // 
            this.Progress.AutoSize = true;
            this.Progress.BackColor = System.Drawing.Color.Transparent;
            this.Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Progress.ForeColor = System.Drawing.Color.Navy;
            this.Progress.Location = new System.Drawing.Point(250, 148);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(113, 31);
            this.Progress.TabIndex = 18;
            this.Progress.Text = "...........";
            // 
            // btnSendFirst
            // 
            this.btnSendFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendFirst.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSendFirst.BackgroundImage = global::Messenger_Client.Properties.Resources.butt4;
            this.btnSendFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendFirst.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSendFirst.FlatAppearance.BorderSize = 0;
            this.btnSendFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendFirst.Location = new System.Drawing.Point(214, 194);
            this.btnSendFirst.Name = "btnSendFirst";
            this.btnSendFirst.Size = new System.Drawing.Size(176, 35);
            this.btnSendFirst.TabIndex = 22;
            this.btnSendFirst.Text = "Запрос на регистрацию";
            this.btnSendFirst.UseVisualStyleBackColor = false;
            this.btnSendFirst.Click += new System.EventHandler(this.btnSendFirst_Click);
            // 
            // ConnectTimer
            // 
            this.ConnectTimer.Interval = 5000;
            this.ConnectTimer.Tick += new System.EventHandler(this.ConnectTimer_Tick);
            // 
            // lblResultAdditionInfo
            // 
            this.lblResultAdditionInfo.AutoSize = true;
            this.lblResultAdditionInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblResultAdditionInfo.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultAdditionInfo.Location = new System.Drawing.Point(31, 169);
            this.lblResultAdditionInfo.Name = "lblResultAdditionInfo";
            this.lblResultAdditionInfo.Size = new System.Drawing.Size(548, 17);
            this.lblResultAdditionInfo.TabIndex = 24;
            this.lblResultAdditionInfo.Text = "Теперь, чтобы авторизоваться, достаточно ввести свой логин и пароль в главном окн" +
    "е";
            this.lblResultAdditionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultInfo
            // 
            this.lblResultInfo.AutoSize = true;
            this.lblResultInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblResultInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblResultInfo.Location = new System.Drawing.Point(160, 100);
            this.lblResultInfo.Name = "lblResultInfo";
            this.lblResultInfo.Size = new System.Drawing.Size(291, 25);
            this.lblResultInfo.TabIndex = 23;
            this.lblResultInfo.Text = "Регистрация прошла успешно";
            // 
            // LoginTT
            // 
            this.LoginTT.IsBalloon = true;
            this.LoginTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.LoginTT.ToolTipTitle = "Логин";
            this.LoginTT.UseFading = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::Messenger_Client.Properties.Resources.mianbgnd1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(613, 414);
            this.ControlBox = false;
            this.Controls.Add(this.lblResultAdditionInfo);
            this.Controls.Add(this.lblResultInfo);
            this.Controls.Add(this.btnSendFirst);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.HiddenInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.btnSend);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма регистрации";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrationForm_FormClosing);
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label HiddenInfo;
        private System.Windows.Forms.Label Progress;
        private System.Windows.Forms.Timer ConnectTimer;
        public System.Windows.Forms.Label lblResultAdditionInfo;
        public System.Windows.Forms.Label lblResultInfo;
        public System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.Button btnSendFirst;
        private System.Windows.Forms.ToolTip LoginTT;
    }
}