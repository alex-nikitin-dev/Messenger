using System;
using System.Windows.Forms;
using SplashScreenLib;
using System.IO;
namespace Messenger_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            SplashScreen.ShowSplashScreen(10);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen.SetStatus(@"Инициализация компонентов...");
            Application.Run(new MainForm());
        }

        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            var fs = new FileStream("g:\\log.txt",FileMode.Append, FileAccess.Write);
            var sw = new StreamWriter(fs);
            try
            {
                sw.WriteLine(args.LoadedAssembly.FullName);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}