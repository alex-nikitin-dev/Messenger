using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SetupUI
{
    public partial class SetupOption : Form
    {
        public SetupOption()
        {
            InitializeComponent();
        }
        public bool CancelClose = true;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Прервать установку " + MainForm._productName + "?",
                                              @"Мастер установки",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                CancelClose = false;
                Program.Exit();
            }
        }

        private void SetupOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Welcome wl  = (Welcome)MainForm.GetStep(StepName.Welcome);
            wl.Left     = this.Left;
            wl.Top      = this.Top;
            wl.Visible  = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SetupProgress sp = (SetupProgress)MainForm.GetStep(StepName.Progress);
            SetupProgress._addOptionCount = 0;
            if (chkLinkDesktop.Checked) { sp._linkDesktop = true; SetupProgress._addOptionCount++; }
            else sp._linkDesktop = false;

            if (chkLinkQuickRun.Checked) { sp._linkQuickRun = true; SetupProgress._addOptionCount++; }
            else sp._linkQuickRun = false;

            if (chkStartGroup.Checked) { sp._StartGroup = true; SetupProgress._addOptionCount++; }
            else { sp._StartGroup = false; SetupProgress._addOptionCount++; }

            if (!PathIsValid(txtPath.Text))
            {
                MessageBox.Show(@"Неверно задан путь установки",
                                              @"Мастер установки",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                return;
            }
            sp._path = txtPath.Text;

            this.Visible    = false;
            sp.Top          = this.Top;
            sp.Left         = this.Left;
            sp.Visible      = true;
            sp.SetProgressStep();
            sp.BeginSetup();
        }
        public void ToCenterScreen()
        {
            this.CenterToScreen();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (DlgBrowse.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text= DlgBrowse.SelectedPath;
            }
        }
        bool PathIsValid(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                if ((di.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }

                return false;
            }
            catch (Exception _E)
            {
                return false;
            }
        }

        private void SetupOption_Load(object sender, EventArgs e)
        {
            try
            {
                string ppath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                ppath += "\\Messenger .NET";
                Directory.CreateDirectory(ppath);
                txtPath.Text = ppath;
            }
            catch{
                txtPath.Text = "";
            }
        }
    }
}