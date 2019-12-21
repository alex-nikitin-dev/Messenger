using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using ErrorsProcessingLib;
using ParametresLib;
namespace Messenger_Client
{
    public partial class Options : Form
    {
        private readonly Parametres   _params = new Parametres();
        private ParamsStruct _ps;

        private bool _optionsChanged;
        private readonly Watch _watch;

        private readonly bool _debug;
        readonly bool _isNowConnected;

        public string Login        = "";
        public string Password     = "";

        public Options(Watch watch,bool isNowConnected)
        {
#if DEBUG
            _debug = true;
#endif
            _isNowConnected = isNowConnected;
            _watch          = watch;

            InitializeComponent();

            _ps = Parametres.Load();
        }
        private void Options_Load(object sender, EventArgs e)
        {
            if (!_isNowConnected)
            {
                gboxProfile.Enabled     = false;
                btnEditProfile.Enabled  = false;

                btnToBlack.Enabled      = false;
                btnToWite.Enabled       = false;

                lstBlack.Enabled        = false;
                lstWite.Enabled         = false;
            }
            
            Байда.Visible           = false;
            chkWatchForce.Visible   = false;

            Байда.Checked           = _ps.Bayda;
            Host.Text               = _ps.ServerIp;
            Port.Text               = _ps.Port.ToString();
            message_delay.Value     = _ps.SendDelay;
            chkWatchForce.Checked   = _ps.WatchForce;
            AutoRun.Checked         = _ps.AutoStart;
            MChatColorsLoad();

            EnableApply(false);
        }
        void MChatColorsLoad()
        {
            MChatOwnForeColor.BackColor     = _ps.MChatOwnForeColor;
            MChatOwnBackColor.BackColor     = _ps.MChatOwnBackColor;

            MChatUserForeColor.BackColor    = _ps.MChatUserForeColor;
            MChatUserBackColor.BackColor    = _ps.MChatUserBackColor;

            MChatUListForeColor.BackColor   = _ps.MChatUListForeColor;
            MChatUListBackColor.BackColor   = _ps.MChatUListBackColor;

            MessageTextForeColor.BackColor  = _ps.MessageTextForeColor;
            MessageTextBackColor.BackColor  = _ps.MessageTextBackColor;

            TimeForeColor.BackColor         = _ps.TimeForeColor;
            TimeBackColor.BackColor         = _ps.TimeBackColor;

            MChatBackColor.BackColor        = _ps.MChatBackColor;
        }
        // ReSharper disable once InconsistentNaming
        public void WBSinchronize()
        {
            try
            {
                WhiteVirtual.Clear();
                BlackVirtual.Clear();

                WhiteVirtual.AddRange(lstWite.Items);
                BlackVirtual.AddRange(lstBlack.Items);
            }
            catch(Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "WBSinchronize() in Options.cs", _debug);
            }
        }
        private void Host_TextChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void Port_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //short.Parse(Port.Text);
                EnableApply(true);
            }
            catch{
                MessageBox.Show(@"Недопустимое значение");
                Port.Text = _ps.Port.ToString();
            }
        }
        void EnableApply(bool enable)
        {
            _optionsChanged   = enable;
            btnApply.Enabled = enable;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_optionsChanged)
            {
                SaveParams();
                UpdateWB();
            }
            Close();
        }
        void SaveParams()
        {
            try
            {
                try{
                    IPAddress.Parse(Host.Text);
                    _ps.ServerIp = Host.Text;
                }
                catch{
                    MessageBox.Show(@"Недопустимое значение в поле IP адреса");
                    Host.Text = _ps.ServerIp;
                    return;
                }
                _ps.Port                    = int.Parse(Port.Text);
                _ps.Bayda                   = Байда.Checked;
                _ps.SendDelay               = (int)message_delay.Value;
                _ps.WatchForce              = chkWatchForce.Checked;

                _ps.MChatOwnForeColor       = MChatOwnForeColor.BackColor;
                _ps.MChatOwnBackColor       = MChatOwnBackColor.BackColor;

                _ps.MChatUserForeColor      = MChatUserForeColor.BackColor;
                _ps.MChatUserBackColor      = MChatUserBackColor.BackColor;

                _ps.MChatUListForeColor     = MChatUListForeColor.BackColor;
                _ps.MChatUListBackColor     = MChatUListBackColor.BackColor;

                _ps.MessageTextForeColor    = MessageTextForeColor.BackColor;
                _ps.MessageTextBackColor    = MessageTextBackColor.BackColor;

                _ps.TimeForeColor           = TimeForeColor.BackColor;
                _ps.TimeBackColor           = TimeBackColor.BackColor;

                _ps.MChatBackColor          = MChatBackColor.BackColor;

                _ps.AutoStart               = AutoRun.Checked;
                if (_ps.AutoStart)
                {
                    SetAutoStart();
                }
                else
                {
                    DelAutoStart();
                }
                _params.Params = _ps;
                _params.Save();

                _wasSave = true;
            }
            catch (Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "SaveParams() in Options.cs", _debug);
            }
        }
        public static void SetAutoStart()
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", 
                                                    Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf('\\') + 1),
                                                    Application.ExecutablePath, 
                                                    Microsoft.Win32.RegistryValueKind.String);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "SetAutoStart() in Options.cs", false);
            }
        }
        void DelAutoStart()
        {
            try
            {
                Microsoft.Win32.RegistryKey rk =  Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);
                Debug.Assert(rk != null, nameof(rk) + " != null");
                rk.DeleteValue(Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf('\\') + 1));
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "DelAutoStart() in Options.cs", false);
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_optionsChanged)
            {
                SaveParams();
                UpdateWB();
            }

            EnableApply(false);
        }
        ArrayList WhiteVirtual = new ArrayList();
        ArrayList BlackVirtual = new ArrayList();

        ArrayList ToWhiteArr = new ArrayList();
        ArrayList ToBlackArr = new ArrayList();

        void ToArrClear()
        {
            ToWhiteArr.Clear();
            ToBlackArr.Clear();
        }
        // ReSharper disable once InconsistentNaming
        private void UpdateWB()
        {
            try
            {
                // заглушка 
                if (!_isNowConnected) return;

                ToArrClear();
                bool w = false;
                bool b = false;

              
                foreach (object item in WhiteVirtual)
                {
                    if (!lstWite.Items.Contains(item))
                    {
                        ToBlackArr.Add(item);
                        b = true;
                    }
                }
                if (b)
                {
                    Debug.Assert(BlackListReadyEvent != null, nameof(BlackListReadyEvent) + " != null");
                    BlackListReadyEvent(ToBlackArr);
                }

                foreach (object item in BlackVirtual)
                {
                    if (!lstBlack.Items.Contains(item))
                    {
                        ToWhiteArr.Add(item);
                        w = true;
                    }
                }

                if (w)
                {
                    Debug.Assert(WhiteListReadyEvent != null, nameof(WhiteListReadyEvent) + " != null");
                    WhiteListReadyEvent(ToWhiteArr);
                }
               


            }
            catch (Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "UpdateWB() in Options.cs", _debug);
            }
            finally{
                WBSinchronize();
            }
        }
        private void Options_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Home)
            {
                Байда.Visible           = true;
                chkWatchForce.Visible   = true;
                btnShowWatch.Visible    = true;
            }
        }
        private void Байда_CheckedChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void chkWatchForce_CheckedChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }

        RegistrationForm _regForm;
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (!_isNowConnected) { return; }
            try
            {
                btnEditProfile.Enabled      = false;
                _cancelClose                 = true;

                _regForm                    = new RegistrationForm(_watch);
                _regForm.IsEdit              = true;
                _regForm.StartPosition      = FormStartPosition.CenterScreen;
                _regForm.Login             = Login;
                _regForm.Password          = Password;
                _regForm.btnSend.Text          = @"Отправить";
                _regForm.btnSendFirst.Text  = @"Получить профиль";

                _regForm.Show();
                _regForm.FormClosed += OnRegFormClosed;
            }
            catch (Exception exception)
            {
                ErrorsProc.WriteErrorAndMessage(exception, "btnEditProfile_Click in Options.cs", _debug);
                btnEditProfile.Enabled = true;
            }
        }
        bool _cancelClose;
        void OnRegFormClosed(object sender,FormClosedEventArgs e)
        {
            btnEditProfile.Enabled  = true;
            _cancelClose             = false;
        }
        
        private void btnToWite_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.AddRange(lstBlack.SelectedItems);

            foreach (object item in arr)
	        {
                if (!lstWite.Items.Contains(item))
                {
                    lstWite.Items.Add(item);
                    EnableApply(true);
                }

                lstBlack.Items.Remove(item);
	        }
        }
        public delegate void BlackListReadyHandler(ArrayList blackList);
        /// <summary>
        /// белый список изменён и данные для чёрного списка готовы к отправке
        /// </summary>
        public event BlackListReadyHandler BlackListReadyEvent;


        public delegate void WhiteListReadyHandler(ArrayList whiteList);
        /// <summary>
        /// чёрный список изменён и данные для белого списка готовы к отправке
        /// </summary>
        public event WhiteListReadyHandler WhiteListReadyEvent;

        private void btnToBlack_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.AddRange(lstWite.SelectedItems);

            foreach (object item in arr)
            {
                if (!lstBlack.Items.Contains(item))
                {
                    lstBlack.Items.Add(item);
                    EnableApply(true);
                }
                lstWite.Items.Remove(item);
            }
        }

        private void message_delay_ValueChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        bool _wasSave;
        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_wasSave && !_debug)
            {
                MessageBox.Show(@"Некоторые настройки вступят в силу после перезапуска Мессенжера", @"Messenger", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancelClose;
            if (_cancelClose)
            {
                Report.Warning("Чтобы закрыть окно параметров, необходимо закрыть окно редактора профиля");
            }
        }

        private void MChatOwnForeColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatOwnForeColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatOwnForeColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatOwnBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatOwnBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatOwnBackColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatUserForeColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatUserForeColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatUserForeColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatUserBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatUserBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatUserBackColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatUListForeColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatUListForeColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatUListForeColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatUListBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatUListBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatUListBackColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MChatBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MChatBackColor.BackColor = DlgColor.Color;
            }
        }

        private void MessageTextForeColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MessageTextForeColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MessageTextForeColor.BackColor = DlgColor.Color;
            }
        }

        private void MessageTextBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = MessageTextBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                MessageTextBackColor.BackColor = DlgColor.Color;
            }
        }

        private void TimeForeColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = TimeForeColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                TimeForeColor.BackColor = DlgColor.Color;
            }
        }

        private void TimeBackColor_Click(object sender, EventArgs e)
        {
            DlgColor.Color = TimeBackColor.BackColor;
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                EnableApply(true);
                TimeBackColor.BackColor = DlgColor.Color;
            }
        }

        private void MChatColorReset_Click(object sender, EventArgs e)
        {
            MChatDefaultColorsSave();
            _ps = Parametres.Load();
            MChatColorsLoad();
        }

        void MChatDefaultColorsSave()
        {
            ParamsStruct ps = Parametres.Load();
            ParamsStruct def = Parametres.GetDefault();

            ps.MChatOwnForeColor = def.MChatOwnForeColor;
            ps.MChatOwnBackColor = def.MChatOwnBackColor;

            ps.MChatUserForeColor = def.MChatUserForeColor;
            ps.MChatUserBackColor = def.MChatUserBackColor;

            ps.MChatUListForeColor = def.MChatUListForeColor;
            ps.MChatUListBackColor = def.MChatUListBackColor;

            ps.MessageTextForeColor = def.MessageTextForeColor;
            ps.MessageTextBackColor = def.MessageTextBackColor;

            ps.TimeForeColor = def.TimeForeColor;
            ps.TimeBackColor = def.TimeBackColor;

            ps.MChatBackColor = def.MChatBackColor;

            Parametres pr = new Parametres {Params = ps};
            pr.Save();
        }

       
    }
   
}