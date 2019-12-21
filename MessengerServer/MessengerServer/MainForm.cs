using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ErrorsProcessingLib;
using MessengerServer.UserDataSetTableAdapters;
using MessengerServer.UsersDataSetTableAdapters;
using ServerExceptionLib;
using ServerInterfaceLib;
using TextOperations;
using AccountTableAdapter = MessengerServer.UserDataSetTableAdapters.AccountTableAdapter;
using BanReasonsTableAdapter = MessengerServer.UserDataSetTableAdapters.BanReasonsTableAdapter;
using CCMessages = ClientConnectionLib.ClientConnection.Messages;
using State = ClientConnectionLib.MessageHelper.State;

namespace MessengerServer
{
    public partial class MainForm : Form
    {
        #region Нажатия клавиш

        #region Окно ввода текста

        private void MessageText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                e.Handled = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                //
                // server message
                //
                SendMessageText();
            }
        }

        #endregion

        #endregion

        private void ChatContext_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            CC_NIK.Visible = false;
            CC_SEP.Visible = false;
            CC_NikToChat.Visible = false;
        }

        private void CC_NikToChat_Click(object sender, EventArgs e)
        {
            MessageText.AppendText(CC_NIK.Text + ":");
        }

        private void CC_Clear_Click(object sender, EventArgs e)
        {
            Chat.Clear();
        }

        private void CC_Expand_Click(object sender, EventArgs e)
        {
            CC_Expand.Text = ChatUsrLstContainer.Panel2Collapsed ? @"Спрятать список пользователей" : @"Показать список пользователей";
            ChatUsrLstContainer.Panel2Collapsed = !ChatUsrLstContainer.Panel2Collapsed;
        }

        private void CC_AutoScroll_Click(object sender, EventArgs e)
        {
            CC_AutoScroll.Checked = !CC_AutoScroll.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void Ban_Delete_Click(object sender, EventArgs e)
        {
            if (BanView.SelectedItems.Count != 0)
            {
                var id = (int) BanView.SelectedItems[0].Tag;
                var row = _accountTable.FindById(id);
                row.Banned = false;

                BanView.SelectedItems[0].Remove();
                _accountAdapter.Update(_accountTable);

                try
                {
                    if (_bannedIp.Contains(row.IP)) _bannedIp.Remove(row.IP);
                }
                catch (Exception)
                {
                    if (_debug) throw;
                }

                BanViewUpdate();
            }
        }

        private void BanViewUpdate()
        {
            try
            {
                BanView.Items.Clear();

                foreach (var row in _accountTable)
                    if (row.Banned)
                    {
                        var li = BanView.Items.Add(row.Login);
                        li.Tag = row.Id;
                        var dt = $"{row.BanTimespan:dd.MM.yyyy HH:mm:ss}";
                        li.SubItems.Add(dt).Tag = row.BanTimespan;

                        var sip = row.BanByIp.ToString();
                        if (row.BanByIp) sip += "(" + row.IP + ")";
                        li.SubItems.Add(sip).Tag = row.BanByIp;

                        var bta = new BanReasonsTableAdapter();
                        var brt = new UserDataSet.BanReasonsDataTable();
                        bta.Fill(brt);

                        li.SubItems.Add(brt.FindByid(row.BanReason).Reason);
                    }
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "BanViewUpdate");
            }
        }

        private void Ban_Set_ByIP_Click(object sender, EventArgs e)
        {
            if (BanView.SelectedItems.Count != 0)
            {
                var id = (int) BanView.SelectedItems[0].Tag;
                var byIp = _accountTable.FindById(id).BanByIp;
                var row = _accountTable.FindById(id);
                row.BanByIp = !byIp;
                _accountAdapter.Update(_accountTable);

                var br = new UserDataSet.BanReasonsDataTable();
                var ba = new BanReasonsTableAdapter();
                ba.Fill(br);
                var reason = br.FindByid(row.BanReason).Reason;

                try
                {
                    if (row.BanByIp)
                    {
                        if (_bannedIp.Contains(row.IP)) _bannedIp.Remove(row.IP);
                        var data = new ArrayList {reason, row.BanTimespan, row.Id};

                        _bannedIp.Add(row.IP, data);

                        reason += "(Banned by IP)";
                    }
                    else
                    {
                        _bannedIp.Remove(row.IP);
                    }
                }
                catch(Exception)
                {
                    if (_debug) throw;
                }

                if (_mainChatUsers.Contains(row.Login))
                {
                    var sDt = $"{row.BanTimespan:dd.MM.yyyy HH:mm:ss}";
                    var user = (UserConnection) _mainChatUsers[row.Login];

                    user.SendMessage(MessageHelper.Messages.MchatBan, reason, sDt);
                    user.IsMChatActive = false;

                    _mainChatUsers.Remove(row.Login);
                    MChatItemRemove(row.Login);
                }

                BanViewUpdate();
            }
        }

        private void Ban_AddUser_Click(object sender, EventArgs e)
        {
            var bf = new BanForm();
            bf.ShowDialog();

            AccountBanUpdate(bf.out_login_id);
            BanViewUpdate();
        }

        private void Ban_Edit_Click(object sender, EventArgs e)
        {
            if (BanView.SelectedItems.Count != 0)
            {
                var login = BanView.SelectedItems[0].Text;
                var ed = (DateTime) BanView.SelectedItems[0].SubItems[1].Tag;
                var byip = (bool) BanView.SelectedItems[0].SubItems[2].Tag;
                var reason = BanView.SelectedItems[0].SubItems[3].Text;

                var bf = new BanForm(login, ed, byip, reason, true);
                bf.ShowDialog();

                AccountBanUpdate(bf.out_login_id);
                BanViewUpdate();
            }
        }

        private void MCLC_Ban_Click(object sender, EventArgs e)
        {
            if (MChatUserView.SelectedItems.Count != 0)
            {
                var login = MChatUserView.SelectedItems[0].Text;
                var bf = new BanForm(login);
                bf.ShowDialog();

                AccountBanUpdate(bf.out_login_id);
                BanViewUpdate();
            }
        }

        /// <summary>
        ///     обновление записи
        /// </summary>
        private void AccountBanUpdate(int login)
        {
            try
            {
                if (login < 0) return;
                var row = _accountAdapter.GetData().FindById(login);
                var old = _accountTable.FindById(login);

                old.BanByIp = row.BanByIp;
                old.BanReason = row.BanReason;
                old.BanTimespan = row.BanTimespan;
                old.Banned = row.Banned;

                old.AcceptChanges();

                var br = new UserDataSet.BanReasonsDataTable();
                var ba = new BanReasonsTableAdapter();
                ba.Fill(br);
                var reason = br.FindByid(row.BanReason).Reason;

                try
                {
                    if (row.BanByIp)
                    {
                        if (_bannedIp.Contains(row.IP)) _bannedIp.Remove(row.IP);
                        var data = new ArrayList {reason, row.BanTimespan, row.Id};

                        _bannedIp.Add(row.IP, data);

                        reason += "(Ban by IP)";
                    }
                    else
                    {
                        _bannedIp.Remove(row.IP);
                    }
                }
                catch(Exception)
                {
                    if (_debug) throw;
                }

                if (_mainChatUsers.Contains(row.Login))
                {
                    var sDt = $"{row.BanTimespan:dd.MM.yyyy HH:mm:ss}";
                    var user = (UserConnection) _mainChatUsers[row.Login];

                    user.SendMessage(MessageHelper.Messages.MchatBan, reason, sDt);
                    user.IsMChatActive = false;

                    _mainChatUsers.Remove(row.Login);
                    MChatItemRemove(row.Login);
                }
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "AccountBanUpdate");
            }
        }

        private void BanContext_Opening(object sender, CancelEventArgs e)
        {
            if (BanView.SelectedItems.Count == 0)
            {
                Ban_Delete.Enabled = false;
                Ban_Edit.Enabled = false;
                Ban_Set_ByIP.Enabled = false;
            }
            else
            {
                Ban_Delete.Enabled = true;
                Ban_Edit.Enabled = true;
                Ban_Set_ByIP.Enabled = true;

                Ban_Set_ByIP.Checked = (bool) BanView.SelectedItems[0].SubItems[2].Tag;
            }
        }

        private void MChatListContext_Opening(object sender, CancelEventArgs e)
        {
            if (MChatUserView.SelectedItems.Count == 0)
                MCLC_Ban.Visible = false;
            else
                MCLC_Ban.Visible = true;
        }

        private void UserListTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserListTab.SelectedIndex == 3) BanViewUpdate();
        }

        private void ALC_DetachUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (AttachedUsersView.SelectedItems.Count != 0)
                {
                    var login = AttachedUsersView.SelectedItems[0].Text;
                    (_attachedUsers[login] as UserConnection)?.ShutDown();
                }
            }
            catch (Exception exception)
            {
                if (_debug) throw;
                ReportAnErrorEx(exception, "ALC_DetachUser_Click");
            }
        }

        private void AttachedListContext_Opening(object sender, CancelEventArgs e)
        {
            if (AttachedUsersView.SelectedItems.Count == 0)
                ALC_DetachUser.Enabled = false;
            else
                ALC_DetachUser.Enabled = true;
        }

        private void Ban_HideMessageWindow_Click(object sender, EventArgs e)
        {
            CxtExpandRigthPanel(sender);
        }

        #region Свойства и конструкторы

        private bool _debug;
        private bool _cancelClose = true;
        private readonly int UserData_RowCount = 6;
        private ParamsStruct _params;

        private readonly Hashtable _mainChatUsers = new Hashtable();
        private readonly Hashtable _attachedUsers = new Hashtable();

        private readonly UserDataSet.AccountDataTable _accountTable = new UserDataSet.AccountDataTable();
        private readonly AccountTableAdapter _accountAdapter = new AccountTableAdapter();

        private readonly WhiteTableAdapter _whiteAdapter = new WhiteTableAdapter();
        private readonly UserDataSet.WhiteDataTable _whiteTable = new UserDataSet.WhiteDataTable();

        private readonly BlackTableAdapter _blackAdapter = new BlackTableAdapter();
        private readonly UserDataSet.BlackDataTable _blackTable = new UserDataSet.BlackDataTable();

      

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            _debug = true;
#endif
        }

        #endregion

        #region События

        #region События трея

        private void TrayExit_Click(object sender, EventArgs e)
        {
            CorrectExit();
        }

        private void TrayShowWindow_Click(object sender, EventArgs e)
        {
            SwitchHideShow();
        }

        private void TrayIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SwitchHideShow();
        }

        private void TrayIco_Click(object sender, EventArgs e)
        {
            TopMost = true;
            TopMost = false;
        }

        #endregion

        #region События Главной Формы

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _params = Parametres.Load();

                if (_params.AutoStart) Options.SetAutoStart();
                if (_params.ForceDebug)
                    if (!_debug)
                        SwitchDebug();

                StartListener();

                if (_debug) Text = @"Messenger Server [DEBUG]";

                FillUserDataSet();

                BindUserDataset();
            }
            catch (Exception exception)
            {
                ReportAnError(exception, "MainForm_Load");
            }
        }

        private void MainExit_Click(object sender, EventArgs e)
        {
            CorrectExit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancelClose;
            if (_cancelClose)
                HideThis();
            else
                BaseFlush();
        }

        private void FillUserDataSet()
        {
            try
            {
                _accountAdapter.Fill(_accountTable);
                _whiteAdapter.Fill(_whiteTable);
                _blackAdapter.Fill(_blackTable);


                foreach (var row in _accountTable)
                    try
                    {
                        if (row.BanByIp && row.Banned)
                        {
                            var br = new UserDataSet.BanReasonsDataTable();
                            var ba = new BanReasonsTableAdapter();
                            ba.Fill(br);
                            var reason = br.FindByid(row.BanReason).Reason;

                            var data = new ArrayList {reason, row.BanTimespan, row.Id};

                            _bannedIp.Add(row.IP, data);
                        }
                    }
                    catch (Exception)
                    {
                        if (_debug) throw;
                    }
            }
            catch (Exception e)
            {
                ReportAnError(e, "FillUserDataSet");
            }
        }

        private void BindUserDataset()
        {
            AccountGrid.DataSource = _accountTable;
            WhiteGrid.DataSource = _whiteTable;
            BlackGrid.DataSource = _blackTable;
            AlertGrid.DataSource = _alertSystem.Table;
        }

        private void Info_DoubleClick(object sender, EventArgs e)
        {
            ReportNoProblem();
        }

        private void MM_SwitchDebug_Click(object sender, EventArgs e)
        {
            SwitchDebug();
        }

        private void SwitchDebug()
        {
            try
            {
                if (_debug)
                {
                    _debug = false;
                    MM_SwitchDebug.Checked = false;
                    _alertSystem.Debug = false;
                    Text = @"Messenger Server";
                }
                else
                {
                    _debug = true;
                    _alertSystem.Debug = true;
                    MM_SwitchDebug.Checked = true;
                    Text = @"Messenger Server [DEBUG]";
                }
            }
            catch (Exception){if (_debug) throw;}
        }

        private void MM_Options_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                if (_debug)
                    MM_SwitchDebug.Checked = true;
                else
                    MM_SwitchDebug.Checked = false;
            }
            catch (Exception){if (_debug) throw;}
            
        }

        private void MM_Params_Click(object sender, EventArgs e)
        {
            OptionsShow();
        }

        private bool _optionsIsRun;
        private Options _optionsForm;

        private void OptionsShow()
        {
            try
            {
                if (!_optionsIsRun)
                {
                    _optionsForm = new Options();
                    _optionsForm.FormClosed += optionsForm_FormClosed;
                    _optionsForm.Show();
                    _optionsIsRun = true;
                }
                else
                {
                    _optionsForm.TopMost = true;
                    _optionsForm.TopMost = false;
                }
            }
            catch (Exception e)
            {
                ReportAnError(e, "OptionsShow");
            }
        }

        private void optionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _optionsIsRun = false;
        }

        #endregion

        #endregion

        #region Операции над формой

        private void HideThis()
        {
            Visible = false;

            TrayShowWindow.Text = @"Show Window";
        }

        private void ShowThis()
        {
            Visible = true;

            TrayShowWindow.Text = @"Hide Window";
        }

        private void SwitchHideShow()
        {
            if (Visible == false)
                ShowThis();
            else
                HideThis();
        }

        private void CorrectExit()
        {
            var res = MessageBox.Show(@"Вы уверены что хотите остановить сервер сообщений?",
                @"Диалог выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                SendMessageAllAttached(MessageHelper.Messages.Disconnect, "");

                _cancelClose = false;

                if (_listener != null)
                {
                    _listener.Stop();
                    _listenerThread?.Abort();
                }

                _clients.Clear();

                Application.Exit();
            }
        }

        private void ALC_RightPanelExpand_Click(object sender, EventArgs e)
        {
            CxtExpandRigthPanel(sender);
        }

        private void MCLC_RightPanelExpand_Click(object sender, EventArgs e)
        {
            CxtExpandRigthPanel(sender);
        }

        private void CxtExpandBaseVew_Click(object sender, EventArgs e)
        {
            CxtExpandRigthPanel(sender);
        }

        private void CxtExpandRigthPanel(object sender)
        {
            try
            {
                var itm = (ToolStripMenuItem) sender;
                if (!MainSplit.Panel2Collapsed)
                {
                    MainSplit.Panel2Collapsed = true;
                    ChatUsrLstContainer.Panel1Collapsed = true;

                    itm.Text = @"Show Message Window";
                }
                else
                {
                    MainSplit.Panel2Collapsed = false;
                    ChatUsrLstContainer.Panel1Collapsed = false;

                    itm.Text = @"Hide Message Window";
                }
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "CxtExpandRigthPanel");
            }
        }

        private void AccountGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "Password") e.Column.Visible = false;
        }

        #region Печать текста в чате

        public bool ChatAddOwnerMessage(string message)
        {
            return ChatAddString("Server", message, Color.White, Color.Blue);
        }

        //public bool ChatPrintRed(string message)
        //{
        //    return ChatAddString(message, Color.Red);
        //}

        //public bool ChatPrintGreen(string message)
        //{
        //    return ChatAddString(message, Color.GreenYellow);
        //}

        public bool ChatPrintGray(string message)
        {
            return ChatAddString(message, Color.Gray);
        }

        public bool ChatPrintYellow(string message)
        {
            return ChatAddString(message, Color.Yellow);
        }

        public bool ChatAddString(string message)
        {
            Color color = Color.Black;
            if (!_Text.ConteinsNotSpaces(message)) return false;

            if (!_Text.IsEmpty(Chat.Text)) Chat.AppendText("\n");


            var time = "[" + DateTime.Now.ToLongTimeString() + "] ";
            Chat.AppendText(time);

            Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);
            Chat.SelectionColor = color;
            Chat.DeselectAll();

            Chat.AppendText(_Text.Normalize(message));
            if (CC_AutoScroll.Checked) Chat.ScrollToCaret();
            return true;
           
        }

        public bool ChatAddString(string message, Color foreColor, Color backColor)
        {
            foreColor = Color.Black;
            backColor = Color.White;
            Color timeColor = Color.Black;
            if (InvokeRequired)
                return (bool) Invoke(new Func<bool>(() => ChatAddString(message, foreColor, backColor)));
           
                if (!_Text.ConteinsNotSpaces(message)) return false;

                if (!_Text.IsEmpty(Chat.Text)) Chat.AppendText("\n");

                var time = "[" + DateTime.Now.ToLongTimeString() + "] ";
                Chat.AppendText(time);
                Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);

                Chat.SelectionColor = timeColor;
                Chat.DeselectAll();

                var apndtxt = _Text.Normalize(message);
                Chat.AppendText(apndtxt);

                Chat.Select(Chat.Text.Length - apndtxt.Length, apndtxt.Length);
                Chat.SelectionBackColor = backColor;
                Chat.SelectionColor = foreColor;
                Chat.DeselectAll();
                if (CC_AutoScroll.Checked) Chat.ScrollToCaret();
                return true;
           
        }

        public bool ChatAddString(string user, string message, Color foreColor, Color backColor)
        {

            foreColor = Color.Black;
            backColor = Color.White;
            Color timeColor = Color.Black;
            if (!_Text.ConteinsNotSpaces(message)) return false;

                if (!_Text.IsEmpty(Chat.Text)) Chat.AppendText("\n");
                message = "<" + user + ">" + message;
                var time = "[" + DateTime.Now.ToLongTimeString() + "] ";
                Chat.AppendText(time);
                Chat.Select(Chat.Text.Length - time.Length, time.Length - 1);

                Chat.SelectionColor = timeColor;
                Chat.DeselectAll();

                var textToAppend = _Text.Normalize(message);
                Chat.AppendText(textToAppend);

                Chat.Select(Chat.Text.Length - textToAppend.Length, textToAppend.Length);
                Chat.SelectionBackColor = backColor;
                Chat.SelectionColor = foreColor;
                Chat.DeselectAll();
                if (CC_AutoScroll.Checked) Chat.ScrollToCaret();
                return true;
           
        }

        public bool ChatAddString(string message, Color foreColor)
        {
            return ChatAddString(message, foreColor, Chat.BackColor);
        }

        /// <summary>
        ///     дебажная
        /// </summary>
        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool ChatAddInformation(string information)
        {
            if (_debug) return ChatAddString(information, Color.White);
            return false;
        }

        /// <summary>
        ///     дебажная
        /// </summary>
        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool ChatAddWarning(string warning)
        {
            if (_debug) return ChatPrintYellow(warning);
            return false;
        }

        /// <summary>
        ///     дебажная
        /// </summary>
        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool ChatAddError(string error)
        {
            if (_debug) return ChatAddString(error, Color.Red, Color.Yellow);
            return false;
        }

        /// <summary>
        ///     дебажная
        /// </summary>
        private bool ChatAddComment(string comment)
        {
            if (InvokeRequired) return (bool) Invoke(new Func<bool>(() => ChatAddComment(comment)));
            return _debug && ChatPrintGray(comment);
        }

        /// <summary>
        ///     дебажная
        /// </summary>
        private bool ChatAddComment(UserConnection sender, string comment)
        {
            if (InvokeRequired) return (bool) Invoke(new Func<bool>(() => ChatAddComment(sender, comment)));
            if (!_debug) return false;
            return sender.Name != "" ? ChatPrintGray(sender.Name + ":" + comment) : ChatPrintGray("&_Anonymous" + ":" + comment);
        }

        #endregion

        #endregion

        #region Сетевое взаимодействие

        private Thread _listenerThread;
        private TcpListener _listener;
        private const int Port = 1100;

        private void StartListener()
        {
            _listenerThread = new Thread(DoListen);
            _listenerThread.Start();

            ChatAddComment("listener is started");
        }

        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<UserConnection> _clients = new List<UserConnection>();

        private void DoListen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, Port);
                _listener.Start();
                do
                {
                    try
                    {
                        var client = new UserConnection(_listener.AcceptTcpClient());

                        client.Receive += OnClientReceive;
                        client.DisconnectEvent += OnDisconnectUser;
                        client.SendMessageEvent += OnUserMessageSend;
                        client.ReplaceUserIpEvent += OnUserReplaceIp;
                        _clients.Add(client);
                        ChatAddComment("Принято новое соединение");
                    }
                    catch (ServerException e)
                    {
                        ReportAnError(e, "DoListen");
                        ReportAnError();
                    }
                } while (true);
            }
            catch (Exception e)
            {
                if (!_cancelClose && e.Message.IndexOf("Thread was being aborted", StringComparison.Ordinal) != -1) return;

                ReportAnError(e, "DoListen");

#if DEBUG
                MessageBox.Show(@"Вышел из цикла в методе DoListen  class MainForm in MainForm.cs");
#else
                //Alarm.Sound(Alarm.LevelError.Fatal);
#endif
            }
        }

        private void OnUserReplaceIp(UserConnection sender, string oldIp, string newIp)
        {
            try
            {
                _accountTable.FindById(sender.Id).IP = newIp;
                _accountTable.AcceptChanges();
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "OnUserReplaceIP");
            }
        }

        private void OnUserMessageSend(UserConnection user, string message)
        {
            try
            {
                if (_debug) ChatAddString(">>> юзеру " + user.Name + " было отправлено: " + message, Color.LightGreen);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool AuthorizeUser(string userName, string password, UserConnection sender)
        {
            try
            {
                var id = FindUserId(userName);
                if (id == -1)
                {
                    sender.SendMessage(MessageHelper.Messages.AutorizeFailedNotRegistered);
                    return false;
                }

                if (id == -2)
                {
                    sender.SendMessage(MessageHelper.Messages.AutorizeFailedServerError);
                    return false;
                }

                userName = _accountTable.FindById(id).Login;

                if (string.Compare(GetPasswordById(id), password, StringComparison.Ordinal) == 0)
                {
                    AttachUser(userName, sender);
                    return true;
                }

                sender.SendMessage(MessageHelper.Messages.AutorizeFailedWrongPassword);

                return false;
            }
            catch (Exception e)
            {
                ReportAnError(e, "AuthorizeUser");
                return false;
            }
        }

        private string GetPasswordById(int id)
        {
            return _accountTable.FindById(id).Password;
        }

        private string AttachedUsers_Contains(object key)
        {
#if !DEBUG
           try
           {
#endif
            var name = ((string) key).ToLower();
            foreach (var item in _attachedUsers.Keys)
                if (String.Compare(((string) item).ToLower(), name, StringComparison.Ordinal) == 0)
                    return item.ToString();

            return "";
#if !DEBUG
           }
           catch{
           return "";
           }
#endif
        }

        private void AttachUser(string userName, UserConnection sender)
        {
            try
            {
                if (AttachedUsers_Contains(userName) != "")
                {
                    sender.SendMessage(MessageHelper.Messages.WasAttached);
                }
                else
                {
                    sender.Name = userName;
                    sender.IsAttached = true;
                    sender.FillData();

                    ChatAddComment(userName + ":  is now attached");


                    _attachedUsers.Add(userName, sender);
                    AttachedUsersView.Items.Add(userName).SubItems.AddRange(new[]
                        {sender.Email, sender.Ip.ToString(), sender.Description});

                    sender.SendMessage(MessageHelper.Messages.Attached);

                    Send_BW_State(sender, _params.BwDelay);

                    var guests = _alertSystem.Guests(sender.Id);

                    SendAlerts(sender, guests);

                    SayToAllUsers(sender); // типа AllertAllUsers :)
                }
            }
            catch (Exception e)
            {
                ReportAnError(e, "AttachUser");
            }
        }

        private void SendAlerts(UserConnection sender, int[] logins)
        {
            var arr = new ArrayList();
            foreach (var id in logins)
            {
                arr.Add(_accountTable.FindById(id).Login);
                _alertSystem.Release(sender.Id, id);
            }

            if (arr.Count != 0)
                sender.SendMessage(MessageHelper.Messages.Alert, (string[]) arr.ToArray(typeof(string)));
        }

        private void SayToAllUsers(UserConnection sender)
        {
#if !DEBUG
            try
            {
#endif
            foreach (var row in _whiteTable)
                if (sender.Id == row.Friend)
                {
                    var name = _accountTable.FindById(row.Login).Login;
#if DEBUG
                    ChatAddComment("юзер нашёл себя добавленным в друзья к " + name);
#endif
                    var strong = AttachedUsers_Contains(name);
                    if (strong != "")
                        if (!sender.Black.Contains(strong))
                            Send_BW_State((UserConnection) _attachedUsers[strong], _params.BwDelay);
                }
#if !DEBUG
            }
            catch{
            }
#endif
        }

        /// <summary>
        ///     Key - string IP
        ///     Value - ArrayList : [0] - reason(string) [1] - endDate(DateTime)
        ///     [2] - int AccountId
        /// </summary>
        private readonly Hashtable _bannedIp = new Hashtable();

        private void AttachToMainChat(UserConnection sender)
        {
            try
            {
                if (!sender.IsAttached) return;
                if (sender.IsMChatActive)
                {
                    sender.SendMessage(MessageHelper.Messages.WasRegister);
                }
                else
                {
                    var row = _accountTable.FindById(sender.Id);

                    #region BAN BY IP VERIFY

                    try
                    {
                        foreach (DictionaryEntry entry in _bannedIp)
                        {
                            var sIp = (string) entry.Key;
                            if (String.Compare(row.IP, sIp, StringComparison.Ordinal) == 0)
                            {
                                var comm = (ArrayList) entry.Value;
                                var reason = (string) comm[0];
                                var dt = (DateTime) comm[1];
                                var id = (int) comm[2];

                                if (dt >= DateTime.Now)
                                {
                                    var sDt = $"{dt:dd.MM.yyyy HH:mm:ss}";
                                    sender.SendMessage(MessageHelper.Messages.MchatBan, reason + "(Banned by IP)",
                                        sDt);
                                    return;
                                }

                                _accountTable.FindById(id).Banned = false;
                                _accountAdapter.Update(_accountTable);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ReportAnErrorEx(e, " (BAN BY IP VERIFY)AttachToMainChat");
                    }

                    #endregion

                    if (row.Banned)
                    {
                        if (row.BanTimespan >= DateTime.Now)
                        {
                            var br = new UserDataSet.BanReasonsDataTable();
                            var ba = new BanReasonsTableAdapter();
                            ba.Fill(br);
                            var reason = br.FindByid(row.BanReason).Reason;
                            var dt = $"{row.BanTimespan:dd.MM.yyyy HH:mm:ss}";

                            sender.SendMessage(MessageHelper.Messages.MchatBan, reason, dt);
                            return;
                        }

                        row.Banned = false;
                        _accountAdapter.Update(_accountTable);
                    }

                    ChatAddInformation(sender.Name + ":  is now enter to main chat");


                    _mainChatUsers.Add(sender.Name, sender);
                    MChatUserView.Items.Add(sender.Name).SubItems.AddRange(new[]
                        {sender.Email, sender.Ip.ToString(), sender.Description});
                    sender.IsMChatActive = true;
                    sender.SendMessage(MessageHelper.Messages.MchatEnterPassed);
                }
            }
            catch (Exception e)
            {
                ReportAnError(e, "AttachToMainChat");
                sender.SendMessage(MessageHelper.Messages.MchatEnterFailed);
            }
        }

        public void SendMessageAllUsers(UserConnection sender,MessageHelper.Messages message, string additional)
        {
            try
            {
                var ic = _mainChatUsers.Keys;

                foreach (string nameClient in ic)
                    if (nameClient != sender.Name)
                        ((UserConnection) _mainChatUsers[nameClient]).SendMessage(message, additional);
            }
            catch (Exception e)
            {
                ReportAnError(e, " SendMessageAllUsers");
            }
        }

        /// <summary>
        ///     всем юзерам главного без исключений
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additional"></param>
        public void SendMessageAllUsers(MessageHelper.Messages message, string additional)
        {
            try
            {
                foreach (var nameClient in _mainChatUsers.Keys)
                    ((UserConnection) _mainChatUsers[nameClient]).SendMessage(message, additional);
            }
            catch (Exception e)
            {
                ReportAnError(e, " SendMessageAllUsersA");
            }
        }

        /// <summary>
        ///     ВСЕМ активным без исключений
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additional"></param>
        public void SendMessageAllAttached(MessageHelper.Messages message, string additional)
        {
            try
            {
                foreach (var nameClient in _attachedUsers.Keys)
                    ((UserConnection) _attachedUsers[nameClient]).SendMessage(message, additional);
            }
            catch (Exception e)
            {
                ReportAnError(e, " SendMessageALLActive");
                if (_debug)
                    throw;
            }
        }

        #region Отправка сообщения с сервера
        private void SendServerMessage(MessageHelper.Messages message, string additional)
        {
            var ic = _mainChatUsers.Keys;
            foreach (string nameClient in ic)
                ((UserConnection) _mainChatUsers[nameClient]).SendMessage(message, additional);
        }
        #endregion

        public void ServerSay(string tirade)
        {
            SendServerMessage(MessageHelper.Messages.Server, tirade);
        }

        public void SendMessageText()
        {
            if (!ChatAddOwnerMessage(MessageText.Text)) return;
            ServerSay(MessageText.Text);
            MessageText.Text = "";
        }
        //receive message from client
        private void OnClientReceive(UserConnection sender, string message)
        {
            try
            {
                ChatAddComment(sender, message);
                var messSplit = message.Split('|');
                switch (ClientConnectionLib.ClientConnection.GetMessage(messSplit[0]))
                {
                    case CCMessages.CreateRoom:
                        CreateRoom(sender, messSplit[1]);
                        break;
                    case CCMessages.Connect:
                        AuthorizeUser(messSplit[1], messSplit[2], sender);
                        break;
                    //*************************************
                    //          Main chat
                    //*************************************
                    case CCMessages.Chat:
                        if (sender.IsMChatActive)
                        {
                            UserSay(sender, messSplit[1]);

                            SendMessageAllUsers(sender, MessageHelper.Messages.Chat, "<" + sender.Name + ">" + messSplit[1]);
                        }
                        break;
                    case CCMessages.MchatEnter:
                        AttachToMainChat(sender);
                        SendListUserAll(sender);
                        break;
                    case CCMessages.MchatExit:
                        
                        DetachFromMainChat(sender);
                        break;
                    //***************************************
                    case CCMessages.Listusers:
                        SendListUsers(sender);
                        break;
                    case CCMessages.GetAllUsers:
                        SendAllUsersList(sender);
                        break;
                    case CCMessages.FindUser:
                        FindUsers(sender, messSplit);
                        break;
                    case CCMessages.Disconnect:
                        sender.CloseConnection();
                        break;
                    case CCMessages.Registration:
                        ChatAddWarning("User want to create new account");
                        RegisterUser(messSplit, sender);
                        break;
                    case CCMessages.YouAlive:
                        sender.SendMessage(MessageHelper.Messages.ServerAlive);
                        break;
                    case CCMessages.GetProfile: //  login           password
                        SendProfile(sender, messSplit[1], messSplit[2]);
                        break;
                    case CCMessages.Private:
                        PrivateProcessing(sender, messSplit);
                        break;
                    case CCMessages.AddContact:
                        AddContact(sender, messSplit);
                        break;
                    case CCMessages.ToWhite:
                        UsersToWhite(sender, messSplit);
                        break;
                    case CCMessages.ToBlack: 
                        UsersToBlack(sender, messSplit);
                        break;
                    case CCMessages.GetBw:
                        SendBlackWhite(sender, _params.BwDelay);
                        break;
                    case CCMessages.GetBwState:
                        Send_BW_State(sender, _params.BwDelay);
                        break;
                    case CCMessages.State:
                        StateChange(sender, messSplit[1]);
                        break;
                    case CCMessages.GetEmail:
                        SendEmail(sender, messSplit[1]);
                        break;
                    default:
                        ChatAddString("Unknown message:" + message);
                        break;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "client_Receive in MainForm.cs", _debug);
            }
        }

        private void CreateRoom(UserConnection sender, string roomName)
        {
            var ownerID = sender.Id;
            //UsersDataSet.
        }

        private void SendEmail(UserConnection sender, string user)
        {
            try
            {
                var id = FindUserId(user);
                if (id > -1)
                {
                    var email = _accountTable.FindById(id).Email;
                    sender.SendMessage(MessageHelper.Messages.Email, email);
                }
                else
                {
                    sender.SendMessage(MessageHelper.Messages.EmailAps);
                }
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "SendEmail");
                sender.SendMessage(MessageHelper.Messages.EmailAps);
            }
        }

        private void StateChange(UserConnection sender, string data)
        {
            try
            {
                var state = (State) Enum.Parse(typeof(State), data);

                sender.CurrentState = state;

                SayToAllUsers(sender);
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "StateChange");
            }
        }

        private void PrivateProcessing(UserConnection sender, string[] data)
        {
            try
            {
                //login,message,colorName,fontName,fontSize
                var pvtData = new string[data.Length - 1];
                for (var i = 1; i < data.Length; i++) pvtData[i - 1] = data[i];

                try
                {
                    var toUser = (UserConnection) _attachedUsers[pvtData[0]];
                    if (!toUser.Black.Contains(sender.Name))
                        toUser.SendMessage(MessageHelper.Messages.Private, 10, sender.Name, pvtData[1], pvtData[2],
                            pvtData[3], pvtData[4]);
                }
                catch (Exception e)
                {
                    var err = "ошибка в блоке доступа к пользователю "
                              + pvtData[0]
                              + "Exeption: "
                              + e.Message;

                    ReportAnErrorEx(err, "PrivateProcessing");
                }
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "PrivateProcessing");
            }
        }

        private void FindUsers(UserConnection sender, string[] data)
        {
            // login,firstName,lastName,email
            var criteries = new string[data.Length - 1];
            for (var i = 1; i < data.Length; i++) criteries[i - 1] = data[i];

            var loginSearch = _Text.ConteinsNotSpaces(criteries[0]);
            var fnSearch = _Text.ConteinsNotSpaces(criteries[1]);
            var lnSearch = _Text.ConteinsNotSpaces(criteries[2]);
            var eMailSearch = _Text.ConteinsNotSpaces(criteries[3]);

            var loginReg = ConvertMask(criteries[0]);
            var fnReg = ConvertMask(criteries[1]);
            var lnReg = ConvertMask(criteries[2]);
            var eMailReg = ConvertMask(criteries[3]);

            var users = new ArrayList();

            foreach (var row in _accountTable)
                if (!loginSearch || loginReg.Matches(row.Login).Count != 0)
                    if (!fnSearch || fnReg.Matches(row.Firstname).Count != 0)
                        if (!lnSearch || lnReg.Matches(row.Lastname).Count != 0)
                            if (!eMailSearch || eMailReg.Matches(row.Email).Count != 0)
                            {
                                var userData = "";

                                userData += row.Login;
                                userData += "&";
                                userData += row.Firstname;
                                userData += "&";
                                userData += row.Lastname;
                                userData += "&";
                                userData += row.Email;

                                users.Add(userData);
                            }

            if (users.Count != 0)
                sender.SendMessage(MessageHelper.Messages.ListAllUsers, (string[]) users.ToArray(typeof(string)));
        }

        private Regex ConvertMask(string mask)
        {
            var msk = mask;
            msk = msk.Replace(".", @"\.");
            msk = msk.Replace("?", ".");
            msk = msk.Replace("*", ".*");
            msk = "^" + msk + "$";
            return new Regex(msk, RegexOptions.IgnoreCase);
        }

        //private void SendWhiteState(UserConnection sender)
        //{
        //    var data = new ArrayList();
        //    foreach (string login in sender.White)
        //        if (AttachedUsers_Contains(login) != "" && VerifyId(sender.Id, login))
        //            data.Add(login + "&" +
        //                     Enum.GetName(typeof(STATE), ((UserConnection) AttachedUsers[login]).CurrentState));
        //        else
        //            data.Add(login + "&" + "Отключён");
        //    sender.SendMessage(Messages.WHITE_USER_STATE, (string[]) data.ToArray(typeof(string)));
        //}

        /// <summary>
        ///     нет ли id в черном списке данного юзера вернёт тру если нет
        /// </summary>
        private bool VerifyId(int id, string login)
        {
            var uid = FindUserId(login);
            if (uid > -1)
                if (GetBlackId(uid, id) < 0)
                    return true;
            return false;
        }
        private enum UserGroupType
        {
            White = 0,
            Black = 1
        }
        private void SendStateByList(UserConnection sender, UserGroupType groupType , int delay)
        {
            var data = new ArrayList();
            var userArrayList = groupType == UserGroupType.White ? sender.White : sender.Black;
            foreach (string login in userArrayList)
                if (AttachedUsers_Contains(login) != "" && VerifyId(sender.Id, login))
                {
                    var userState = ((UserConnection)_attachedUsers[login]).CurrentState;
                    if (userState == State.Invisible) userState = State.Off;
                    data.Add(login + "&" + Enum.GetName(typeof(State), userState));
                }
                else
                    data.Add($"{login}&{State.Off}");
            var messageHead = groupType == UserGroupType.White ? MessageHelper.Messages.WhiteUserState : MessageHelper.Messages.BlackUserState;
            sender.SendMessage(messageHead, delay, (string[]) data.ToArray(typeof(string)));
        }

        private void SendWhiteState(UserConnection sender, int delay)
        {
           SendStateByList(sender,UserGroupType.White,delay);
        }

        private void SendBlackState(UserConnection sender, int delay)
        {
            SendStateByList(sender, UserGroupType.Black, delay);
        }

        //private void SendBlackState(UserConnection sender)
        //{
        //    var data = new ArrayList();
        //    foreach (string login in sender.Black)
        //        if (AttachedUsers_Contains(login) != "" && VerifyId(sender.Id, login))
        //            data.Add(login + "&" +
        //                     Enum.GetName(typeof(STATE), ((UserConnection) AttachedUsers[login]).CurrentState));
        //        else
        //            data.Add(login + "&" + "Отключён");
        //    sender.SendMessage(Messages.BLACK_USER_STATE, (string[]) data.ToArray(typeof(string)));
        //}

        private void Send_BW_State(UserConnection sender, int delay)
        {
            SendWhiteState(sender, delay);
            SendBlackState(sender, delay * _params.BlackMulti);

            sender.SendMessage(MessageHelper.Messages.SendBwUserStateFinished, delay * _params.GeneralMulti);
        }

        private void SendBlackWhite(UserConnection sender, int delay)
        {
            try
            {
                var w = new ArrayList();
                var b = new ArrayList();

                foreach (UserDataSet.WhiteRow row in _whiteTable.Rows)
                    if (row.Login == sender.Id)
                    {
                        var l = ((UserDataSet.AccountRow) _accountTable.Rows.Find(row.Friend)).Login;
                        w.Add(l);
                    }

                sender.SendMessage(MessageHelper.Messages.WhiteList, delay, (string[]) w.ToArray(typeof(string)));

                foreach (UserDataSet.BlackRow row in _blackTable.Rows)
                    if (row.Login == sender.Id)
                    {
                        var l = ((UserDataSet.AccountRow) _accountTable.Rows.Find(row.Enemy)).Login;
                        b.Add(l);
                    }

                sender.SendMessage(MessageHelper.Messages.BlackList, delay + 100,
                    (string[]) b.ToArray(typeof(string)));

                sender.SendMessage(MessageHelper.Messages.SendBwFinished, delay + 200);
            }
            catch (Exception e)
            {
                ReportAnError(e, "SendBlackWhite");
                sender.SendMessage(MessageHelper.Messages.GetBwError);
            }
        }

        /// <summary>
        ///     -1, если не нашел и -2 если ошибка перечисления
        /// </summary>
        private int GetWhiteId(int login, int friend)
        {
            try
            {
                foreach (UserDataSet.WhiteRow row in _whiteTable.Rows)
                    if (row.Login == login && row.Friend == friend)
                        return row.Id;

                return -1;
            }
            catch (Exception e)
            {
                ReportAnError(e, "GetWhiteId");
                return -2;
            }
        }

        /// <summary>
        ///     -1, если не нашел и -2 если ошибка перечисления
        /// </summary>
        private int GetBlackId(int login, int enemy)
        {
            try
            {
                foreach (UserDataSet.BlackRow row in _blackTable.Rows)
                    if (row.Login == login && row.Enemy == enemy)
                        return row.Id;

                return -1;
            }
            catch (Exception e)
            {
                ReportAnError(e, "GetBlackId");
                return -2;
            }
        }

        private readonly AlertSystem _alertSystem = new AlertSystem();

        private void AddContact(UserConnection sender, string[] logins)
        {
            try
            {
                var newContacts = new ArrayList();
                var wrongContacts = new ArrayList();
                for (var i = 1; i < logins.Length; i++)
                {
                    var fId = FindUserId(logins[i]);
                    if (fId > -1)
                    {
                        if (sender.Id == fId)
                        {
                            wrongContacts.Add(logins[i]);
                            continue;
                        }

                        #region не добавлен ли сендер в друзья

                        if (GetWhiteId(fId, sender.Id) < 0)
                        {
                            //    отправить данного юзера в чёрный список
                            //    к добавляемому к данному юзеру контакту
                            //    чтобы предоставить  добавляемому контакту
                            //    возможность выбора: позволить или нет с ним общаться
                            UserToBlack(sender.Id, fId);

                            //   попытка сообщить юзеру 
                            //   что сендер добавил его в контакты
                            if (!TrySendAlert(logins[i], sender.Name)) _alertSystem.Watch(fId, sender.Id);
                        }

                        #endregion

                        var wId = GetWhiteId(sender.Id, fId);
                        if (wId == -1)
                        {
                            _whiteTable.AddWhiteRow(sender.Id, fId);
                            newContacts.Add(logins[i]);
                            DeleteFromBlack(sender.Id, fId); // на всякий пож. :)
                        }
                        else if (wId > -1)
                        {
                            wrongContacts.Add(logins[i]);
                        }
                    }
                }

                _whiteAdapter.Update(_whiteTable);
                if (wrongContacts.Count != 0)
                    sender.SendMessage(MessageHelper.Messages.AddContactWrong, _params.BwDelay * _params.BlackMulti,
                        (string[]) wrongContacts.ToArray(typeof(string)));
                if (newContacts.Count != 0)
                    sender.SendMessage(MessageHelper.Messages.AddContactPass, _params.BwDelay * _params.GeneralMulti,
                        (string[]) newContacts.ToArray(typeof(string)));
            }
            catch (Exception e)
            {
                ReportAnError(e, "AddContact");
                sender.SendMessage(MessageHelper.Messages.AddContactWrong);
            }
            finally
            {
                sender.BW_Fill(_accountTable);
                Send_BW_State(sender, _params.BwDelay);
            }
        }

        public bool TrySendAlert(string login, string guest)
        {
            var strong = AttachedUsers_Contains(login);

            if (strong != "")
            {
                ((UserConnection) _attachedUsers[strong]).SendMessage(MessageHelper.Messages.Alert, guest);
                return true;
            }

            return false;
        }

        private void UsersToWhite(UserConnection sender, string[] logins)
        {
            try
            {
                for (var i = 1; i < logins.Length; i++)
                {
                    var fId = FindUserId(logins[i]);
                    if (fId > -1)
                    {
                        if (sender.Id == fId)
                        {
                            sender.SendMessage(MessageHelper.Messages.WhiteAddWrong, logins[i]);
                            continue;
                        }

                        var wId = GetWhiteId(sender.Id, fId);
                        if (wId == -1)
                        {
                            _whiteTable.AddWhiteRow(sender.Id, fId);
                            DeleteFromBlack(sender.Id, fId);
                            if (AttachedUsers_Contains(logins[i]) != "")
                                Send_BW_State((UserConnection) _attachedUsers[logins[i]], _params.BwDelay);
                        }
                        else if (wId > -1)
                        {
                            sender.SendMessage(MessageHelper.Messages.WhiteAddWrong, logins[i]);
                        }
                    }
                }

                _whiteAdapter.Update(_whiteTable);
                sender.SendMessage(MessageHelper.Messages.WhiteAddPass);
            }
            catch (Exception e)
            {
                ReportAnError(e, "UsersToWhite");
                sender.SendMessage(MessageHelper.Messages.WhiteAddError);
            }
            finally
            {
                sender.BW_Fill(_accountTable);
                Send_BW_State(sender, _params.BwDelay);
            }
        }

        private void UsersToBlack(UserConnection sender, string[] logins)
        {
            try
            {
                for (var i = 1; i < logins.Length; i++) UserToBlack(sender, logins[i]);
                _blackAdapter.Update(_blackTable);

                sender.SendMessage(MessageHelper.Messages.BlackAddPass);
            }
            catch (Exception e)
            {
                ReportAnError(e, "UsersToBlack");
                sender.SendMessage(MessageHelper.Messages.BlackAddError);
            }
            finally
            {
                sender.BW_Fill(_accountTable);
                Send_BW_State(sender, _params.BwDelay);
            }
        }

        /// <summary>
        ///     логин - кого
        ///     сендер- кому
        ///     (юзер с логином login будет добавлен в чёрный список к юзеру sender)
        /// </summary>
        private void UserToBlack(UserConnection sender, string login)
        {
            try
            {
                var eId = FindUserId(login);
                if (eId > -1)
                {
                    if (sender.Id == eId)
                    {
                        sender.SendMessage(MessageHelper.Messages.BlackAddWrong, login);
                        return;
                    }

                    var bId = GetBlackId(sender.Id, eId);
                    if (bId == -1)
                    {
                        _blackTable.AddBlackRow(sender.Id, eId);
                        DeleteFromWhite(sender.Id, eId);
                        if (AttachedUsers_Contains(login) != "")
                            Send_BW_State((UserConnection) _attachedUsers[login], _params.BwDelay);
                    }
                    else if (eId > -1)
                    {
                        sender.SendMessage(MessageHelper.Messages.BlackAddWrong, login);
                    }
                }
            }
            catch (Exception e)
            {
                ReportAnError(e, "UserToBlack");
                sender.SendMessage(MessageHelper.Messages.BlackAddWrong, login);
            }
        }

        private void UserToBlack(int idToAdd /*типа idToAdd*/, int isOwner /*типа idOwner*/)
        {
            try
            {
                var bId = GetBlackId(isOwner, idToAdd);
                if (bId < 0)
                {
                    _blackTable.AddBlackRow(isOwner, idToAdd);
                    DeleteFromWhite(isOwner, idToAdd);
                    _blackAdapter.Update(_blackTable);

                    var login = _accountTable.FindById(isOwner).Login;
                    if (AttachedUsers_Contains(login) != "")
                    {
                        var user = (UserConnection) _attachedUsers[login];
                        user.BW_Fill(_accountTable);
                    }
                }
            }
            catch (Exception e)
            {
                ReportAnError(e, "UserToBlack(string idToAdd,string isOwner)");
            }
        }

        private void DeleteFromWhite(int login, int friend)
        {
            try
            {
                var wId = GetWhiteId(login, friend);
                if (wId > -1)
                {
                    _whiteTable.FindById(wId).Delete();

                    _whiteAdapter.Update(_whiteTable);
                }
                else
                {
                    ChatAddError("Удаление из белого списка неудалось: в таблице не найден id переданных данных");
                    ChatAddError("ДАННЫЕ: login = " + login + " friend = " + friend);
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "DeleteFromWhite in MainForm.cs", _debug);
            }
        }

        private void DeleteFromBlack(int login, int enemy)
        {
            try
            {
                var bId = GetBlackId(login, enemy);
                if (bId > -1)
                {
                    _blackTable.FindById(bId).Delete();

                    _blackAdapter.Update(_blackTable);
                }
                else
                {
                    if (_debug)
                    {
                        ChatAddError("Удаление из чёрного списка неудалось: в таблице не найден id переданных данных");
                        ChatAddError("ДАННЫЕ: login = " + login + " enemy = " + enemy);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "DeleteFromBlack in MainForm.cs", _debug);
            }
        }

        private void SendAllUsersList(UserConnection sender)
        {
            var reply = new ArrayList();

            foreach (UserDataSet.AccountRow row in _accountTable.Rows)
            {
                var userData = "";

                userData += row.Login;
                userData += "&";
                userData += row.Firstname;
                userData += "&";
                userData += row.Lastname;
                userData += "&";
                userData += row.Email;

                reply.Add(userData);
            }

            sender.SendMessage(MessageHelper.Messages.ListAllUsers, (string[]) reply.ToArray(typeof(string)));
        }

        private void SendProfile(UserConnection sender, string login, string password)
        {
            try
            {
                // какому юзеру
                login = AttachedUsers_Contains(login);
                if (login == "")
                {
                    sender.SendMessage(MessageHelper.Messages.RegistrationFailedDefault);
                    return;
                }

                var user = (UserConnection) _attachedUsers[login];
                // проверка на хак
                if (String.Compare(user.Password, password, StringComparison.Ordinal) != 0)
                {
                    sender.SendMessage(MessageHelper.Messages.RegistrationFailedDefault);
                    return;
                }

                var row = _accountTable.FindById(user.Id);

                sender.SendMessage(MessageHelper.Messages.Profile,
                    row.Login,
                    row.Password,
                    row.Firstname,
                    row.Lastname,
                    row.Email,
                    row.Description);
            }
            catch (Exception e)
            {
                sender.SendMessage(MessageHelper.Messages.ServerError);
                ReportAnError(e, "SendProfile");
            }
        }

        private void DetachFromMainChat(UserConnection sender)
        {
            try
            {
                SendMessageAllUsers(sender, MessageHelper.Messages.Userlost, sender.Name);
                _mainChatUsers.Remove(sender.Name);
                MChatItemRemove(sender.Name);
                sender.IsMChatActive = false;
                sender.SendMessage(MessageHelper.Messages.MchatExit);
            }
            catch (Exception e)
            {
                ReportAnError(e, "DetachFromMainChat");
            }
        }

        public enum Reason
        {
            Default,
            LoginAlreadyExist,
            VerifyDataFailed
        }

        private void SendRegistrationFailed(UserConnection sender, Reason reason)
        {
            try
            {
                var message = MessageHelper.Messages.RegistrationFailed;
                switch (reason)
                {
                    case Reason.Default:
                        message = MessageHelper.Messages.RegistrationFailedDefault;
                        break;
                    case Reason.LoginAlreadyExist:
                        message = MessageHelper.Messages.RegistrationFailedLoginAlreadyExist;
                        break;
                    case Reason.VerifyDataFailed:
                        message = MessageHelper.Messages.RegistrationVerifydataError;
                        break;
                }

                sender.SendMessage(message);
                ChatAddError("create new account failed");

                if (reason != Reason.LoginAlreadyExist && reason != Reason.VerifyDataFailed) sender.CloseConnection();
            }
            catch (Exception e)
            {
                ReportAnError(e, "SendRegistrationFailed");
            }
        }

        private void RegisterUser(string[] messages, UserConnection sender)
        {
            try
            {
                var koef = messages.Length - UserData_RowCount;

                //    регистрация        изменение профиля
                if (koef != 1 && koef != 3)
                {
                    SendRegistrationFailed(sender, Reason.Default);
                    return;
                }

                var senderUser = new ArrayList();
                sender.DataArray = new string[messages.Length - koef];

                for (var i = koef; i < messages.Length; i++) sender.DataArray[i - koef] = messages[i];
                senderUser.Add(sender);

                if (koef == 3)
                {
                    var login = messages[1];
                    var password = messages[2];
                    // какому юзеру
                    login = AttachedUsers_Contains(login);
                    if (login == "")
                    {
                        sender.SendMessage(MessageHelper.Messages.RegistrationFailedDefault);
                        return;
                    }

                    var user = (UserConnection) _attachedUsers[login];
                    // проверка на хак
                    if (string.Compare(user.Password, password, StringComparison.Ordinal) != 0)
                    {
                        sender.SendMessage(MessageHelper.Messages.RegistrationFailedDefault);
                        return;
                    }

                    senderUser.Add(user);
                }


                // регистрация в новом потоке чтобы освободить прием сообщений
                var th = new Thread(DoRegistrationUser);
                th.Start(senderUser);
            }
            catch (Exception e)
            {
                ReportAnError(e, "RegisterUser");
            }
        }

        public enum UserData : uint
        {
            /// <summary>
            ///     логин не может быть пустым
            /// </summary>
            Login = 0,

            /// <summary>
            ///     пароль не может быть менее 6 символов
            /// </summary>
            Password,

            /// <summary>
            ///     имя может содержать только буквы
            /// </summary>
            Firstname,

            /// <summary>
            ///     фамилия может содержать только буквы
            /// </summary>
            Lastname,
            Email,
            Description
        }

        /// <summary>
        ///     Проверка корректности личных данных пользователя
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool VerifyData(string[] data)
        {
            try
            {
                var rName = new Regex(@"^[A-Za-zА-Яа-я-]+$");
                var rMail = new Regex(@"^[^ @]+@[^ @]+\.[^ \.@]+$");

                //MessageBox.Show(String.Join("***",data));

                for (var i = 0; i < UserData_RowCount; i++)
                    switch ((UserData) i)
                    {
                        case UserData.Login:
                            if (_Text.IsEmpty(data[i])) return false;
                            data[i] = _Text.Normalize(data[i]);
                            break;
                        case UserData.Password:
                            if (data[i].Length < 6) return false;
                            break;
                        case UserData.Firstname:
                            if (rName.Matches(data[i]).Count == 0) return false;
                            break;
                        case UserData.Lastname:
                            if (rName.Matches(data[i]).Count == 0) return false;
                            break;
                        case UserData.Email:
                            if (rMail.Matches(data[i]).Count == 0) return false;
                            break;
                        case UserData.Description:
                            if (data[i] == null) return false;
                            break;
                    }

                return true;
            }
            catch (Exception e)
            {
                ReportAnError(e, "VerifyData");
                return false;
            }
        }

        public enum AddAccountError
        {
            NoProblem,
            LoginAlreadyExist,
            DatabaseException
        }

        private AddAccountError AddNewAccount(string[] data, IPAddress ip)
        {
            var findRes = FindUserId(data[0]);

            if (findRes > -1) return AddAccountError.LoginAlreadyExist;
            if (findRes == -2) return AddAccountError.DatabaseException;

            try
            {
                var bt = new UserDataSet.BanReasonsDataTable();

                var br = bt.NewBanReasonsRow();
                br.Reason = "";

                var row = _accountTable.AddAccountRow(data[0],
                    data[1],
                    data[2],
                    data[3],
                    data[4],
                    data[5],
                    false,
                    DateTime.Now,
                    ip.ToString(),
                    false,
                    br
                );

                _accountAdapter.Update(_accountTable);

                // по умолчанию Другие должны входить в чёрный список
                _blackTable.AddBlackRow(row.Id, 1);


                _blackAdapter.Update(_blackTable);

                return AddAccountError.NoProblem;
            }
            catch (Exception e)
            {
                ReportAnError(e, "AddNewAccount");
                return AddAccountError.DatabaseException;
            }
        }

        private AddAccountError EditAccount(UserConnection sender, UserConnection user)
        {
            try
            {
                var row = _accountTable.FindById(user.Id);

                row.Login = sender.DataArray[0];
                row.Password = sender.DataArray[1];
                row.Firstname = sender.DataArray[2];
                row.Lastname = sender.DataArray[3];
                row.Email = sender.DataArray[4];
                row.Description = sender.DataArray[5];

                //AccountTable.AcceptChanges();
                _accountAdapter.Update(_accountTable);
                return AddAccountError.NoProblem;
            }
            catch (Exception e)
            {
                ReportAnError(e, "AddNewAccount");
                return AddAccountError.DatabaseException;
            }
        }

        #region FindUser

        /// <summary>
        ///     -1, если не нашел и -2 если ошибка перечисления
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private int FindUserId(string login)
        {
            try
            {
                foreach (UserDataSet.AccountRow row in _accountTable.Rows)
                    if (String.Compare(row.Login, login, StringComparison.OrdinalIgnoreCase) == 0)
                        return row.Id;

                return -1;
            }
            catch (Exception e)
            {
                ReportAnError(e, "FindUserId");
                return -2;
            }
        }

/*
        /// <summary>
        ///     -1, если не нашел и -2 если ошибка перечисления
        /// </summary>
        /// <param name="login"></param>
        /// <param name="AccountTable"></param>
        /// <returns></returns>
        private int FindUserPosition(string login, UserDataSet.AccountDataTable AccountTable)
        {
            try
            {
                for (var i = 0; i < AccountTable.Rows.Count; i++)
                {
                    var row = (UserDataSet.AccountRow) AccountTable.Rows[i];
                    if (String.Compare(row.Login, login, StringComparison.OrdinalIgnoreCase) == 0) return i;
                }

                return -1;
            }
            catch (Exception e)
            {
                ReportAnError(e, "FindUserPosition");
                return -2;
            }
        }
*/

        #endregion

        private void DoRegistrationUser(object parameter)
        {
            try
            {
                var senderUser = (ArrayList) parameter;
                var sender = (UserConnection) senderUser[0];
                var res = AddAccountError.NoProblem;

                if (senderUser.Count == 2)
                {
                    var user = (UserConnection) senderUser[1];
                    if (!VerifyData(sender.DataArray))
                    {
                        SendRegistrationFailed(sender, Reason.VerifyDataFailed);
                        return;
                    }

                    res = EditAccount(sender, user);
                }
                else if (senderUser.Count == 1)
                {
                    if (!VerifyData(sender.DataArray))
                    {
                        SendRegistrationFailed(sender, Reason.VerifyDataFailed);
                        return;
                    }

                    res = AddNewAccount(sender.DataArray, sender.Ip);
                }

                ///////////////////Обработка ошибок///////////////////////
                if (res == AddAccountError.LoginAlreadyExist)
                {
                    SendRegistrationFailed(sender, Reason.LoginAlreadyExist);
                    return;
                }

                if (res == AddAccountError.DatabaseException)
                {
                    SendRegistrationFailed(sender, Reason.Default);
                    return;
                }

                RegistrationRelease(sender);
            }
            catch (Exception e)
            {
                ReportAnError(e, "DoRegistrationUser");
            }
        }

        private void RegistrationRelease(UserConnection user)
        {
            user.SendMessage(MessageHelper.Messages.RegistrationPassed);

            ChatAddInformation("new account was created or modifyed");
            //клиент самостоятельно должен разорвать конект
            // user.CloseConnection();
        }

        private void PreparingCloseUserConnection(UserConnection sender)
        {
            if (sender.IsMChatActive)
            {
                ChatAddComment(sender.Name + " user disconnected");
                SendMessageAllUsers(sender, MessageHelper.Messages.Chat, sender.Name + " user disconnected");
            }
            else if (!sender.IsAttached)
            {
                ChatAddComment("анонимное соединение разорвано IP = " + sender.Ip);
            }
            else if (sender.IsAttached)
            {
                ChatAddComment(sender, "соединение разорвано IP = " + sender.Ip);
                if (_cancelClose) BaseFlush();
            }
        }

        private void BaseFlush()
        {
            try
            {
              
                    _accountAdapter.Update(_accountTable);
                    _whiteAdapter.Update(_whiteTable);
                    _blackAdapter.Update(_blackTable);
              

                _alertSystem.Flush();
            }
            catch (Exception e)
            {
                ReportAnErrorEx(e, "BaseFlush");
            }
        }

        private void AfterCloseUserConnection(UserConnection sender)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AfterCloseUserConnection(sender)));
                return;
            }

            try
            {
                if (sender.IsMChatActive)
                {
                    _mainChatUsers.Remove(sender.Name);
                    MChatItemRemove(sender.Name);
                    SendMessageAllUsers(MessageHelper.Messages.Userlost, sender.Name);
                }

                if (sender.IsAttached)
                {
                    _attachedUsers.Remove(sender.Name);
                    AttachedUsersViewItemRemove(sender.Name);
                    SayToAllUsers(sender);
                }

                _clients.Remove(sender);
            }
            catch (Exception e)
            {
                ReportAnError(e, "AfterCloseUserConnection");
            }
        }

        public void OnDisconnectUser(UserConnection sender, UserConnection.DisconnectReason reason)
        {
            try
            {
                if (sender != null)
                {
                    PreparingCloseUserConnection(sender);

                    sender.CloseConnection();
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorToLog(e.Message, "OnDisconnectUser in MainForm.cs");
                ChatAddError(e.Message);
            }
            finally
            {
                AfterCloseUserConnection(sender);
            }
        }

        private void UserSay(UserConnection sender, string message)
        {
            ChatAddString("<" + sender.Name + ">" + message);
        }

        private void AttachedUsersViewItemRemove(string item)
        {
            for (var i = 0; i < AttachedUsersView.Items.Count; i++)
                if (AttachedUsersView.Items[i].Text == item)
                {
                    AttachedUsersView.Items[i].Remove();
                    return;
                }
        }

        public void MChatItemRemove(string item)
        {
            for (var i = 0; i < MChatUserView.Items.Count; i++)
                if (MChatUserView.Items[i].Text == item)
                {
                    MChatUserView.Items[i].Remove();
                    return;
                }
        }

        private void SendListUsers(UserConnection sender)
        {
            var reply = MChatUserStringCreate();

            sender.SendMessage(reply.message, reply.additional);
        }

        ///// <summary>
        /////     Всем без исключений
        ///// </summary>
        //private void SendListUserAll()
        //{
        //    var reply = MChatUserStringCreate();
        //    SendMessageAllUsers(reply);
        //}

        /// <summary>
        ///     Всем за исключенем одного
        /// </summary>
        /// <param name="exceptionSender"></param>
        private void SendListUserAll(UserConnection exceptionSender)
        {
            var reply = MChatUserStringCreate();
            SendMessageAllUsers(exceptionSender, reply.message, reply.additional);
        }

        private (MessageHelper.Messages message,string additional) MChatUserStringCreate()
        {
            var reply = "";
            foreach (DictionaryEntry entry in _mainChatUsers)
            {
                var us = (UserConnection) entry.Value;
                reply += us.Name;
                reply += "&" + us.Description;
                reply += "&" + us.Email;
                reply += "|";
            }

            return (MessageHelper.Messages.Listusers, reply.TrimEnd('|'));
        }
        #endregion

        #region Обработка ошибок

        private int _reportsCount = 1;

        public void ReportAnError()
        {
            Info.Text = @"лог ошибок обновлён " + _reportsCount;
            _reportsCount++;
        }

        /// <summary>
        ///     будет записано в лог, если DEBUG выдано сообщение, иначе обновление статуса
        ///     К строке имени метода будет добавлено 'in MainForm.cs'
        /// </summary>
        public void ReportAnError(Exception e, string methodName)
        {
            ErrorsProc.WriteErrorAndMessage(e, methodName + " in MainForm.cs", _debug);
            ReportAnError();
        }

        ///// <summary>
        /////     будет записано в лог, если DEBUG выдано сообщение, иначе обновление статуса
        /////     К строке имени метода будет добавлено 'in MainForm.cs'
        ///// </summary>
        //public void ReportAnError(string error, string methodName)
        //{
        //    ErrorsProc.WriteErrorAndMessage(error, methodName + " in MainForm.cs", _debug);
        //    ReportAnError();
        //}

        /// <summary>
        ///     будет записано в лог, если DEBUG сообщение в главном чате, иначе обновление статуса
        ///     К строке имени метода будет добавлено 'in MainForm.cs'
        /// </summary>
        public void ReportAnErrorEx(string error, string methodName)
        {
            ErrorsProc.WriteErrorToLog(error, methodName + " in MainForm.cs");
            ChatAddError(error + " (" + methodName + " in MainForm.cs" + ")");
            ReportAnError();
        }

        /// <summary>
        ///     будет записано в лог, если DEBUG сообщение в главном чате, иначе обновление статуса
        ///     К строке имени метода будет добавлено 'in MainForm.cs'
        /// </summary>
        public void ReportAnErrorEx(Exception e, string methodName)
        {
            ErrorsProc.WriteErrorToLog(e, methodName + " in MainForm.cs");
            ChatAddError(e.Message + " (" + methodName + " in MainForm.cs" + ")");
            ReportAnError();
        }

        public void ReportNoProblem()
        {
            Info.Text = @"Ready";
            _reportsCount = 1;
        }

        #endregion
    }
}