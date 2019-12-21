using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorsProcessingLib;
using TextOperations;
namespace MessengerServer
{
    public partial class BanForm : Form
    {
        public BanForm()
        {
            InitializeComponent();
        }
        string _login = "";
        bool _edit = false;
        DateTime _endDate;
        bool _byIP = false;
        string _reason = "";

        public string out_login = "";
        public int out_login_id = -1;
        public BanForm(string login):this()
        {
            _login = login;
        }
        public BanForm(string login,DateTime ed, bool byIP, string reason,bool edit):this(login)
        {
            _reason     = reason;
            _byIP       = byIP;
            _endDate    = ed;
            _edit       = edit;
        }
        private void BanForm_Load(object sender, EventArgs e)
        {
            this.banReasonsTableAdapter.Fill(this.userDataSet.BanReasons);
            this.banRulesTableAdapter.Fill(this.userDataSet.BanRules);
            this.accountTableAdapter.Fill(this.userDataSet.Account);

            cbxEndData.Value = DateTime.Now;

            InitInterface();
        }
        void InitInterface()
        {
            try
            {
                cbxLogin.SelectedIndex = -1;
                cbxReson.SelectedIndex = -1;

                if (_Text.ConteinsNotSpaces(_login))
                {
                    int indx = cbxLogin.FindString(_login);
                    if (indx != -1)
                    {
                        cbxLogin.SelectedIndex = indx;
                    }
                }
                
                if (_edit)
                {
                    int indx = cbxReson.FindString(_reason);
                    if (indx != -1)
                    {
                        cbxReson.SelectedIndex = indx;
                    }
                    
                    chkByIP.Checked = _byIP;

                    cbxEndData.Value = _endDate;
                }
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "InitInterface in BanForm.cs");
            }
        }
        
        private void cbxReson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id  = (int)cbxReson.SelectedValue;
                int sec = userDataSet.BanRules.FindByid(id).GeneralTime;

                cbxEndData.Value = DateTime.Now.AddSeconds(sec);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "cbxReson_SelectedIndexChanged in BanForm.cs");
            }
        }

        private void btnAddBanRule_Click(object sender, EventArgs e)
        {
            new BanRuleForm().ShowDialog();

            this.userDataSet.BanRules.Clear();
            this.userDataSet.BanReasons.Clear();

            this.banRulesTableAdapter.Fill(this.userDataSet.BanRules);
            this.banReasonsTableAdapter.Fill(this.userDataSet.BanReasons);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxReson.SelectedIndex == -1)
                {
                    MessageBox.Show(@"Choise Reason or create new", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbxEndData.Value <= DateTime.Now)
                {
                    MessageBox.Show(@"End Date can not be less or equal then current time", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbxLogin.SelectedIndex == -1)
                {
                    MessageBox.Show(@"Choise login!", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool byip           = chkByIP.Checked;
                int AccountId       = (int)cbxLogin.SelectedValue;
                int reson           = (int)cbxReson.SelectedValue;
                DateTime enddate    = cbxEndData.Value;

                UserDataSet.AccountRow row = userDataSet.Account.FindById(AccountId);

                row.Banned          = true;
                row.BanByIp         = byip;
                row.BanTimespan     = enddate;
                row.BanReason       = reson;

                accountTableAdapter.Update(userDataSet.Account);

                out_login_id = AccountId;
                
                CancelClose = false;
                Close();
            }
            catch (Exception _E)
            {
                MessageBox.Show(_E.Message,@"Messenger Server", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }

        }
        bool CancelClose = true;
        private void BanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClose = false;
            Close();
        }

        private void cbxLogin_DropDown(object sender, EventArgs e)
        {
            try
            {
                cbxLogin.Items.Remove("Другие");
            }
            catch{
            }
        }

    }
}