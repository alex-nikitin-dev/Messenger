namespace Messenger_Client
{
    partial class PrivateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateForm));
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.ToolChat = new System.Windows.Forms.ToolStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblInfoAdditional = new System.Windows.Forms.ToolStripLabel();
            this.Chat = new System.Windows.Forms.RichTextBox();
            this.ToolMessage = new System.Windows.Forms.ToolStrip();
            this.lblFont = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblBackColor = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblAllColors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToBlack = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.MessageText = new System.Windows.Forms.RichTextBox();
            this.TT_Main = new System.Windows.Forms.ToolTip(this.components);
            this.FontDlg = new System.Windows.Forms.FontDialog();
            this.ColorDlg = new System.Windows.Forms.ColorDialog();
            this.ForceDisconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.ToolChat.SuspendLayout();
            this.ToolMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.ToolChat);
            this.MainContainer.Panel1.Controls.Add(this.Chat);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.MainContainer.Panel2.Controls.Add(this.ToolMessage);
            this.MainContainer.Panel2.Controls.Add(this.btnSend);
            this.MainContainer.Panel2.Controls.Add(this.MessageText);
            this.MainContainer.Size = new System.Drawing.Size(688, 375);
            this.MainContainer.SplitterDistance = 254;
            this.MainContainer.TabIndex = 0;
            // 
            // ToolChat
            // 
            this.ToolChat.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo,
            this.toolStripLabel1,
            this.lblInfoAdditional});
            this.ToolChat.Location = new System.Drawing.Point(0, 0);
            this.ToolChat.Name = "ToolChat";
            this.ToolChat.Size = new System.Drawing.Size(688, 25);
            this.ToolChat.TabIndex = 1;
            this.ToolChat.Text = "toolStrip2";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(102, 22);
            this.lblInfo.Text = "Собеседник: Юзер";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel1.Text = "    ";
            // 
            // lblInfoAdditional
            // 
            this.lblInfoAdditional.Name = "lblInfoAdditional";
            this.lblInfoAdditional.Size = new System.Drawing.Size(158, 22);
            this.lblInfoAdditional.Text = "Дополнительная информация";
            this.lblInfoAdditional.Visible = false;
            // 
            // Chat
            // 
            this.Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Chat.ForeColor = System.Drawing.Color.White;
            this.Chat.Location = new System.Drawing.Point(0, 28);
            this.Chat.Name = "Chat";
            this.Chat.ReadOnly = true;
            this.Chat.Size = new System.Drawing.Size(688, 226);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "";
            // 
            // ToolMessage
            // 
            this.ToolMessage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFont,
            this.toolStripSeparator1,
            this.lblBackColor,
            this.toolStripSeparator2,
            this.lblAllColors,
            this.toolStripSeparator3,
            this.btnToBlack,
            this.btnClear});
            this.ToolMessage.Location = new System.Drawing.Point(0, 0);
            this.ToolMessage.Name = "ToolMessage";
            this.ToolMessage.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolMessage.Size = new System.Drawing.Size(688, 26);
            this.ToolMessage.TabIndex = 2;
            this.ToolMessage.Text = "toolStrip1";
            // 
            // lblFont
            // 
            this.lblFont.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(23, 23);
            this.lblFont.Text = "А";
            this.lblFont.ToolTipText = "Выбор шрифта";
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // lblBackColor
            // 
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(62, 23);
            this.lblBackColor.Text = "Цвет фона";
            this.lblBackColor.ToolTipText = "Установить цвет фона(авто коррекция)";
            this.lblBackColor.Click += new System.EventHandler(this.lblBackColor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // lblAllColors
            // 
            this.lblAllColors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblAllColors.Image = global::Messenger_Client.Properties.Resources.SettingsIco;
            this.lblAllColors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblAllColors.Name = "lblAllColors";
            this.lblAllColors.Size = new System.Drawing.Size(23, 23);
            this.lblAllColors.Text = "Все цвета";
            this.lblAllColors.ToolTipText = "Настройки цвета";
            this.lblAllColors.Click += new System.EventHandler(this.lblAllColors_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // btnToBlack
            // 
            this.btnToBlack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToBlack.Image = global::Messenger_Client.Properties.Resources.IcoToBlack;
            this.btnToBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToBlack.Name = "btnToBlack";
            this.btnToBlack.Size = new System.Drawing.Size(23, 23);
            this.btnToBlack.ToolTipText = "Запретить этого пользователя";
            this.btnToBlack.Click += new System.EventHandler(this.btnToBlack_Click);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = global::Messenger_Client.Properties.Resources.UtilIco;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 23);
            this.btnClear.ToolTipText = "Очистить чат";
            this.btnClear.Click += new System.EventHandler(this.btnClearChat_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSend.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnSend.Location = new System.Drawing.Point(582, 54);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 39);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MessageText
            // 
            this.MessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageText.AutoWordSelection = true;
            this.MessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.MessageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageText.ForeColor = System.Drawing.Color.White;
            this.MessageText.Location = new System.Drawing.Point(3, 29);
            this.MessageText.MaxLength = 255;
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(573, 88);
            this.MessageText.TabIndex = 0;
            this.MessageText.Text = "";
            this.MessageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageText_KeyDown);
            this.MessageText.BackColorChanged += new System.EventHandler(this.MessageText_BackColorChanged);
            // 
            // FontDlg
            // 
            this.FontDlg.Color = System.Drawing.Color.White;
            this.FontDlg.ShowColor = true;
            // 
            // ColorDlg
            // 
            this.ColorDlg.FullOpen = true;
            // 
            // ForceDisconnectTimer
            // 
            this.ForceDisconnectTimer.Tick += new System.EventHandler(this.ForceDisconnectTimer_Tick);
            // 
            // PrivateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(688, 375);
            this.Controls.Add(this.MainContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrivateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приватное общение";
            this.Load += new System.EventHandler(this.PrivateForm_Load);
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.Panel2.PerformLayout();
            this.MainContainer.ResumeLayout(false);
            this.ToolChat.ResumeLayout(false);
            this.ToolChat.PerformLayout();
            this.ToolMessage.ResumeLayout(false);
            this.ToolMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.RichTextBox Chat;
        private System.Windows.Forms.RichTextBox MessageText;
        public System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ToolStrip ToolMessage;
        private System.Windows.Forms.ToolStrip ToolChat;
        private System.Windows.Forms.ToolStripLabel lblInfo;
        private System.Windows.Forms.ToolStripLabel lblBackColor;
        private System.Windows.Forms.ToolStripButton btnToBlack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip TT_Main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.FontDialog FontDlg;
        private System.Windows.Forms.ColorDialog ColorDlg;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripLabel lblFont;
        private System.Windows.Forms.ToolStripButton lblAllColors;
        public System.Windows.Forms.ToolStripLabel lblInfoAdditional;
        private System.Windows.Forms.Timer ForceDisconnectTimer;
    }
}