using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Messenger_Client
{
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}