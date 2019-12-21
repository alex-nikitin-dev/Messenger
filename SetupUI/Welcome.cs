using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetupUI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        public void ToCenterScreen()
        {
            this.CenterToScreen();
        }
        private void lblShowDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblShowDescription.Visible  = false;
            txtDescription.Visible      = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SetupOption so = (SetupOption)MainForm.GetStep(StepName.Options);
            
            so.Top      = this.Top;
            so.Left     = this.Left;
            so.Visible  = true;
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

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            this.Text = MainForm._productName + " " + MainForm._productVertion;
            txtDescription.Text = MainForm._description;
            lblProductName.Text = MainForm._productName;
            lblProductName1.Text = MainForm._productName;
        }
    }
}