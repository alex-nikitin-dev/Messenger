using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using TextOperations;
namespace Messenger_Client
{
    public partial class FindUserForm : Form
    {
        public FindUserForm()
        {
            InitializeComponent();
        }

        private void EnableLogin_CheckedChanged(object sender, EventArgs e)
        {
            Login.Enabled   = EnableLogin.Checked;
        }

        private void EnableFirstName_CheckedChanged(object sender, EventArgs e)
        {
            FirstName.Enabled = EnableFirstName.Checked;
        }

        private void EnableLastName_CheckedChanged(object sender, EventArgs e)
        {
            LastName.Enabled = EnableLastName.Checked;
        }

        private void EnableEMail_CheckedChanged(object sender, EventArgs e)
        {
            EMail.Enabled = EnableEMail.Checked;
        }
        bool IsEnableInterface()
        {
            if (EnableLogin.Checked
                || EnableFirstName.Checked
                || EnableLastName.Checked
                || EnableEMail.Checked)
            {
                return true;
            }
            return false;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnEnableWatch(object sender, EventArgs e)
        {
            btnFind.Enabled = IsEnableInterface();
        }

        private void ResultContext_Opening(object sender, CancelEventArgs e)
        {
            if (Results.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// вернёт null если все критерии выбранные для поиска - пустые строки
        /// </summary>
        /// <returns></returns>
        public string[] GetCriteries()
        {
            ArrayList reply = new ArrayList();

            if (!VerifyCriteries()) { return null; }

            if (EnableLogin.Checked)        { reply.Add(Login.Text);     }
            else { reply.Add(""); }

            if (EnableFirstName.Checked)    { reply.Add(FirstName.Text); }
            else { reply.Add(""); }

            if(EnableLastName.Checked)      { reply.Add(LastName.Text);  }
            else { reply.Add(""); }

            if(EnableEMail.Checked)         { reply.Add(EMail.Text);     }
            else { reply.Add(""); }

            return (string[])(reply.ToArray(typeof(string)));
        }
        /// <summary>
        /// true, если хотябы один критерий содержит непробельные символы
        /// </summary>
        /// <returns></returns>
        public bool VerifyCriteries()
        {
            if ( LoginIsOk()     ) { return true; }
            if ( FirstNameIsOk() ) { return true; }
            if ( LastNameIsOk()  ) { return true; }
            if ( EMailNameIsOk() ) { return true; }

            return false;
        }

        public bool LoginIsOk()
        {
            if (!Login.Text.Contains(" "))    { return true; }

            return false;
        }
        public bool FirstNameIsOk()
        {
            if (!FirstName.Text.Contains(" ")) { return true; }

            return false;
        }
        public bool LastNameIsOk()
        {
            if (!LastName.Text.Contains(" ")) { return true; }

            return false;
        }
        public bool EMailNameIsOk()
        {
            if (!EMail.Text.Contains(" "))    { return true; }

            return false;
        }
        private void FindHelpShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FindHelp.Show(@"Возможно вы помните только часть логина или имени и т.д.
                            Воспользуйтесь * и ? для поиска:
                            Например вы ищите ВесьЛогин, но помните только
                            первую часть 'Весь' тогда для поиска достаточно написать 
                            Весь*", Control.FromHandle(lblEmail.Handle), 100000);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (String.Compare(Login.Text, "другие", StringComparison.OrdinalIgnoreCase) == 0) 
            {
                Report.Warning("Логин не может быть 'Другие'");
            }
            else 
            {
                string [] criteries = GetCriteries();
                if (criteries != null)
                {
                    FindClickEvent?.Invoke(criteries);
                }
                else
                {
                    Report.Warning("Необходимо определить хотя бы один критерий\nсодержащий какие-нибудь символы");
                }
            }
        }
        public delegate void FindClickHendler(string [] criteries);
        public event FindClickHendler FindClickEvent;

        DateTime _loadTime;
        private void FindUserForm_Load(object sender, EventArgs e)
        {
            _loadTime = DateTime.Now;
            ViewTimer.Start();
            Tabs.SelectTab(1);
            Tabs.SelectTab(0);
        }

        private void OnViewTimer(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - _loadTime;
            if (ts.Milliseconds > 25)
            {
                this.TopMost = true;
                ViewTimer.Stop();
            }
        }
        //public void ShowMessage(string message)
        //{
        //    Report._Information(message);
        //}
        /// <summary>
        /// Потоковый
        /// </summary>
        public void _SelectTab(int index)
        {
            System.Threading.Thread th = new System.Threading.Thread(DoSelectTab) {IsBackground = true};

            th.Start(index);
        }
        void DoSelectTab(object data)
        {
            this.Tabs.SelectTab((int)data);
        }
        
    }
}