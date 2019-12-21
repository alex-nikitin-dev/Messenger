using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Messenger_Client
{
    public partial class Watch : Form
    {
        public MainForm _main;
        public Watch(MainForm main)
        {
            _main = main;
            InitializeComponent();
        }

        private void Watch_VisibleChanged(object sender, EventArgs e)
        {
            if (!_main.Debug)
            {
                Visible = false;
            }
        }

        
        private void Receive_DoubleClick(object sender, EventArgs e)
        {
            MainContainer.Panel2Collapsed = !MainContainer.Panel2Collapsed;
        }

        private void Send_DoubleClick(object sender, EventArgs e)
        {
            MainContainer.Panel1Collapsed = !MainContainer.Panel1Collapsed;
        }

    }
}