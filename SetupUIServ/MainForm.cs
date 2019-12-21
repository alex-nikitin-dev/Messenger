using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetupUI
{
    public enum StepName
    {
        Welcome,
        Options,
        Progress,
        Finish
    }
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetProgressStep();
           
        }
        DateTime _loadTime;
        private void MainForm_Load(object sender, EventArgs e){
        }
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - _loadTime;
           
            if (ts.TotalMilliseconds >= 1000)
            {
                tmrLoad.Stop();
                UIInitialize();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _loadTime = DateTime.Now;
            tmrLoad.Start();
        }
        public static string _productName = "Messenger Server";
        public static string _productVertion = "v 1.0";
        public static string _description = "Обеспечивает подключение, оповещение и связь клиентов данного приложения. Содержит базу данных пользователей. Поддерживает главный чат(для приватных сообщений необходимо установить клиент)";
        public static string _baseAppName = "MessengerServer.exe";
        public static Hashtable Steps = new Hashtable();
       
        public static int _steps = 8;
        void UIInitialize()
        {
            Welcome w = new Welcome();
            HackForm(w);
            w.Show();
            progress.PerformStep();
            w.Visible = false;
            Steps.Add(StepName.Welcome,w);
            RecoverForm(w);
            progress.PerformStep();

            SetupOption so = new SetupOption();
            HackForm(so);
            so.Show();
            progress.PerformStep();
            so.Visible = false;
            Steps.Add(StepName.Options, so);
            RecoverForm(so);
            progress.PerformStep();

            SetupProgress sp = new SetupProgress();
            HackForm(sp);
            sp.Show();
            progress.PerformStep();
            sp.Visible = false;
            Steps.Add(StepName.Progress, sp);
            RecoverForm(sp);
            progress.PerformStep();

            Finish fn = new Finish();
            HackForm(fn);
            fn.Show();
            progress.PerformStep();
            fn.Visible = false;
            Steps.Add(StepName.Finish, fn);
            RecoverForm(fn);
            progress.PerformStep();

            this.Visible = false;

            ((Welcome)GetStep(StepName.Welcome)).ToCenterScreen();
            GetStep(StepName.Welcome).Visible = true;
        }
        public static Form GetStep(StepName name)
        {
            return (Form)Steps[name];
        }
        void HackForm(Form form)
        {
            form.Opacity = 0;
            form.ShowInTaskbar = false;
            form.Height = 0;
            form.Width = 0;
        }
        void RecoverForm(Form form)
        {
            form.Opacity = 1;
            form.ShowInTaskbar = true;
            form.Height = 380;
            form.Width = 494;
        }
        void SetProgressStep()
        {
            int step = (int)Math.Round((decimal)progress.Maximum / _steps);
            progress.Step = step;
        }

    }
}