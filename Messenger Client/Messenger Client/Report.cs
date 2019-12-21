using System;
using System.Threading;
using System.Windows.Forms;

namespace Messenger_Client
{
    /// <summary>
    /// Для показа окна сообщения по шаблону(в загововках - Messenger)
    /// </summary>
    public class Report
    {
        public static string _caption = "Messenger";
        public static DialogResult EnError(string message)
        {
            return MessageBox.Show(message, _caption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        public static DialogResult EnError(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }


        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, _caption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        public static DialogResult Warning(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }


        public static DialogResult Prompt(string message)
        {
            return MessageBox.Show(message, _caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Prompt(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Information(string message)
        {
            return MessageBox.Show(message, _caption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        public static DialogResult Information(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        /// <summary>
        /// Потоковый
        /// </summary>
        public static void _Information(string message)
        {
            Thread th = new Thread(new ParameterizedThreadStart(DoInformation));
            th.IsBackground = true;

            th.Start(message);
        }
        private static void DoInformation(object data)
        {
            string message = (string)data;
            Information(message);
        }

        /// <summary>
        /// Потоковый
        /// </summary>
        public static void _EnError(string message)
        {
            Thread th = new Thread(new ParameterizedThreadStart(DoEnError));
            th.IsBackground = true;

            th.Start(message);
        }
        private static void DoEnError(object data)
        {
            string message = (string)data;
            EnError(message);
        }

        /// <summary>
        /// Потоковый
        /// </summary>
        public static void _Warning(string message)
        {
            Thread th = new Thread(new ParameterizedThreadStart(DoWarning));
            th.IsBackground = true;

            th.Start(message);
        }
        private static void DoWarning(object data)
        {
            string message = (string)data;
            Warning(message);
        }
    }
}
