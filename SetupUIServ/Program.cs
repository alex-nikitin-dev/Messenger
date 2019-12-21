using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SetupUI
{
    static class Program
    {
        [STAThread]
        static void Main(string [] args)
        {
            if (args.Length != 0)
            {
                if (args[0].CompareTo("-Installing") == 0)
                {
                    mainForm.Show();
                    Application.Run();
                }
                else
                {
                    MessageBox.Show(@"Начните установку с файла Setup.exe",
                                               @"Installation process",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(@"Ошибка установки: отсутствуют необходимые параметры",
                                               @"Installation process",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Error);
            }
                       
        }

        public static void Exit()
        {
            try
            {
                if (MainForm.Steps.Count != 0)
                {
                    Welcome wl = (Welcome)MainForm.GetStep(StepName.Welcome);
                    SetupOption op = (SetupOption)MainForm.GetStep(StepName.Options);
                    SetupProgress pr = (SetupProgress)MainForm.GetStep(StepName.Progress);
                    Finish fn = (Finish)MainForm.GetStep(StepName.Finish);

                    wl.CancelClose = false;
                    op.CancelClose = false;
                    pr.CancelClose = false;
                    fn.CancelClose = false;

                    wl.Close();
                    op.Close();
                    pr.Close();
                    fn.Close();

                    Application.Exit();
                }
            }
            catch(Exception _E){
                MessageBox.Show(_E.Message);
            }
        }
        public static MainForm mainForm = new MainForm();
    }
}