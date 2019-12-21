using System;
using System.IO;
using System.Windows.Forms;
using MelodyLib;
namespace Messenger_Client.Errors
{
    #region Обработка ошибок
    class ErrorsProc
    {
        public static string _LogPath = Application.StartupPath + @"\errors.log";
        public static bool _debug = false;
        /// <summary>
        /// запись в файл сообщения об ошибке
        /// </summary>
        /// <param name="_E"></param>
        /// <param name="additional">имя метода, вернувшего исключение (и другая доп. информ. через пробел)</param>
        public static void WriteErrorToLog(Exception _E, string additional)
        {
            try
            {
                FileStream fs = new FileStream(_LogPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                if (fs.Position != 0) sw.WriteLine();
                sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sw.Write("  Message: " + _E.Message);
                sw.Write("  Return: " + additional);
                sw.Close();

                if (_debug)
                {
                    Alarm.Sound(Alarm.LevelError.Single);
                }

            }
            catch{
            }
        }
        public static void WriteErrorToLog(string message, string additional)
        {
            try
            {
                FileStream fs = new FileStream(_LogPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                if (fs.Position != 0) sw.WriteLine();
                sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sw.Write("  Message: " + message);
                sw.Write("  Return: "  + additional);
                sw.Close();

                if (_debug)
                {
                    Alarm.Sound(Alarm.LevelError.Single);
                }

            }
            catch{
            }
        }
        public static void WriteErrorAndMessage(Exception _E, string additional,bool showMessage)
        {
            _debug = showMessage;
            WriteErrorToLog(_E,additional);

            if (showMessage)
            {
                MessageBox.Show(_E.Message + " return " + additional, "ErrorProc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void WriteErrorAndMessage(string message, string additional, bool showMessage)
        {
            _debug = showMessage;
            WriteErrorToLog(message, additional);

            if (showMessage)
            {
                MessageBox.Show(message + " return " + additional, "ErrorProc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
      
    
    #endregion
}