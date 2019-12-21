using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MessengerServer.UserDataSetTableAdapters;
using ErrorsProcessingLib;
using TextOperations;
namespace MessengerServer
{
    public partial class BanRuleForm : Form
    {
        public BanRuleForm()
        {
            InitializeComponent();
        }
        int GetS()
        {
            try
            {
                return int.Parse(txtSeconds.Text);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "GetS in BanRuleForm.cs");
                return 0;
            }
        }
        int GetM()
        {
            try
            {
                return int.Parse(txtMinutes.Text);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "GetM in BanRuleForm.cs");
                return 0;
            }
        }
        int GetH()
        {
            try
            {
                return int.Parse(txtHours.Text);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "GetH in BanRuleForm.cs");
                return 0;
            }
        }
        int GetD()
        {
            try
            {
                return int.Parse(txtDays.Text);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "GetD in BanRuleForm.cs");
                return 0;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BanRulesAddNew();
        }
        void BanRulesUpdate()
        {
            if (BanRulesGrid.SelectedRows.Count < 1)
            {
                MessageBox.Show(@"Non selection for update", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!_Text.ConteinsNotSpaces(txtReason.Text))
            {
                MessageBox.Show(@"Reason field can not be empty", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = (int)BanRulesGrid.SelectedRows[0].Cells[0].Value;
            int s = GetS();
            int m = GetM();
            int h = GetH();
            int d = GetD();

            string timeView = "";

            timeView += d + " d";
            timeView += ":" + h + "h";
            timeView += ":" + m + "m";
            timeView += ":" + s + "s";

            int genTime = GetSeconds(s, m, h, d);

            int resonid = (int)BanRulesGrid.SelectedRows[0].Cells[1].Value;
            userDataSet.BanReasons.FindByid(resonid).Reason = txtReason.Text;
            banReasonsTableAdapter.Update(userDataSet.BanReasons);

            UserDataSet.BanRulesRow row =  userDataSet.BanRules.FindByid(id);
            row.GeneralTime = genTime;
            row.TimeView = timeView;
            row.Reason = resonid;

            banRulesTableAdapter.Update(userDataSet.BanRules);
        }
        void BanRulesAddNew()
        {
            try
            {
                if (!_Text.ConteinsNotSpaces(txtReason.Text))
                {
                    MessageBox.Show(@"Reason field can not be empty", @"Messenger Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int s = GetS();
                int m = GetM();
                int h = GetH();
                int d = GetD();

                string timeView = "";

                timeView += d + " d";
                timeView += ":" + h + "h";
                timeView += ":" + m + "m";
                timeView += ":" + s + "s";

                int genTime = GetSeconds(s, m, h, d);

                UserDataSet.BanReasonsRow resrow = userDataSet.BanReasons.AddBanReasonsRow(txtReason.Text);
                banReasonsTableAdapter.Update(userDataSet.BanReasons);

                userDataSet.BanRules.AddBanRulesRow(resrow, genTime, timeView);
                banRulesTableAdapter.Update(userDataSet.BanRules);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "btnAdd_Click in BanRuleForm.cs");
            }
        }
       
        private void BanRuleForm_Load(object sender, EventArgs e)
        { 
            try
            {
                this.banReasonsTableAdapter.Fill(this.userDataSet.BanReasons);
                this.banRulesTableAdapter.Fill(this.userDataSet.BanRules);
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "BanRuleForm_Load in BanRuleForm.cs");
            }

            load = true;
            UpdateReasonName();

        }
        bool load = false;
        private void BanRulesGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            banRulesTableAdapter.Update(this.userDataSet.BanRules);
        }
        private void BanRulesGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (BanRulesGrid.SelectedRows.Count != 0)
                {
                    int     sec     = (int)BanRulesGrid.SelectedRows[0].Cells[3].Value;
                    string  reason  = (string)BanRulesGrid.SelectedRows[0].Cells[2].Value;
                    double[] ss = SecondsSplit(sec);

                    txtSeconds.Text = ss[0].ToString();
                    txtMinutes.Text = ss[1].ToString();
                    txtHours.Text   = ss[2].ToString();
                    txtDays.Text    = ss[3].ToString();

                    txtReason.Text = reason;
                }
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "BanRulesGrid_SelectionChanged in BanRuleForm.cs");
            }
        }
        double[] SecondsSplit(int seconds)
        {
            double minutes = seconds / (double)60;
            double hours = minutes / 60;
            double days = hours / 24;

            double Seconds = 0;
            double Minutes = 0;
            double Hours = 0;
            double Days = 0;

            if (minutes >= 60)
            {
                Minutes = Math.Floor(minutes) - Math.Floor(hours) * 60;
            }
            else
            {
                Minutes = Math.Floor(minutes);
            }

            if (hours >= 24)
            {
                Hours = Math.Floor(hours) - Math.Floor(days) * 24;
            }
            else
            {
                Hours = Math.Floor(hours);
            }

            Days = Math.Floor(days);

            Seconds = Math.Round((minutes - Math.Floor(minutes)) * 60);

            return new double[] { Seconds, Minutes, Hours, Days };

        }

        int GetSeconds(int seconds, int minutes, int hours, int days)
        {
            int sec = 0;
            sec += days * 24 * 60 * 60;
            sec += hours * 60 * 60;
            sec += minutes * 60;
            sec += seconds;

            return sec;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BanRulesUpdate();
        }

        private void BanRulesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateReasonName();
        }
        void UpdateReasonName()
        {
            try
            {
                if (!load) return;

                foreach (DataGridViewRow row in BanRulesGrid.Rows)
                {
                    try
                    {
                        int id = (int)row.Cells[1].Value;
                        row.Cells[2].Value = userDataSet.BanReasons.FindByid(id).Reason;
                    }
                    catch{
                    }
                }

            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorToLog(_E, "UpdateReasonName in BanRuleForm.cs");
            }
        }

      

    }
}