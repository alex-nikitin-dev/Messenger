using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Messenger_Client
{
    public partial class Alert : Form
    {
        public int _width ;
        public int _height ;
        public Alert()
        {
            InitializeComponent();
            _width = this.Width;
            _height = this.Height;
        }
        public string[] Guests
        {
            get
            {
                ArrayList arr = new ArrayList();
                foreach (ListViewItem item in lstGuests.CheckedItems)
                {
                    arr.Add(item.Text);
                }
                return (string[])arr.ToArray(typeof(string));
            }
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void AddGuest(string name)
        {
            lstGuests.Items.Add(name).SubItems.Add("Пользователь будет блокирован");
        }
        public void ClearList()
        {
            lstGuests.Items.Clear();
        }

        private void lstGuests_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (e.Item.Checked)
                {
                    e.Item.SubItems[1].Text = "Пользователь будет разрешен";
                    e.Item.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Item.SubItems[1].Text = "Пользователь будет блокирован";
                    e.Item.BackColor = lstGuests.BackColor;
                }
            }
            catch{
            }
        }
    }
}