using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Messenger_Client
{
    public partial class _Report : Form
    {
        public _Report(string message,string caption)
        {
            InitializeComponent();
            this.message.Text = message;
            this.Text = caption;
        }
        private void MsgBox_Load(object sender, EventArgs e)
        {
            this.Width = message.Width + 20;
            message.Left = GetLeftCoord(this.Width,message.Width);
        }
        int GetLeftCoord(int parentWidth, int childWidth)
        {
            return (int)Math.Round((double)(parentWidth - childWidth) / 2);
        }

        public static DialogResult EnError(string message)
        {
            new _Report(message, "Messenger").Show();
            return DialogResult.OK;
        }
        public static DialogResult EnError(string message, string caption)
        {
            new _Report(message, "Messenger").Show();
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, @"Messenger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Warning(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public static DialogResult Prompt(string message)
        {
            return MessageBox.Show(message, @"Messenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Prompt(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Information(string message)
        {
            return MessageBox.Show(message, @"Messenger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Information(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}