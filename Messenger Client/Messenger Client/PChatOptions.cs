using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParametresLib;
namespace Messenger_Client
{
    public partial class PChatOptions : Form
    {
        public PChatOptions()
        {
            InitializeComponent();
        }
        ParamsStruct _ps;
        private void PChatOptions_Load(object sender, EventArgs e)
        {
            LoadParams();
        }

        void LoadParams()
        {
            _ps = Parametres.Load();
            ViewParams();
        }
        void ViewParams()
        {
            lblBtnSendBackColor.BackColor = _ps.PChatBtnSendBackColor;
            lblBtnSendForeColor.BackColor = _ps.PChatBtnSendForeColor;

            lblMTextBackColor.BackColor = _ps.PChatMTextBackColor;
            lblMTextForeColor.BackColor = _ps.PChatMTextForeColor;

            lblOwnBackColor.BackColor = _ps.PChatOwnBackColor;
            lblOwnForeColor.BackColor = _ps.PChatOwnForeColor;

            lblTimeBackColor.BackColor = _ps.PChatTimeBackColor;
            lblTimeForeColor.BackColor = _ps.PChatTimeForeColor;

            lblViewBackColor.BackColor = _ps.PChatViewBackColor;
            lblViewForeColor.BackColor = _ps.PChatViewForeColor;
        }
        bool OptionsChanged = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (OptionsChanged)
            {
                SaveParams();
            }

            EnableApply(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (OptionsChanged)
            {
                SaveParams();
            }

            Close();
        }
        void SaveParams()
        {
            try
            {
                _ps.PChatBtnSendBackColor   = lblBtnSendBackColor.BackColor;
                _ps.PChatBtnSendForeColor   = lblBtnSendForeColor.BackColor;

                _ps.PChatMTextBackColor     = lblMTextBackColor.BackColor;
                _ps.PChatMTextForeColor     = lblMTextForeColor.BackColor;

                _ps.PChatOwnBackColor       = lblOwnBackColor.BackColor;
                _ps.PChatOwnForeColor       = lblOwnForeColor.BackColor;

                _ps.PChatTimeBackColor      = lblTimeBackColor.BackColor;
                _ps.PChatTimeForeColor      = lblTimeForeColor.BackColor;

                _ps.PChatViewBackColor      = lblViewBackColor.BackColor;
                _ps.PChatViewForeColor      = lblViewForeColor.BackColor;

                Parametres pr = new Parametres();
                pr.Params = _ps;
                pr.Save();

                WasSave = true;
            }
            catch{
            }
            finally
            {
                LoadParams();
            }

        }
        public bool WasSave = false;
        void EnableApply(bool enable)
        {
            OptionsChanged = enable;
            btnApply.Enabled = enable;
        }

        void SetBkColor(object sender)
        {
            Control ctrl = (Control)sender;
            ColorDlg.Color = ctrl.BackColor;

            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                ctrl.BackColor = ColorDlg.Color;
                EnableApply(true);
            }
        }
        private void lblViewForeColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblViewBackColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblMTextForeColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblMTextBackColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblTimeForeColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblTimeBackColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblBtnSendForeColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblBtnSendBackColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblOwnForeColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblOwnBackColor_Click(object sender, EventArgs e)
        {
            SetBkColor(sender);
        }

        private void lblDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ps = Parametres.GetDefault();
            ViewParams();
            EnableApply(true);
        }
    }
}