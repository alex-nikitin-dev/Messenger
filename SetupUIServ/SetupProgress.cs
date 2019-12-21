using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShortcutLib;
using System.IO;
using SetupParamsLib;
using System.Runtime.Serialization.Formatters.Binary;
using LinkLocation = SetupParamsLib.SetupParams.LinkLocation;
namespace SetupUI
{
    public partial class SetupProgress : Form
    {
        public bool     CancelClose = true;
        public string   _path;
        public bool     _linkDesktop;
        public bool     _linkQuickRun;
        public bool     _StartGroup;

        public SetupProgress()
        {
            InitializeComponent();
        }

        private void SetupProgress_Load(object sender, EventArgs e)
        {
            this.Text = MainForm._productName + " " + MainForm._productVertion; 
        }

        public void BeginSetup()
        {
            _loadTime = DateTime.Now;
            tmrLoad.Start();
        }
        DateTime _loadTime;
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - _loadTime;

            if (ts.TotalMilliseconds >= 1000)
            {
                tmrLoad.Stop();
                DoInstalling();
            }
        }
        public static int _addOptionCount = 0;
        int _steps = _addOptionCount + DistribFilesCount;
        public void SetProgressStep()
        {
            _steps = _addOptionCount + DistribFilesCount;
            int step = (int)Math.Round((decimal)progress.Maximum / _steps);
            progress.Step = step;
        }
        void DoInstalling()
        {
            if (BaseInstall())
            {
                CreateLinks();
                SaveLog();
                Finish fn = (Finish)MainForm.GetStep(StepName.Finish);
                fn.chkFirstRun.Enabled = true;
                ShowResult("Установка успешно завершена","Все компоненты установлены и программа готова к работе");
            }
            else
            {
                ShowResult("Установка не удалась","Ошибка при установке базового пакета");
            }
        }
        void ShowResult(string info,string subinfo)
        {
            this.Visible    = false;
            Finish fn       = (Finish)MainForm.GetStep(StepName.Finish);
            fn._info        = info;
            fn._subinfo     = subinfo;
            fn.SetInfo();
            fn.Top          = this.Top;
            fn.Left         = this.Left;
            fn.Visible      = true;
        }
        bool BaseInstall()
        {
            try
            {
                _params.files       = new ArrayList();
                _params.folders     = new ArrayList();
                _params.links       = new ArrayList();
                _params.startGroups = new ArrayList();

                string spath = Application.StartupPath;
                string bsdist = spath + "\\bsdist";

                string[] bsFiles = Directory.GetFiles(bsdist);
                foreach (string file in bsFiles)
                {
                    FileInfo fi = new FileInfo(file);
                    string tofile = _path + "\\" + fi.Name;
                    File.Copy(file, tofile, true);
                    _params.files.Add(tofile);
                    
                    ProgressStep(fi.Name);
                }
                return true;
            }
            catch (Exception _E)
            {
#if DEBUG
                MessageBox.Show(_E.Message, @"BaseInstall", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                return false;
            }
        }
       
        SetupParams.Params _params;
        static int DistribFilesCount
        {
            get
            {
                try
                {
                    string spath = Application.StartupPath;
                    string bsdist = spath + "\\bsdist";

                    string[] bsFiles = Directory.GetFiles(bsdist);
                    return bsFiles.Length;
                }
                catch (Exception _E)
                {
                    MessageBox.Show(_E.Message, @"DistribFilesCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }
        void SaveLog()
        {
            _params.baseAppName     = MainForm._baseAppName;
            _params.description     = MainForm._description;
            _params.productName     = MainForm._productName;
            _params.productVertion  = MainForm._productVertion;

            string ppath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            ppath += "\\XMessengerServer";
            _params.folders.Add(ppath);
            
            SetupParams._path = _path;
            SetupParams.Save(_params);
        }
        void ProgressStep(string info)
        {
            progress.PerformStep();
            lblInfo.Text = info;
            lblInfo.Update();
            System.Threading.Thread.Sleep(100);
        }
        void CreateLinks()
        {
            try
            {
                if (_linkDesktop)
                {
                    ShortcutEx.CreateDesktopLink(MainForm._productName,
                                                 _path + "\\" + MainForm._baseAppName,
                                                 MainForm._description);
                    ProgressStep("Ярлык для рабочего стола");
                    _params.links.Add(new object[] { MainForm._productName, LinkLocation.Desktop });
                }

                if (_linkQuickRun)
                {
                    ShortcutEx.CreateQuickLaunchLink(MainForm._productName,
                                                    _path + "\\" + MainForm._baseAppName,
                                                    MainForm._description);
                    ProgressStep("Ярлык для панели быстрого запуска");
                    _params.links.Add(new object[] { MainForm._productName, LinkLocation.QuickLaunch });
                }

                if (_StartGroup)
                {
                    string bpath = ShortcutEx.CreateStartMenuGroup(MainForm._productName);
                    ShortcutEx.CreateLink(MainForm._productName,
                                          _path + "\\" + MainForm._baseAppName,
                                          MainForm._description,
                                          bpath);
                    ShortcutEx.CreateLink("Uninstall",
                                          _path + "\\Uninstaller.exe",
                                          MainForm._description,
                                          bpath);
                    ProgressStep("Группа в меню пуск");
                    _params.startGroups.Add(MainForm._productName);
                }
                else
                {
                    ShortcutEx.CreateDesktopLink("Uninstall " + MainForm._productName,
                                                 _path + "\\Uninstaller.exe",
                                                 MainForm._description);
                    ProgressStep("Ярлык деинсталлятора на рабочем столе");
                    _params.links.Add(new object[] { "Uninstall " + MainForm._productName, LinkLocation.Desktop });
                }
            }
            catch (Exception _E)
            {
                MessageBox.Show(_E.Message, @"CreateLinks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}