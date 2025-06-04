using System;
using System.IO;
//using System.Windows.Forms;

namespace ErrorsProcessingLib
{
    public class ErrorsProc
    {
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + @"errors.log";

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
                sw.Write("  Return: " + additional);
                sw.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void WriteErrorAndMessage(Exception e, string additional, bool showMessage)
        {
            WriteErrorToLog(e, additional);

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
    }
}