using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace SetupUI
{
    public partial class Finish : Form
    {
        public bool CancelClose = true;
        public string _info;
        public string _subinfo;
        public Finish()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (chkFirstRun.Checked)
            {
                SetupProgress sp = (SetupProgress)MainForm.GetStep(StepName.Progress);
                string path = sp._path + "\\" + MainForm._baseAppName;
                Process.Start(path);
            }
            Program.Exit();
        }
        public void SetInfo()
        {
            lblInfo.Text = _info;
            lblInfo.Left = GetLeftCoord(SubContainer.Panel2.Width,lblInfo.Width);
            
            lblSubInfo.Text         = _subinfo;
            lblSubInfo.Left         = GetLeftCoord(SubContainer.Panel2.Width, lblSubInfo.Width);
            lblProductName.Text     = MainForm._productName;
        }
        int GetLeftCoord(int parentWidth, int childWidth)
        {
            return (int)Math.Round((double)(parentWidth - childWidth) / 2);
        }
    }
}