using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShortcutLib;
using SetupParamsLib;
using System.Runtime.Serialization.Formatters.Binary;
using LinkLocation = SetupParamsLib.SetupParams.LinkLocation;
namespace Uninstaller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string _productName;
        int _steps = 0;
        SetupParams.Params _params;
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!SetupParams.Load(out _params))
            {
                Application.Exit();
            }
            _productName = _params.productName;
           
            _steps += _params.files.Count;
            _steps += _params.folders.Count;
            _steps += _params.links.Count;
            _steps += _params.startGroups.Count;
            
            DialogResult res =  MessageBox.Show(@"Вы действительно хотите удалить приложение и все его компоненты с вашего компьютера?",
                                                _productName,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                BeginUninstall();
            }
            else
            {
                Application.Exit();
            }
        }
        void ProgressStep(string info)
        {
            progress.PerformStep();
            lblInfo.Text = info;
            lblInfo.Update();
            System.Threading.Thread.Sleep(300);
        }
        public void SetProgressStep()
        {
            int step = (int)Math.Round((decimal)progress.Maximum / _steps);
            progress.Step = step;
        }
       
        void DoUininstall()
        {
            foreach (object[] arr in _params.links)
            {
                try
                {
                    LinkLocation ll = (LinkLocation)arr[1];
                    string name = (string)arr[0];
                    if (ll == LinkLocation.Desktop)
                    {
                        ShortcutEx.DeleteDesktopLink(name);
                        ProgressStep("Удаление ярлыков с рабочего стола");
                    }
                    else if (ll == LinkLocation.QuickLaunch)
                    {
                        ShortcutEx.DeleteQuickLaunchLink(name);
                        ProgressStep("Удаление ярлыков с панели быстрого запуска");
                    }
                }
                catch{
                }
            }
            foreach (object sg in _params.startGroups)
            {
                try
                {
                    string name = sg.ToString();
                    ShortcutEx.DeleteStartMenuGroup(name);
                    ProgressStep("Удаление группы в меню пуск");
                }
                catch{
                }
            }
            foreach (object file in _params.files)
            {
                try
                {
                    string fpath = file.ToString();
                    FileInfo fi = new FileInfo(fpath);
                    fi.Delete();
                    ProgressStep(fi.Name);
                }
                catch{
                }
            }
            foreach (object dir in _params.folders)
            {
                try
                {   
                    string dpath = dir.ToString();
                    DirectoryInfo di = new DirectoryInfo(dpath);
                    di.Delete(true);
                    ProgressStep(di.Name);
                }
                catch{
                }
            }

            this.Visible = false;
           MessageBox.Show(@"Деинсталляция успешно завершена",
                           _productName,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
           Close();
        }
        DateTime _loadTime;
        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - _loadTime;

            if (ts.TotalMilliseconds >= 1000)
            {
                tmrDelay.Stop();
                DoUininstall();
            }
        }
        void BeginUninstall()
        {
            _loadTime = DateTime.Now;
            tmrDelay.Start();
        }
        
    }
}