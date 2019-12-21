using System;
using System.IO;
//using System.Threading;
using System.Windows.Forms;

namespace ErrorsProcessingLib
{
    public class ErrorsProc
    {
       // static readonly string Caption = "ErrorProc <" + Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf('\\') + 1) + ">";
        public static string LogPath = Application.StartupPath + @"\errors.log";
        /// <summary>
        /// write to file log
        /// </summary>
        /// <param name="e"></param>
        /// <param name="additional">method which has error</param>
        public static void WriteErrorToLog(Exception e, string additional)
        {
            try
            {
                var fs = new FileStream(LogPath, FileMode.Append, FileAccess.Write);
                var sw = new StreamWriter(fs);
                if (fs.Position != 0) sw.WriteLine();
                sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sw.Write("  Message: " + e.Message);
                sw.Write("  Return: " + additional);
                sw.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        public static void WriteErrorToLog(string message, string additional)
        {
            try
            {
                var fs = new FileStream(LogPath, FileMode.Append, FileAccess.Write);
                var sw = new StreamWriter(fs);
                if (fs.Position != 0) sw.WriteLine();
                sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sw.Write("  Message: " + message);
                sw.Write("  Return: "  + additional);
                sw.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        public static void WriteErrorAndMessage(Exception e, string additional,bool showMessage)
        {
            WriteErrorToLog(e,additional);

            if (showMessage)
            {
                //_ShowMessage(e.Message + " " + additional);
            }
        }
        public static void WriteErrorAndMessage(string message, string additional, bool showMessage)
        {
            WriteErrorToLog(message, additional);

            if (showMessage)
            {
               // _ShowMessage(message + " " + additional);
            }
        }
        ///// <summary>
        ///// streaming
        ///// </summary>
        //static void _ShowMessage(string message)
        //{
        //    //var th = new Thread(DoShowMessage) {IsBackground = true};

        //   //th.Start(message);
        //}
        //static void DoShowMessage(object data)
        //{
        //    var message = (string)data;
        //    MessageBox.Show(message, Caption, MessageBoxButtons.OK, 
        //        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        //}
    }
}