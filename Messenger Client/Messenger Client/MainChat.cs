using System;
using System.Drawing;
using System.Windows.Forms;
using ParametresLib;
namespace Messenger_Client
{
    public partial class MainChat : Form
    {
        #region Свойства и конструкторы
        public bool CancelClose = true;
        public int  WidthStored;
        public int  HeightStored;
        private readonly string _nameOfTheChat;
        public MainChat(string nameOfTheChat)
        {
            InitializeComponent();
            _nameOfTheChat = nameOfTheChat;
        }
        #endregion

        #region Events

        #region Handling main menu

        private void MM_Topmost_Click(object sender, EventArgs e)
        {
            SwitchTopmost();
        }
        private void MM_Hide_Click(object sender, EventArgs e)
        {
            SwitchHideShow();
        }
        #endregion

        #region Обработка трея
        private void MChatTray_DoubleClick(object sender, EventArgs e)
        {
            SwitchHideShow();
        }

        private void TM_Exit_Click(object sender, EventArgs e)
        {
            CorrectExit();
        }

        private void TM_Show_Click(object sender, EventArgs e)
        {
            SwitchHideShow();
        }
        #endregion

        #region Обработка чат контекста
        private void CC_NikToChat_Click(object sender, EventArgs e)
        {
            MessageText.AppendText(CC_NIK.Text + ":");
        }

        private void CC_Clear_Click(object sender, EventArgs e)
        {
            Chat.Clear();
        }

        private void CC_Expand_Click(object sender, EventArgs e)
        {
            CC_Expand.Text = ChatUsrLstContainer.Panel2Collapsed ?
                @"Спрятать список пользователей" : @"Показать список пользователей";
            ChatUsrLstContainer.Panel2Collapsed  = !ChatUsrLstContainer.Panel2Collapsed;
        }

        private void CC_AutoScroll_Click(object sender, EventArgs e)
        {
            CC_AutoScroll.Checked = !CC_AutoScroll.Checked;
        }
        #endregion

        private void MainExit_Click(object sender, EventArgs e)
        {
            CorrectExit();
        }
       
        private void MainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
            if (CancelClose)
            {
                HideThis();
            }
        }

        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Chat.SelectionStart = Chat.GetCharIndexFromPosition(e.Location);
                ShowNik();
            }
        }
        private void ChatContext_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            CC_NIK.Visible = false;
            CC_SEP.Visible = false;
            CC_NikToChat.Visible = false;
        }
        #endregion

        #region Key's events

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

                // send by network
                SendMessageText();
            }
        }
        public delegate void SayEventHandler(string tirada);
        public event SayEventHandler Say;

        public void SendMessageText()
        {
            if (!ChatAddOwnersMessage(MessageText.Text)) return;
            Say?.Invoke(MessageText.Text);
            MessageText.Text = "";
        }
        #endregion

        #endregion

        #region Операции над формой
        private void HideThis()
        {
            SetVisibleState(false);
        }
        private void ShowThis()
        {
            SetVisibleState(true);
        }

        private void SetVisibleState(bool isVisible)
        {
            Visible = isVisible;
            TM_Show.Text = isVisible ? @"Hide " : @"Show " + _nameOfTheChat;
        }
        private void SwitchHideShow()
        {
            if(Visible)
                HideThis();
            else
                ShowThis();
        }
        private void SwitchTopmost()
        {
            TopMost = !TopMost;
            MM_Topmost.Checked = !TopMost;
        }
        public delegate void WantCloseEventHandler();
        public event WantCloseEventHandler WantClose;

        private void CorrectExit()
        {
            var res = MessageBox.Show($@"Do exit {_nameOfTheChat}?",
                            @"Exit dialog",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                WantClose?.Invoke();        
            }
        }
        
        public void ExitNow()
        {
            CancelClose = false;
            Close();
        }
        #region Печать текста в чате
        public bool ChatAddString(string message)
        {
            return ChatAddString(message,_ps.MChatUserForeColor,_ps.MChatUserBackColor);
        }
        public bool ChatAddOwnersMessage(string message)
        { 
           return ChatAddString(Login,message,_ps.MChatOwnForeColor,_ps.MChatOwnBackColor);
        }
    
        public bool ChatAddString(string message, Color foreColor, Color backColor)
        {
            if (string.IsNullOrWhiteSpace(message)) return false;
            if (!string.IsNullOrEmpty(Chat.Text)) Chat.AppendText(Environment.NewLine);
           
            var time = $"[{DateTime.Now.ToLongTimeString()}] ";
            Chat.AppendText(time);

            Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);
            Chat.SelectionColor = _ps.TimeForeColor;
            Chat.SelectionBackColor = _ps.TimeBackColor;
            Chat.DeselectAll();

            Chat.AppendText(message);
            Chat.Select(Chat.Text.Length - message.Length, message.Length);
            Chat.SelectionBackColor = backColor;
            Chat.SelectionColor = foreColor;
            Chat.DeselectAll();

            if (CC_AutoScroll.Checked) Chat.ScrollToCaret();
            return true;
        }

        public bool ChatAddString(string user,string message, Color foreColor, Color backColor)
        {
            return ChatAddString("<" + user + ">" + message, foreColor, backColor);
        }
       
        void ShowNik()
        {
            int ind = Chat.SelectionStart;
            int first = Chat.Text.LastIndexOf('<', ind);
            int last  = Chat.Text.IndexOf('>', ind);
            if (first > -1 && last > -1)
            {
                string nik = Chat.Text.Substring(first + 1, last - first - 1);

                CC_NIK.Text = nik;
                CC_NIK.Visible          = true;
                CC_SEP.Visible          = true;
                CC_NikToChat.Visible    = true;
            }
        }
        #endregion
        public string Login = "";
        public new void Close()
        {
            base.Close();
        }
        #endregion

        private void ULC_NikToChat_Click(object sender, EventArgs e)
        {
            if (UserList.SelectedItems.Count != 0)
            {
                MessageText.AppendText(UserList.SelectedItems[0].Text + ":");
            }
        }

        private void UserListContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (UserList.SelectedItems.Count == 0)
                e.Cancel = true;
            else
                ULC_NIK.Text = UserList.SelectedItems[0].Text;
        }
        ParamsStruct _ps;
        private void MainChat_Load(object sender, EventArgs e)
        {
            _ps = Parametres.Load();

            MessageText.ForeColor = _ps.MessageTextForeColor;
            MessageText.BackColor = _ps.MessageTextBackColor;
            UserList.ForeColor    = _ps.MChatUListForeColor;
            UserList.BackColor    = _ps.MChatUListBackColor;
            Chat.BackColor        = _ps.MChatBackColor;
            Text = _nameOfTheChat;
        }
    }
}