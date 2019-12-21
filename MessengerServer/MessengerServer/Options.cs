using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorsProcessingLib;
namespace MessengerServer
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }
        bool _debug = false;
        private void Options_Load(object sender, EventArgs e)
        {
#if DEBUG
            _debug = true;
#endif
            _ps = Parametres.Load();

            message_delay.Value     = _ps.MessageDelay;
            BW_Delay.Value          = _ps.BwDelay;
            BlackMulti.Value        = _ps.BlackMulti;
            GeneralMulti.Value      = _ps.GeneralMulti;
            
            chkAutoRun.Checked      = _ps.AutoStart;
            chkDebugForce.Checked   = _ps.ForceDebug;
            
            EnableApply(false);

            IsLoad = true;
        }

        bool IsLoad = false;
        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveParams();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (OptionsChanged)
            {
                SaveParams();
            }
            this.Close();
        }
        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void chkDebugForce_CheckedChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void message_delay_ValueChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void BW_Delay_ValueChanged(object sender, EventArgs e)
        {
            EnableApply(true);
        }
        private void BlackMulti_ValueChanged(object sender, EventArgs e)
        {
            BWVerify();
            EnableApply(true);
        }
        private void GeneralMulti_ValueChanged(object sender, EventArgs e)
        {
            BWVerify();
            EnableApply(true);
        }

        bool OptionsChanged = false;
        void EnableApply(bool enable)
        {
            OptionsChanged   = enable;
            btnApply.Enabled = enable;
        }
        void BWVerify()
        {
            if (!IsLoad) return;
            if (BWVerifyThread == null)
            {
                if (GeneralMulti.Value <= BlackMulti.Value)
                {
                    BWVerifyThread = new System.Threading.Thread(new System.Threading.ThreadStart(DoBWVerify));
                    BWVerifyThread.Start();
                }
            }
        }
        System.Threading.Thread BWVerifyThread = null;
        void DoBWVerify()
        {
            Report.Warning("If the 'General Multiply' will be less or equal than to the 'Black Multiply'\nINCORRECT WORK of server is fully possible");
        }
        bool WasSave = false;
        private Parametres _params = new Parametres();
        private ParamsStruct _ps;
        void SaveParams()
        {
            try
            {
                _ps.MessageDelay    = (int)message_delay.Value;
                _ps.BwDelay         = (int)BW_Delay.Value;
                _ps.BlackMulti      = (int)BlackMulti.Value;
                _ps.GeneralMulti    = (int)GeneralMulti.Value;
                _ps.ForceDebug      = chkDebugForce.Checked;
                _ps.AutoStart       = chkAutoRun.Checked;
                
                if (_ps.AutoStart)  { SetAutoStart(); }

                EnableApply(false);

                _params.Params = _ps;
                _params.Save();

                WasSave = true;
            }
            catch (Exception _E){
                ErrorsProc.WriteErrorAndMessage(_E, "SaveParams() in Options.cs", _debug);
            }
        }
        public static void  SetAutoStart()
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                                                    Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf('\\') + 1),
                                                    Application.ExecutablePath,
                                                    Microsoft.Win32.RegistryValueKind.String);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorAndMessage(_E, "SetAutoStart() in Options.cs", false);
            }
        }
        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WasSave)
            {
                MessageBox.Show(@"Changes will enter into force at the next start of server",@"Messenger Server",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

       

        

       

    }
}