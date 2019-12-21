using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ErrorsProcessingLib;
using ParametresLib;
namespace Messenger_Client
{
    public partial class PrivateForm : Form
    {
        public PrivateForm(string user,string ownName)
        {
            InitializeComponent();

            _user  = user;
            _owner = ownName;
            lblInfo.Text = @"Собеседник: " + _user;
        }
        public bool IsDebug;
        ParamsStruct _ps;

        private readonly string _user;
        private readonly string _owner;
        
        public string StartMessage = "";
        public Font StartFont;
        public Color StartColor;
        public bool StartMessageNeed;

        bool _forceDisconnect;

        public string Interlocutor => _user;

        #region Окно ввода текста

        private void MessageText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                e.Handled = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                //
                //     отправка по сети
                //

                SendMessageText();
            }
        }
        public delegate void SayEventHandler(string toUser,string tirada,Color color,string fontName,string fontSize);
        public event SayEventHandler SayEvent;

        public void SendMessageText()
        {
            try
            {
                if (!ChatAddOwnerMessage(MessageText.Text)) return;
                SayEvent?.Invoke(_user,MessageText.Text,_ps.PChatOwnForeColor,_ps.PChatOwnerFont.Name,_ps.PChatOwnerFont.Size.ToString(CultureInfo.InvariantCulture));
                MessageText.Text = "";
            }
            catch(Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "SendMessageText in PrivateForm.cs",IsDebug);
            }
        }
        #endregion

        #region Печать текста в чате
        public bool ChatAddString(string message)
        {
            return ChatAddString(message, _ps.PChatViewForeColor, _ps.PChatViewBackColor);
        }
        public bool ChatAddOwnerMessage(string message)
        {
            return ChatAddString(_owner,message, _ps.PChatOwnForeColor, _ps.PChatOwnBackColor, _ps.PChatOwnerFont);
        }
        public void UserSay(string nik, string message)
        {
            ChatAddString("<" + nik + ">" + message);
        }
        public bool ChatAddString(string message, Color foreColor, Color backColor)
        {
            return ChatAddString(message,foreColor,backColor,Chat.Font);
        }
        public bool ChatAddString(string message, Color foreColor, Color backColor,Font font)
        {
           
                

                if (!String.IsNullOrEmpty(Chat.Text))
                {
                    Chat.AppendText("\n");
                }

                string time = "[" + DateTime.Now.ToLongTimeString() + "] ";
                Chat.AppendText(time);

                Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);

                Chat.SelectionColor     = _ps.PChatTimeForeColor;
                Chat.SelectionBackColor = _ps.PChatViewBackColor;

                Chat.DeselectAll();

                string apndtxt = message;
                Chat.AppendText(apndtxt);

                Chat.Select(Chat.Text.Length - apndtxt.Length, apndtxt.Length);
                Chat.SelectionBackColor = backColor;
                Chat.SelectionColor = foreColor;
                Chat.SelectionFont = font;
                Chat.DeselectAll();

                Chat.ScrollToCaret();
                return true;
            

        }
        public bool ChatAddString(string user,string message, Color foreColor, Color backColor, Font font)
        {
           
             

                if (!String.IsNullOrEmpty(Chat.Text))
                {
                    Chat.AppendText("\n");
                }

                message = "<" + user + ">" + message;

                string time = "[" + DateTime.Now.ToLongTimeString() + "] ";
                Chat.AppendText(time);

                Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);

                Chat.SelectionColor = _ps.PChatTimeForeColor;
                Chat.SelectionBackColor = _ps.PChatViewBackColor;

                Chat.DeselectAll();

                string apndtxt = message;
                Chat.AppendText(apndtxt);

                Chat.Select(Chat.Text.Length - apndtxt.Length, apndtxt.Length);
                Chat.SelectionBackColor = backColor;
                Chat.SelectionColor = foreColor;
                Chat.SelectionFont = font;
                Chat.DeselectAll();

                Chat.ScrollToCaret();
                return true;
           
        }
        public bool ChatAddString(string message, Color foreColor)
        {
            return ChatAddString(message, foreColor, _ps.MChatBackColor);
        }
        public bool ChatAddString(string message, Font font)
        {
            return ChatAddString(message, _ps.PChatViewForeColor, _ps.PChatViewBackColor,font);
        }
        public bool ChatAddString(string message,Color foreColor,Font font)
        {
            return ChatAddString(message, foreColor, _ps.PChatViewBackColor, font);
        }
        #endregion

        private void PrivateForm_Load(object sender, EventArgs e)
        {
            LoadParams();
            if (StartMessageNeed)
            {
                OnRecive(StartMessage, StartColor, StartFont);
                StartMessageNeed = false;
            }
        }
        void LoadParams()
        {
#if DEBUG
            IsDebug = true;
#endif
            _ps                     = Parametres.Load();

            Chat.ForeColor          = _ps.PChatViewForeColor;
            Chat.BackColor          = _ps.PChatViewBackColor;

            MessageText.ForeColor   = _ps.PChatMTextForeColor;
            MessageText.BackColor   = _ps.PChatMTextBackColor;

            btnSend.ForeColor       = _ps.PChatBtnSendForeColor;
            btnSend.BackColor       = _ps.PChatBtnSendBackColor;

            MessageText.Font        = _ps.PChatOwnerFont;

        }
        void SaveParams()
        {
            Parametres pr = new Parametres();
            pr.Params = _ps;
            pr.Save();

            LoadParams();
        }

        private void lblFont_Click(object sender, EventArgs e)
        {
            FontDlg.Font    = _ps.PChatOwnerFont;
            FontDlg.Color   = _ps.PChatOwnForeColor;

            if(FontDlg.ShowDialog() == DialogResult.OK)
            {
                _ps.PChatOwnForeColor   = FontDlg.Color;
                _ps.PChatOwnerFont      = FontDlg.Font;
                _ps.PChatMTextForeColor = FontDlg.Color;

                SaveParams();
            }
        }
        
        private void lblBackColor_Click(object sender, EventArgs e)
        {
            ColorDlg.Color = Chat.BackColor;
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                _ps.PChatViewBackColor  = ColorDlg.Color;
                _ps.PChatMTextBackColor = ColorDlg.Color;
                _ps.PChatTimeBackColor  = ColorDlg.Color;
                _ps.PChatOwnBackColor   = ColorDlg.Color;

                Chat.SelectAll();
                Chat.SelectionBackColor = ColorDlg.Color;
                

                if (ColorDlg.Color.GetBrightness() < 0.5)
                {
                    _ps.PChatBtnSendBackColor = ControlPaint.Light(ColorDlg.Color);
                    _ps.PChatBtnSendForeColor = ControlPaint.LightLight(ColorDlg.Color);
                    if (_ps.PChatOwnForeColor.GetBrightness() < 0.6)
                    {
                        _ps.PChatOwnForeColor   = ControlPaint.Light(_ps.PChatOwnForeColor);
                        _ps.PChatMTextForeColor = ControlPaint.Light(_ps.PChatMTextForeColor);
                    }

                    _ps.PChatTimeForeColor = ControlPaint.LightLight(ColorDlg.Color);
                    Chat.SelectionColor    = ControlPaint.LightLight(ColorDlg.Color);
                }
                else
                {
                    _ps.PChatBtnSendBackColor = ControlPaint.Dark(ColorDlg.Color);
                    _ps.PChatBtnSendForeColor = ControlPaint.LightLight(ColorDlg.Color);

                    if (_ps.PChatOwnForeColor.GetBrightness() >= 0.5)
                    {
                        _ps.PChatOwnForeColor = ControlPaint.Dark(_ps.PChatOwnForeColor);
                        _ps.PChatMTextForeColor = ControlPaint.Dark(_ps.PChatMTextForeColor);
                    }

                    _ps.PChatTimeForeColor = ControlPaint.Dark(ColorDlg.Color);
                    Chat.SelectionColor    = ControlPaint.DarkDark(ColorDlg.Color);
                }
                Chat.DeselectAll();

                SaveParams();
            }
        }
        public delegate void UserToBlackEventHandler(string login);
        public event UserToBlackEventHandler UserToBlackEvent;

        private void btnToBlack_Click(object sender, EventArgs e)
        {
            if (Report.Prompt("Запретить пользователя " + _user + " (при этом данное окно будет закрыто)?") == DialogResult.Yes)
            {
                UserToBlackEvent?.Invoke(_user);
                System.Threading.Thread.Sleep(500);
                Close();
            }
        }


        private void MessageText_BackColorChanged(object sender, EventArgs e)
        {
            MainContainer.Panel2.BackColor = ((Control)sender).BackColor;
        }

        private void lblAllColors_Click(object sender, EventArgs e)
        {
            PChatOptions opt = new PChatOptions();
            opt.ShowDialog();

            if (opt.WasSave)
            {
                LoadParams();
            }

        }
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            Chat.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessageText();
        }
        bool _interfaceEnabled = true;
        public bool InterfaceEnabled => _interfaceEnabled;

        public void SwitchToDisconnectState(string info)
        {
            lblInfoAdditional.Visible = true;
            lblInfoAdditional.Text = info;

            MessageText.Visible = false;
            MainContainer.Panel2.Enabled = false;

            _interfaceEnabled = false;
        }
        public void ShowInformation(string info)
        {
            lblInfoAdditional.Visible = true;
            lblInfoAdditional.Text = info;
        }
        public void EnableInterface()
        {
            if (!InterfaceEnabled && !_forceDisconnect)
            {
                lblInfoAdditional.Visible = false;
                lblInfoAdditional.Text = "";

                MainContainer.Panel2.Enabled = true;
                MessageText.Visible = true;

                _interfaceEnabled = true;
            }
        }
        public void OnRecive(string message,Color color,Font font)
        {
            ChatAddString("<" + _user +">" + message,color,font);
        }

        private void ForceDisconnectTimer_Tick(object sender, EventArgs e)
        {
            if (_forceDisconnect)
            {
                SwitchToDisconnectState("Вы не можете отправлять сообщения с установленным состоянием 'Off'");
            }
        }

        public bool ForceDisconnectStart()
        {
            if (!_forceDisconnect)
            {
                _forceDisconnect = true;
                ForceDisconnectTimer.Start();

                return true;
            }

            return false;
        }
        public bool ForceDisconnectStop()
        {
            if (_forceDisconnect)
            {
                _forceDisconnect = false;
                ForceDisconnectTimer.Stop();
                return true;
            }
            return false;
        }
    }
}