using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using ClientConnectionLib;
using ErrorsProcessingLib;
using Messenger_Client.Properties;
using ParametresLib;
using SplashScreenLib;
using static ServerInterfaceLib.MessageHelper;
using State = ClientConnectionLib.MessageHelper.State;
namespace Messenger_Client
{
    public partial class MainForm : Form
    {
        private void UVC_AddContact_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        public bool Debug { get; private set; }

        private const string OtherUsers = @"Другие";
        public bool LogsWrite = true;
        private bool _cancelClose = true;
        private MainChat _mainChat;

        public bool IsNowConnected { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            _protectionPanelLeft = ProtectionPanel.Left;
            _stateMenuContainers = new List<ToolStripMenuItem>
            {
                TC_State,
                MM_State
            };
            GenerateStatesMenu();
#if !DEBUG
            PullOut.Visible = false;
            Push.Visible = false;
#else
            Debug = true;
#endif
        }

        private readonly List<ToolStripMenuItem> _stateMenuContainers;

        private void SwitchAndSendState(ToolStripMenuItem menuItemToCheck)
        {
            var state = (State)Enum.Parse(typeof(State), menuItemToCheck.Name);
            CheckItemInAllStateContainers(state);
            SendState(state);
            PrivateForceDisconnectBy(state);
        }

        private void PrivateForceDisconnectBy(State state)
        {
            if (state == State.Invisible)
                PrivateForceDisconnectEnable();
            else
                PrivateForceDisconnectDisable();
        }

        private void CheckItemInAllStateContainers(State state)
        {
            var name = Enum.GetName(typeof(State), state);
            System.Diagnostics.Debug.Assert(name != null, nameof(name) + " != null");
            foreach (var menuContainer in _stateMenuContainers)
            {
                MenuItemCheckSwitch((ToolStripMenuItem) menuContainer.DropDownItems.Find(name, false)[0],
                    menuContainer.DropDownItems, true);
            }
        }

        private void GenerateStatesMenu()
        {
            foreach (var menuContainer in _stateMenuContainers)
            {
                foreach (State state  in Enum.GetValues(typeof(State)))
                {
                    if(state == State.Off) continue;

                    var newItem = new ToolStripMenuItem
                    {
                        Text = state.GetDescription(),
                        Name = Enum.GetName(typeof(State), state)
                    };
                    newItem.Click += MM_State_Click;
                    menuContainer.DropDownItems.Add(newItem);
                }
            }
        }

        private void MM_State_Click(object sender, EventArgs e)
        {
            SwitchAndSendState((ToolStripMenuItem) sender);
        }

        #region События

        #region События трея

        #region Вызов главного чата

        public static bool MChatIsRun;

        private void MChatLogin()
        {
            if (IsOnLine())
            {
                if (!MChatIsRun)
                {
                    MChatIsRun = true;
                    SwitchMChatLoginVisible();

                    MChatRun();

                    _connection.SendMessage(ClientConnection.Messages.MchatEnter);
                }
                else
                {
                    Report.Information("Вы уже вошли в Главный чат");
                }
            }
        }

        private void MChatRun()
        {
            try
            {
                _mainChat = new MainChat("Main Chat") {Login = Login.Text};
                _mainChat.FormClosed += _mainChat_FormClosed;
                _mainChat.Say += _mainChat_Say;
                _mainChat.WantClose += _mainChat_WantClose;

                MChatInitialize();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "MChatRun() in MainForm.cs", Debug);
            }
        }

        private void MChatInitialize()
        {
            HackMChat();
            _mainChat.Show();
            _mainChat.Visible = false;
            RecoverMChat();
        }

        private void HackMChat()
        {
            _mainChat.WidthStored = _mainChat.Width;
            _mainChat.HeightStored = _mainChat.Height;

            _mainChat.Width = 0;
            _mainChat.Height = 0;
            _mainChat.Opacity = 0;
            _mainChat.ShowInTaskbar = false;
        }

        private void RecoverMChat()
        {
            _mainChat.Width = _mainChat.WidthStored;
            _mainChat.Height = _mainChat.HeightStored;
            _mainChat.Opacity = 1;
            _mainChat.ShowInTaskbar = true;
        }

        private void MChatShow()
        {
            if (IsOnLine() && _mainChat != null)
                    _mainChat.Visible = true;
        }
        private void _mainChat_WantClose()
        {
            try
            {
                if (IsOnLine())
                    _connection.SendMessage(ClientConnection.Messages.MchatExit);
                else
                    MChatClose();
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        private void MChatClose()
        {
            if (MChatIsRun)
            {
                MChatIsRun = false;

                _mainChat.CancelClose = false;
                _mainChat.Close();
            }
        }

        private void _mainChat_Say(string tirada)
        {
            if (IsOnLine()) _connection.SendMessage(ClientConnection.Messages.Chat, tirada);
        }

        private void _mainChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tray_MChat_Login.Enabled = true;
            MM_MainChat.Enabled = true;
        }

        /// <summary>
        ///     if IsNowConnected and _connection.IsNowAttached
        /// </summary>
        /// <returns></returns>
        public bool IsOnLine()
        {
            return IsNowConnected && _connection.IsNowAttached;
        }

        private void SwitchMChatLoginVisible()
        {
            Tray_MChat_Login.Enabled = !MChatIsRun;
            MM_MainChat.Enabled = !MChatIsRun;
        }

        #endregion

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
            PopupThis();
        }

        private void PopupThis()
        {
            TopMost = true;
            TopMost = false;
        }

        private void Tray_MChat_Login_Click(object sender, EventArgs e)
        {
            MChatLogin();
        }

        private void MenuItemCheckSwitch(ToolStripMenuItem menuItemForChecking,ToolStripItemCollection otherMenuItems,bool check)
        {
            foreach (ToolStripMenuItem item in otherMenuItems) item.Checked = !check;
            menuItemForChecking.Checked = check;
        }
        #endregion

        #region События Главной Формы

        #region Обработка Главного меню

        private void MM_CreateRoom_Click(object sender, EventArgs e)
        {
            //_connection.SendMessage(ClientConnection.Messages.);
            //var chat = new MainChat("test");
            //chat.Say += s => { };
            //chat.WantClose += () => { chat.ExitNow(); };
        }

        private void MM_ShutDown_Click(object sender, EventArgs e)
        {
            CorrectExit();
        }

        private void MM_Hide_Click(object sender, EventArgs e)
        {
            HideThis();
        }

        private void MM_Topmost_Click(object sender, EventArgs e)
        {
            SwitchTopmost();
        }

        private void MM_ShowLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(ErrorsProc.LogPath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"Log file doesn't exist", @"Messenger", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        private void SwitchTopmost()
        {
            TopMost = !TopMost;
            MM_Topmost.Checked = !TopMost;
        }

        private void MM_MainChat_Click(object sender, EventArgs e)
        {
            MChatLogin();
        }

        private void PullOut_Click(object sender, EventArgs e)
        {
            ProtectionPanelPullOut();
        }

        private void Push_Click(object sender, EventArgs e)
        {
            ProtectionPanelPush();
        }

        private void MM_View_DropDownOpening(object sender, EventArgs e)
        {
            Push.Enabled = _protectionPanelIsOpen;
            PullOut.Enabled = !_protectionPanelIsOpen;
        }

        private void MM_Logout_Click(object sender, EventArgs e)
        {
            _connection.ShutDown();
        }

        private void MM_Find_Contact_Click(object sender, EventArgs e)
        {
            ShowFindForm();
        }

        private Options _opt;

        private void MM_Params_Click(object sender, EventArgs e)
        {
            ShowParamsForm();
        }

        private void MM_Collect_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void MM_File0_DropDownOpening(object sender, EventArgs e)
        {
            if (!Debug) MM_Collect.Visible = false;
        }

        private void MM_About_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        #endregion

        #region Загрузка и закрытие
        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashStep();
            _ps = Parametres.Load();
            SplashStep();
#if !DEBUG
// to force debugging
            // IsDebug = _ps.WatchForce;
#endif
            if (Debug)
            {
                _watch = new Watch(this);
                SplashStep();
                WatchFormInitialize();
            }

            SplashStep();
            MM_DisableWithOut(true);
            SplashStep();

            if (_ps.SavePassword)
            {
                Login.Text = _ps.Login;
                Password.Text = _ps.Password;

                Login.Enabled = false;
                Password.Enabled = false;
                SavePassword.Checked = true;
            }

            SplashStep();
            ConnectedEvent += OnConnected;
            AttachedEvent += OnAttached;

            _alertForm = new Alert();
            _alertForm.OK.Click += OnAlertOk;
            _alertForm.Cancel.Click += OnAlertCancel;
            _alertForm.FormClosing += OnAlertFormClosed;

            SplashStep();
            AlertFormInitialize();
            SplashStep();

            if (Debug)
            {
                btnDefault.Visible = true;
                btnUser.Visible = true;
                _watch.Visible = true;
                SplashStep();
            }

            if (_ps.AutoStart) Options.SetAutoStart();
            SplashClose();
        }

        private void SplashStep()
        {
            SplashScreen.SetStatus("Инициализация компонентов...");
            Thread.Sleep(50);
        } 

        private void SplashClose()
        {
            Thread.Sleep(1000);
            SplashScreen.CloseForm();
            Thread.Sleep(100);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancelClose;
            if (_cancelClose)
            {
                HideThis();
            }
            else
            {
                if (IsNowConnected) _connection.ShutDown();

                PrivatesKill();
            }
        }

        private void MainLayout(object sender, LayoutEventArgs e)
        {
            Activate();
        }

        #endregion

        #region сохранение пароля

        private void SavePassword_CheckedChanged(object sender, EventArgs e)
        {
            Login.Enabled = !SavePassword.Checked;
            Password.Enabled = !SavePassword.Checked;
            SaveAuthorizationParams();   
        }

        private void SaveAuthorizationParams()
        {
            var ps = Parametres.Load();
            ps.Login = SavePassword.Checked ? Login.Text : string.Empty;
            ps.Password = SavePassword.Checked ? Password.Text : string.Empty;
            ps.SavePassword = SavePassword.Checked;
            var pr = new Parametres(ps);
            pr.Save();
        }
        #endregion

        #region UserView Context

        private void ShowToolTip(string message, string caption)
        {
            TrayIco.BalloonTipText = message;
            TrayIco.BalloonTipTitle = caption;
            TrayIco.ShowBalloonTip(1000);
        }

        private void UserCame(string name)
        {
            ShowToolTip("User " + name + " has just signed in", "Messenger");
        }

        private void UVC_SendPrivate_Click(object sender, EventArgs e)
        {
            SendPrivate();
        }

        private void UVC_SendMail_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        private void UVC_MoveUser_Click(object sender, EventArgs e)
        {
            MoveUser();
        }

        private void UserViewContext_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (UserView.SelectedItems.Count != 0)
                {
                    EnableUVC(true);

                    var li = UserView.SelectedItems[0];
                    var stateItem = li.SubItems[1];
                    System.Diagnostics.Debug.Assert(stateItem.Tag != null, "stateItem.Tag == null");
                    var state = (State)stateItem.Tag;
                    var blackGroupName = GetListViewGroup(GroupType.Black).Name;


                    UVC_MoveUser.Text = string.Compare(li.Group.Name, GetListViewGroup(GroupType.White).Name, StringComparison.Ordinal) ==0 
                        ? "Запретить" : "Разрешить";
                    if (state == State.Off || string.Compare(li.Group.Name, blackGroupName, StringComparison.Ordinal) == 0)
                        UVC_SendPrivate.Enabled = false;
                    else if (state == State.Invisible)
                        UVC_SendPrivate.Enabled = false;
                    else
                        UVC_SendPrivate.Enabled = true;
                }
                else
                {
                    EnableUVC(false);
                    UVC_AddContact.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ErrorsProc.WriteErrorAndMessage(exception, "UserViewContext_Opening in MainForm.cs", Debug);
            }
        }

        // ReSharper disable once InconsistentNaming
        private void EnableUVC(bool enable)
        {
            try
            {
                foreach (ToolStripMenuItem item in UserViewContext.Items) item.Enabled = enable;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorToLog(e, "EnableUVC in MainForm.cs");
            }
        }

        #endregion

        #region Другие

        private void MainForm_Resize(object sender, EventArgs e)
        {
            WatchMimikrie();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            WatchUp();
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Debug) _watch.Visible = Visible;
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            WatchMimikrie();
        }


        private void MainForm_Activated(object sender, EventArgs e)
        {
           // if (Debug) _watch.Show();
        }

        private void CreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!IsNowConnected && !_isNowConnecting) new RegistrationForm(_watch).ShowDialog();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DoLogin();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DoLogin();
        }

        private void UserView_SizeChanged(object sender, EventArgs e)
        {
            if (IsOnLine()) UserView_SetBackground();
        }

        private enum UserViewState
        {
            NoContacts,
            Normal
        }

        private UserViewState _userViewStateFlag = UserViewState.NoContacts;

        private void UserView_SetBackground()
        {
            try
            {
                var bmp = new Bitmap(UserView.Width, UserView.Height);
                var src = _userViewStateFlag == UserViewState.NoContacts ? new Bitmap(Resources.UserView_Nocontacts) : new Bitmap(Resources.UserView_Work);
                var g = Graphics.FromImage(bmp);
                g.DrawImage(src,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    new Rectangle(0, 0, src.Width, src.Height),
                    GraphicsUnit.Pixel
                );
                UserView.BackgroundImage = bmp;
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        #endregion

        #endregion

        #endregion

        #region Операции над формой

        private void HideThis()
        {
            Visible = false;

            TrayShowWindow.Text = @"Show Messenger";
        }

        private void ShowThis()
        {
            Visible = true;

            TrayShowWindow.Text = @"Hide Messenger";
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
#if !DEBUG
            DialogResult res = MessageBox.Show("Завершить работу мессенжера?",
                            "Диалог выхода",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
#endif

#if !DEBUG
            if (res == DialogResult.Yes)
            {
#endif

            _cancelClose = false;
            if (MChatIsRun)
            {
                _mainChat.Show();
                _mainChat.CancelClose = false;
            }

            if (_findFormIsRun) _findUserForm.Close();

            _opt?.Close();
            _alertForm?.Close();

            if (IsOnLine())
            {
                _connection.ShutDown();

                Enabled = false;

                Thread.Sleep(100);
            }


            Application.Exit();
#if !DEBUG
            }
#endif
        }

        #endregion

        #region Операции с Защитной Панелью

        ///////////////////////////////////////////////

        private int _protectionPanelLeft;
        private Thread _pullOutThread;
        private Thread _pushThread;

        private bool PullOutThreadVerify()
        {
            if (_pullOutThread != null)
                if (_pullOutThread.IsAlive)
                {
#if DEBUG
                    Report.EnError("this thread (PullOut) is working now");
#endif
                    return false;
                }

            return true;
        }

        private bool PushThreadVerify()
        {
            if (_pushThread != null)
                if (_pushThread.IsAlive)
                {
#if DEBUG
                    Report.EnError("this thread (Push) is working now");
#endif
                    return false;
                }

            return true;
        }

        /// <summary>
        ///    to pull out the protection panel
        /// </summary>
        private void ProtectionPanelPullOut()
        {
            if (_protectionPanelIsOpen) return;
            if (!PullOutThreadVerify()) return;
            _pullOutThread = new Thread(DoProtectionPanelPullOut);
            _pullOutThread.Start();
        }

        private bool _protectionPanelIsOpen = true;

        private void DoProtectionPanelPullOut()
        {
            try
            {
                _pushThread?.Join();
                ProtectionPanel.Visible = true;

                if (!IsProtectionDissolve)
                {
                    for (var iter = 0; ProtectionPanel.Left != _protectionPanelLeft; iter++)
                    {
                        PullOut.Enabled = false;
                        Push.Enabled = false;

                        ProtectionPanel.Left += 1;

                        if (iter % 10 == 0)
                            for (var i = 0; i < ProtectionPanel.Controls.Count; i++)
                                ProtectionPanel.Controls[i].Left += 1;

                        Thread.Sleep(1);
                    }
                }
                else
                {
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd7;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd6;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd5;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd4;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd3;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd2;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd1;
                    Thread.Sleep(50);
                }

                btnLogin.Enabled = true;
                Push.Enabled = true;
                _protectionPanelIsOpen = true;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "return DoProtectionPanelPullOut in MainForm.cs", Debug);
            }
        }


        /// <summary>
        ///     Задвинуть защитную панель
        /// </summary>
        private void ProtectionPanelPush()
        {
            if (!_protectionPanelIsOpen) return;
            if (!PushThreadVerify()) return;
            _pushThread = new Thread(DoProtectionPanelPush);
            _pushThread.Start();
        }

        private readonly bool IsProtectionDissolve = true;

        private void DoProtectionPanelPush()
        {
            try
            {
                _pullOutThread?.Join();
                if (!IsProtectionDissolve)
                {
                    _protectionPanelLeft = ProtectionPanel.Left;

                    for (var i = 0; ProtectionPanel.Right > 0; i++)
                    {
                        PullOut.Enabled = false;
                        Push.Enabled = false;

                        ProtectionPanel.Left -= 1;
                        if (i % 10 == 0)
                            for (var j = 0; j < ProtectionPanel.Controls.Count; j++)
                                ProtectionPanel.Controls[j].Left -= 1;

                        Thread.Sleep(1);
                    }
                }
                else
                {
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd1;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd2;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd3;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd4;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd5;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd6;
                    Thread.Sleep(50);
                    ProtectionPanel.BackgroundImage = Resources.mianbgnd7;
                    Thread.Sleep(50);
                }

                btnLogin.Enabled = true;

                PullOut.Enabled = true;
                _protectionPanelIsOpen = false;
                ProtectionPanel.Visible = false;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "return DoProtectionPanelPush in MainForm.cs", Debug);
            }
        }

        #endregion

        #region Сетевое взаимодействие

        #region Прием сообщений

        private ClientConnection _connection;
        public Hashtable UserList = new Hashtable();

        private void OnReceive(ClientConnection sender, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnReceive(sender, message)));
                return;
            }

            try
            {
                WatchReceive(message);

                var messSplit = message.Split('|');
                Messages serverMessage;
                try
                {
                    serverMessage = GetMessages(messSplit[0]);
                }
                catch (Exception e)
                {
                    ErrorsProc.WriteErrorToLog(e, "");
                    return;
                }
                
                switch (serverMessage)
                {
                    case Messages.Server:
                        if (MChatIsRun) _mainChat.ChatAddString("Сообщение сервера: " + messSplit[1]);
                        break;
                    case Messages.Alert:
                        ShowAlertForm(messSplit);
                        break;
                    //the authorization was successful
                    case Messages.Attached:
                        AttachedEvent?.Invoke();
                        break;
                    case Messages.Chat:
                        if (MChatIsRun) _mainChat.ChatAddString(messSplit[1]);
                        break;
                    case Messages.Listusers:
                        UserList.Clear();
                        for (var i = 1; i < messSplit.Length; i++)
                        {
                            var messSplit2 = messSplit[i].Split('&');
                            var additional = new ArrayList();
                            for (var j = 1; j < messSplit2.Length; j++) additional.Add(messSplit2[j]);

                            UserList.Add(messSplit2[0], additional);
                        }

                        UpdateUserList();
                        break;
                    case Messages.RegistrationFailed:
                        break;
                    case Messages.RegistrationFailedDefault:
                        break;
                    case Messages.RegistrationFailedLoginAlreadyExist:
                        break;
                    case Messages.RegistrationVerifydataError:
                        break;
                    case Messages.Refuse:
                        if (MChatIsRun)
                        {
#if DEBUG
                            _mainChat.ChatAddString(@"Вернулся мусор :)");
#endif
                        }

                        break;
                    case Messages.WasAttached:
                        ProgressThreadTerminate(@"Отсоеденён");
                        _connection.ShutDown();
                        Report._Information(
                            @"Пользователь с таким логином и паролем уже был авторизован \nПовторная авторизация невозможна");
                        break;
                    case Messages.WasRegister:
                        break;
                    case Messages.RegistrationPassed:
                        break;
                    case Messages.Userlost:
                        if (MChatIsRun) MChatItemRemove(messSplit[1]);
                        break;
                    case Messages.MchatEnterPassed:
                        MChatShow();
                        sender.SendMessage(ClientConnection.Messages.Listusers);
                        break;
                    case Messages.MchatExit:
                        MChatClose();
                        break;
                    case Messages.MchatEnterFailed:
                        Report._Information(@"сейчас невозможно войти в главный чат");
                        MChatIsRun = false;
                        SwitchMChatLoginVisible();
                        break;
                    //сервер сообщает что он жив
                    case Messages.ServerAlive:
                        //теперь необходимо авторизоваться
                        ConnectedEvent?.Invoke();
                        break;
                    case Messages.AutorizeFailedWrongPassword:
                        ProgressThreadTerminate(@"Отсоеденён");
                        _connection.ShutDown();
                        Report._Warning("@Авторизация невозможна: неверный пароль");
                        break;
                    case Messages.AutorizeFailedNotRegistered:
                        ProgressThreadTerminate(@"Отсоеденён");
                        _connection.ShutDown();
                        Report._Information(@"Авторизация невозможна, так как используется не зарегистрированный логин");
                        break;
                    case Messages.AutorizeFailedServerError:
                        ProgressThreadTerminate(@"Отсоеденён");
                        _connection.ShutDown();
                        Report._Information(@"Авторизация невозможна по причине ошибки сервера");
                        break;
                    case Messages.Profile:
                        break;
                    case Messages.ServerError:
                        break;
                    case Messages.ListAllUsers:
                        FillListUsers(messSplit);
                        break;
                    case Messages.WhiteAddPass:
                        break;
                    case Messages.WhiteAddError:
                        break;
                    case Messages.WhiteAddWrong:
                        break;
                    case Messages.BlackAddWrong:
                        break;
                    case Messages.BlackAddPass:
                        break;
                    case Messages.BlackAddError:
                        break;
                    case Messages.WhiteList:
                        _whiteList.Clear();
                        for (var i = 1; i < messSplit.Length; i++) _whiteList.Add(messSplit[i]);

                        break;
                    case Messages.BlackList:
                        _blackList.Clear();
                        for (var i = 1; i < messSplit.Length; i++) _blackList.Add(messSplit[i]);

                        break;
                    case Messages.GetBwError:
                        if (_opt != null)
                        {
                            _opt.Enabled = true;
                            _opt.lblSubWarning.Visible = false;
                            _opt.lblWarning.Text = @"Произошла ошибка";
                        }
                        break;
                    case Messages.SendBwFinished:
                        if (_opt != null)
                        {
                            _opt.lstWite.Items.AddRange(_whiteList.ToArray());
                            _opt.lstBlack.Items.AddRange(_blackList.ToArray());

                            _opt.WBSinchronize();

                            _opt.Protect.Visible = false;
                            _opt.Enabled = true;
                        }
                        TryUpdateUserView();
                        break;
                    case Messages.WhiteUserState:
                        _whiteStates.Clear();
                        for (var i = 1; i < messSplit.Length; i++)
                        {
                            var dict = messSplit[i].Split('&');
                            _whiteStates.Add(dict[0], dict[1]);
                        }
                        break;
                    case Messages.BlackUserState:
                        _blackStates.Clear();
                        for (var i = 1; i < messSplit.Length; i++)
                        {
                            var dict = messSplit[i].Split('&');
                            _blackStates.Add(dict[0], dict[1]);
                        }
                        break;
                    case Messages.SendBwUserStateFinished:
                        UpdateUserView();
                        UVC_MoveUser.Enabled = true;
                        break;
                    case Messages.Disconnect:
                        ProgressThreadTerminate(@"Отсоеденён");
                        _connection.ShutDown();
                        break;
                    case Messages.AddContactPass:
                        if (_findFormIsRun)
                        {
                            _findUserForm.pnlResultsProtect.Visible = false;
                            FindFormResultsBack(messSplit, @"Пользователь успешно добавлен в контакты", Color.LightGreen,
                                Color.Black);
                        }
                        else if (_addUserFormIsRun)
                        {
                            _addContactForm.lblInfo.Text = @"Пользователь был добавлен в контакты";
                            _addContactForm.lblInfo.ForeColor = Color.Lime;
                            _addContactForm.lblSubInfo.Text = string.Empty;
                            _addContactForm.btnCloseForce.Text = @"Закрыть";
                        }

                        break;
                    case Messages.AddContactWrong:
                        if (_findFormIsRun)
                        {
                            _findUserForm.pnlResultsProtect.Visible = false;
                            FindFormResultsBack(messSplit,
                                @"Пользователь не был добавлен в контакты(возможно он был добавлен ранее)",
                                Color.Cornsilk, Color.Black);
                        }
                        else if (_addUserFormIsRun)
                        {
                            _addContactForm.lblInfo.Text = @"Пользователь не добавлен в контакты";
                            _addContactForm.lblInfo.ForeColor = Color.Red;
                            _addContactForm.lblSubInfo.Text = @"Возможно он был добавлен ранее";
                            _addContactForm.btnCloseForce.Text = @"Закрыть";
                        }

                        break;
                    case Messages.Private:
                        PrivateProcessing(messSplit[1], messSplit[2], messSplit[3], messSplit[4], messSplit[5]);
                        break;
                    case Messages.Email:
                        Process.Start("mailto:" + messSplit[1]);
                        break;
                    case Messages.EmailAps:
                        Report._Information("Отправка почты данному пользователю сейчас не возможна");
                        break;
                    case Messages.MchatBan:
                        MChatClose();
                        Report._Information(
                            $"Вход в главный чат невозможен\n\nВаш логин заблокирован Администрацией чата\n\nПо причине: {messSplit[1]}\n\nВаш логин будет разблокирован: {messSplit[2]}");
                        break;
                    default:
                        Report.Warning($"server say:{message}, but it haven't any handler for it");
                        break;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "TreatmentMessage in MainForm.cs", Debug);
            }
        }

        #endregion

        #region Списки пользователей

        private Hashtable UserDataSplit(string[] data)
        {
            try
            {
                var allUsers = new Hashtable();
                for (var i = 1; i < data.Length; i++)
                {
                    var subData = data[i].Split('&');
                    var additional = new ArrayList();

                    for (var j = 1; j < subData.Length; j++) additional.Add(subData[j]);
                    //            логин        инфа аккаунта
                    allUsers.Add(subData[0], additional);
                }

                return allUsers;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, @"UserDataSplit in MainForm.cs", Debug);
                return null;
            }
        }

        private void FillListUsers(string[] data)
        {
            try
            {
                if (_findFormIsRun)
                {
                    var allUsers = UserDataSplit(data);
                    _findUserForm.Results.Items.Clear();
                    foreach (DictionaryEntry user in allUsers)
                    {
                        var arr = (ArrayList) user.Value;

                        if (string.Compare(user.Key.ToString(), OtherUsers, StringComparison.OrdinalIgnoreCase) != 0)
                            _findUserForm.Results.Items.Add(user.Key.ToString()).SubItems
                                .AddRange((string[]) arr.ToArray(typeof(string)));
                    }

                    _findUserForm._SelectTab(1);
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, @"FillListUsers in MainForm.cs", Debug);
            }
        }

        private void UpdateUserList()
        {
            try
            {
                if (!MChatIsRun) return;

                // удаление элемента из листконтрола главного чата, если присланный список его не содержит 
                for (var i = 0; i < _mainChat.UserList.Items.Count; i++)
                    if (!UserList.Contains(_mainChat.UserList.Items[i].Text))
                    {
                        _mainChat.UserList.Items[i].Remove();
                        i--;
                    }

                // добавление новых элементов
                foreach (string key in UserList.Keys)
                    if (!MChatFindItem(key))
                        _mainChat.UserList.Items.Add(key).SubItems
                            .AddRange((string[]) ((ArrayList) UserList[key]).ToArray(typeof(string)));
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, @"UpdateUserList in MainForm.cs", Debug);
            }
        }

        public bool MChatFindItem(string item)
        {
            if (!MChatIsRun) return false;

            for (var i = 0; i < _mainChat.UserList.Items.Count; i++)
                if (_mainChat.UserList.Items[i].Text == item)
                    return true;

            return false;
        }

        public void MChatItemRemove(string item)
        {
            if (!MChatIsRun) return;

            for (var i = 0; i < _mainChat.UserList.Items.Count; i++)
                if (_mainChat.UserList.Items[i].Text == item)
                {
                    _mainChat.UserList.Items[i].Remove();

                    return;
                }
        }

        #endregion

        #region STATE OPERATIONS

        

        private void SendState(State state)
        {
            if (IsOnLine()) _connection.SendMessage(ClientConnection.Messages.State, Enum.GetName(typeof(State), state));
        }

       

        private readonly ArrayList _blackList = new ArrayList();
        private readonly ArrayList _whiteList = new ArrayList();

        private readonly Hashtable _blackStates = new Hashtable();
        private readonly Hashtable _whiteStates = new Hashtable();

        private void TryUpdateUserView()
        {
            if (IsOnLine()) _connection.SendMessage(ClientConnection.Messages.GetBwState, 50);
        }

        private enum GroupType
        {
            White=0,
            Black=1
        }
        private void UpdateStates(Hashtable statesHashtable,GroupType groupType)
        {
            foreach (DictionaryEntry item in statesHashtable)
            {
                var login = item.Key.ToString();
                var state = (State) Enum.Parse(typeof(State), item.Value.ToString());

                if (string.Compare(login, OtherUsers, StringComparison.Ordinal) == 0) continue;

                PrivateVerify(login, state);
                var userListViewIndex = UserViewContain(login, groupType);

                if (userListViewIndex == -1)
                {
                    var li = UserView.Items.Add(login);
                    li.SubItems.Add(state.GetDescription()).Tag = state;
                    li.Group = GetListViewGroup(groupType);
                }
                else // update
                {
                    var si = UserView.Items[userListViewIndex].SubItems[1];
                    if (state != (State)si.Tag)
                    {
                        if (DoesUserAppearFromOffLineRightNow((State)si.Tag, state)) UserCame(login);
                        si.Text = state.GetDescription();
                        si.Tag = state;
                    }
                }
            }
        }

        private void UpdateStates()
        {
            UpdateStates(_whiteStates, GroupType.White);
            UpdateStates(_blackStates, GroupType.Black);
        }
        private int UserViewContain(string userName, GroupType group)
        {
            foreach (ListViewItem item in UserView.Items)
                if (string.Compare(item.Text, userName, StringComparison.Ordinal) == 0)
                {
                    if (item.Group == GetListViewGroup(group))
                        return item.Index;
                    return -1;
                }

            return -1;
        }

        void DeleteOldStates()
        {
            foreach (ListViewItem item in UserView.Items)
                if (item.Group == GetListViewGroup(GroupType.White))
                {
                    if (!_whiteStates.Contains(item.Text)) item.Remove();
                }
                else
                {
                    if (!_blackStates.Contains(item.Text)) item.Remove();
                }
        }

        private void UpdateUserView()
        {
            DeleteOldStates();
            UpdateStates();
            SwitchBackground(UserView.Items.Count == 0 ? UserViewState.NoContacts : UserViewState.Normal);
        }

        void SwitchBackground(UserViewState toState)
        {
            var oldState = toState == UserViewState.Normal ? UserViewState.NoContacts : UserViewState.Normal;
            if (_userViewStateFlag == oldState)
            {
                _userViewStateFlag = toState;
                UserView_SetBackground();
            }
        }

        private bool DoesUserAppearFromOffLineRightNow(State old, State now)
        {
            return (old == State.Off || old == State.Invisible) && now == State.OnLine;
        }

        private void PrivateVerify(string login, State state)
        {
            try
            {
                foreach (var item in _privats)
                {
                    var pvt = (PrivateForm) item;

                    if (string.Compare(pvt.Interlocutor, login, StringComparison.Ordinal) == 0)
                    {
                        switch (state)
                        {
                            case State.Off:
                                pvt.SwitchToDisconnectState("Пользователь не может принять сообщения т.к. он отключён");
                                break;
                            case State.Invisible:
                                pvt.SwitchToDisconnectState(
                                    "Пользователь не хочет принять сообщения т.к. установил что он отключён");
                                break;
                            case State.OnLine:
                                pvt.EnableInterface();
                                break;
                            case State.Busy:
                            case State.Away:
                            case State.ComeBackSoon:
                            case State.Lunch:
                            case State.BadMood:
                            case State.Lahac:
                                pvt.EnableInterface();
                                pvt.ShowInformation(
                                    $@"Пользователь не может ответить, т.к. установил состояние {Enum.GetName(typeof(State), state)}");
                                break;
                        }
                    }
                        
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "PrivateVerify in MainForm.cs", Debug);
            }
        }

        #endregion

        #region Интерфейс подключения

        /// <summary>
        ///     Выключить всё кроме исключений(MM_ExceptionsEnable)
        /// </summary>
        public void MM_DisableWithOut(bool disable)
        {
            MainMenuEnumerate(MainMenu.Items, disable);
            MM_ExceptionsEnable(true);
        }

        private void MainMenuEnumerate(ToolStripItemCollection itemC, bool disable)
        {
            for (var i = 0; i < itemC.Count; i++)
                try
                {
                    if (!(itemC[i] is ToolStripMenuItem item)) continue;
                    if (item.HasDropDownItems) MainMenuEnumerate(item.DropDownItems, disable);

                    if (!string.IsNullOrEmpty(item.Name) && item.Name[item.Name.Length - 1] != '0')
                        item.Enabled = !disable;
                }
                catch (Exception)
                {
                    if (Debug) throw;
                }

            try
            {
                Tray_MChat_Login.Enabled = !disable;
                TC_State.Enabled = !disable;
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        private void MM_ExceptionsEnable(bool enable)
        {
            MM_ShutDown.Enabled = enable;
            MM_Topmost.Enabled = enable;
            MM_ShowLog.Enabled = enable;
            MM_Hide.Enabled = enable;
            MM_About.Enabled = enable;
            MM_Params.Enabled = enable;

            if (Debug)
            {
                MM_Collect.Enabled = true;
                MM_Collect.Visible = true;
            }
        }

        private void SwitchToDisconnectedMainForm()
        {
            if (IsNowConnected)
            {
                MainChatClose();
                ProtectionPanelPullOut();
                FindFormClose();
                AddContactFormClose();

                MM_DisableWithOut(true);
            }
        }

        /// <summary>
        ///     Безопасное закрытие окна Главного чата
        /// </summary>
        private void MainChatClose()
        {
            if (MChatIsRun)
            {
                _mainChat.Show();

                MChatIsRun = false;

                _mainChat.CancelClose = false;
                _mainChat.Close();
            }
        }

        #endregion

        #endregion

        #region Авторизация на сервере

        private ParamsStruct _ps;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            try
            {
                // действует как кнопка ВОЙТИ
                if (!_isNowConnecting)
                {
                    if (Login.Text != "" && Password.Text != "")
                    {
                        _ps = Parametres.Load();

                        AuthorizeOnServer();
                    }
                    else
                    {
                        MessageBox.Show(@"Введите логин и пароль", @"Messenger", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                } // действует как кнопка ОТМЕНА
                else
                {
                    ConnectingCancel();
                }
            }
            catch (Exception e)
            {
                if (Debug) throw;
                ErrorsProc.WriteErrorAndMessage(e, "DoLogin in MainForm.cs", Debug);
            }
        }

        private void ConnectingCancel()
        {
            try
            {
                ProgressThreadTerminate("Отсоеденён");
                ConnectInterfaceEnable(true);

                if (IsNowConnected) _connection.ShutDown();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "AuthorizeOnServer in MainForm.cs", Debug);
            }
            finally
            {
                if (ConnectTimer.Enabled) ConnectTimer.Stop();
                btnLogin.Enabled = true;
            }
        }

        private void AfterConnectingClear()
        {
            try
            {
                ProgressThreadTerminate("Отсоеденён");
                ConnectInterfaceEnable(true);
                UserView.Items.Clear();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "AfterConnectingClear in MainForm.cs", Debug);
            }
            finally
            {
                if (ConnectTimer.Enabled) ConnectTimer.Stop();
                btnLogin.Enabled = true;

                try
                {
                    UserView.BackgroundImage = null;
                }
                catch (Exception)
                {
                    if (Debug) throw;
                }
            }
        }

        private void AuthorizeOnServer()
        {
            try
            {
                if (!BeginConnectToServer()) ConnectingCancel();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "AuthorizeOnServer in MainForm.cs", Debug);
            }
        }

        private bool _isNowConnecting;

        private void ConnectInterfaceEnable(bool enable)
        {
            if (enable)
            {
                btnLogin.Text = @"Войти";
                _isNowConnecting = false;
            }
            else
            {
                btnLogin.Text = @"Отмена";
                _isNowConnecting = true;
            }

            Login.Enabled = enable;
            Password.Enabled = enable;
            SavePassword.Enabled = enable;
        }

        public bool BeginConnectToServer()
        {
            try
            {
                ConnectInterfaceEnable(false);
                ConnectTimer.Start();
                _progressThread = new Thread(DoConnectProgress);
                _progressThread.Start();
                return true;
            }
            catch (Exception e)
            {
                if (LogsWrite) ErrorsProc.WriteErrorAndMessage(e, "return BeginConnectToServer in MainForm.cs", Debug);
                return false;
            }
        }

        private Thread _progressThread;

        private readonly string[] _progressText =
        {
            "", ".", "..", "...", "....", ".....", "......", ".......", "........", "........", ".........",
            "..........", "..........."
        };

        private void DoConnectProgress()
        {
            while (true)
                foreach (var t in _progressText)
                    try
                    {
                        StatusInfo.Text = @"Соединение " + t;

                        Thread.Sleep(150);
                    }
                    catch (Exception e)
                    {
                        ErrorsProc.WriteErrorToLog(e,"");
                    }
            // ReSharper disable once FunctionNeverReturns
        }

        private void ProgressThreadTerminate(string statusInfo)
        {
            if (_progressThread != null)
                if (_progressThread.IsAlive)
                {
                    _progressThread.Abort();
                    _progressThread = null;
                }

            StatusInfo.Text = statusInfo;
        }

        #endregion

        #region Обработка событий подключения

        private void OnDisconnect(ClientConnection sender, ClientConnection.DisconnectReason reason)
        {
            try
            {
                if (_connection != null)
                {
                    sender.Close();
                    _connection = null;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "OnDisconnect() in MainForm.cs", Debug);
            }
            finally
            {
                if (_cancelClose)
                {
                    MainChatClose();
#warning why does it have to switch any states after disconnecting? (comment)
                    // CheckItemInAllStateContainers(State.Invisible);
                    PrivatesBlocking(true);
                    SwitchToDisconnectedMainForm();
                    AfterConnectingClear();
                }

                IsNowConnected = false;
            }
        }

        private void OnMessageSend(ClientConnection sender, string message)
        {
            try
            {
                WatchSend(message);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "OnMessageSend() in MainForm.cs", Debug);
            }
        }

        public delegate void Attached();

        public event Attached AttachedEvent;

        private void OnAttached()
        {
            Thread.Sleep(10);
            ProgressThreadTerminate("Присоеденён");

            _connection.IsNowAttached = true;

            ProtectionPanelPush();

            ConnectInterfaceEnable(true);
            MM_DisableWithOut(false);

            CheckItemInAllStateContainers(State.OnLine);
            PrivatesBlocking(false);

            Text = @"Messenger " + @"<" + Login.Text + @">";

            _userViewStateFlag = UserViewState.NoContacts;
            UserView_SetBackground();
        }

        public delegate void Connected();

        public event Connected ConnectedEvent;

        private void OnConnected()
        {
            IsNowConnected = true;
            btnLogin.Enabled = false;
            _connection.SendMessage(ClientConnection.Messages.Connect, Login.Text, Password.Text);
        }

        private void DoConnect(object sender, EventArgs e)
        {
            var ip = IPAddress.Parse(_ps.ServerIp);
            var port = _ps.Port;
            try
            {
                ConnectTimer.Stop();
                _connection?.Close();
                _connection = new ClientConnection(ip, port);
                _connection.Receive += OnReceive;
                _connection.DisconnectEvent += OnDisconnect;
                _connection.SendMessageEvent += OnMessageSend;
                _connection.SendMessage(ClientConnection.Messages.YouAlive);
            }
            catch (Exception exception)
            {
                ErrorsProc.WriteErrorToLog(exception, "DoConnect() in MainForm.cs");
                ConnectTimer.Start();
            }
        }

        public void SendMessage(ClientConnection.Messages message, params string[] additional)
        {
            if (IsNowConnected) _connection.SendMessage(message, additional);
        }

        #endregion

        #region Форма добавления контакта

        private AddContact _addContactForm;

        private void MM_Add_Contact_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddContact()
        {
            _addContactForm = new AddContact();

            _addContactForm.GoToFind.Click += GoToFind_Click;
            _addContactForm.FormClosed += _AddContactForm_FormClosed;
            _addContactForm.Add.Click += AddContact_AddClick;
            _addContactForm.btnCloseForce.Click += AddContact_CloseForce;
            _addContactForm.LoginToAdd.KeyDown += AddContact_LoginToAdd_KeyDown;

            _addContactForm.TopMost = true;
            _addUserFormIsRun = true;

            _addContactForm.ShowDialog();
        }

        private void AddContact_LoginToAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DoAddContact();
        }

        private void AddContact_CloseForce(object sender, EventArgs e)
        {
            _addContactForm.Close();
        }

        private void AddContact_AddClick(object sender, EventArgs e)
        {
            DoAddContact();
        }

        private void DoAddContact()
        {
            var login = _addContactForm.LoginToAdd.Text;
            if (string.IsNullOrEmpty(login))
            {
                Report.Information("Login can't be empty");
                return;
            }

            if (string.Compare(login, "Другие", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Report.Information("Логин не может быть 'Другие'");
                return;
            }

            _addContactForm.ProtectPanel.Visible = true;
            SendMessage(ClientConnection.Messages.AddContact, login);
        }

        private void _AddContactForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _addUserFormIsRun = false;
        }

        private void AddContactFormClose()
        {
            if (_addUserFormIsRun) _addContactForm.Close();
        }

        private void GoToFind_Click(object sender, EventArgs e)
        {
            ShowFindForm();
            _addContactForm.Close();
        }

        #endregion

        #region Форма поиска контакта

        private FindUserForm _findUserForm;

        private void FindFormResultsBack(string[] data, string message, Color back, Color fore)
        {
            if (data.Length > 1)
                for (var i = 1; i < data.Length; i++)
                {
                    var li = _findUserForm.ResultsBackView.Items.Add(data[i]);
                    li.SubItems.Add(message);
                    li.ForeColor = fore;
                    li.BackColor = back;
                }
        }

        private void FindFormClose()
        {
            if (_findFormIsRun) _findUserForm.Close();
        }

        private void ShowFindForm()
        {
            if (!_findFormIsRun)
            {
                _findUserForm = new FindUserForm();
                _findUserForm.btnGetAll.Click += btnGetAll_Click;
                _findUserForm.AddToContacts.Click += AddToContacts_Click;
                _findUserForm.FormClosed += _FindUserForm_Closed;
                _findUserForm.FindClickEvent += OnFindClick;
                _findUserForm.Show();

                _findFormIsRun = true;
            }
            else
            {
                _findUserForm.TopMost = true;
            }
        }

        private void OnFindClick(string[] criteries)
        {
            _connection.SendMessage(ClientConnection.Messages.FindUser, criteries);
        }

        private bool _findFormIsRun;
        private bool _addUserFormIsRun;

        private void _FindUserForm_Closed(object sender, FormClosedEventArgs e)
        {
            _findFormIsRun = false;
        }

        private void AddToContacts_Click(object sender, EventArgs e)
        {
            var logins = new ArrayList();
            foreach (ListViewItem item in _findUserForm.Results.SelectedItems) logins.Add(item.Text);
            _connection.SendMessage(ClientConnection.Messages.AddContact, (string[]) logins.ToArray(typeof(string)));

            _findUserForm.ResultsBackView.Items.Clear();
            _findUserForm.ResultContainer.Panel2Collapsed = false;
            _findUserForm.pnlResultsProtect.Visible = true;
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            _connection.SendMessage(ClientConnection.Messages.GetAllUsers);
        }

        #endregion

        #region Форма Системы оповещения

        private Alert _alertForm;
        private Thread _alertFormThread;

        private void ShowAlertForm(string[] data)
        {
            try
            {
                if (_alertFormThread == null)
                {
                    var arr = new ArrayList();
                    arr.AddRange(data);

                    _alertFormThread = new Thread(DoAlertFormShow) {IsBackground = true};
                    _alertFormThread.Start(arr);
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "ShowAlertForm(string[] data) in MainForm.cs", Debug);
            }
        }

        private void DoAlertFormShow(object array)
        {
            var arr = (ArrayList) array;
            var data = (string[]) arr.ToArray(typeof(string));

            _alertForm.ClearList();
            for (var i = 1; i < data.Length; i++) _alertForm.AddGuest(data[i]);
            if (!_alertForm.Visible) _alertForm.Visible = true;
            _alertFormThread = null;
        }

        private void OnAlertOk(object sender, EventArgs e)
        {
            if (IsOnLine())
            {
                if (_alertForm.Guests.Length != 0)
                    _connection.SendMessage(ClientConnection.Messages.ToWhite, _alertForm.Guests);
                else
                    _connection.SendMessage(ClientConnection.Messages.GetBwState);
            }

            _alertForm.Hide();
        }

        private void OnAlertCancel(object sender, EventArgs e)
        {
            if (IsOnLine()) _connection.SendMessage(ClientConnection.Messages.GetBwState);
            _alertForm.Hide();
        }

        private void OnAlertFormClosed(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancelClose;
            if (_cancelClose) _alertForm.Hide();
        }

        private void AlertFormInitialize()
        {
            HackAlertForm();
            SplashStep();
            _alertForm.Show();
            SplashStep();
            _alertForm.Visible = false;
            RecoverAlertForm();
            SplashStep();
        }

        private void HackAlertForm()
        {
            _alertForm.Width = 0;
            _alertForm.Height = 0;
            _alertForm.Opacity = 0;
            _alertForm.ShowInTaskbar = false;
        }

        private void RecoverAlertForm()
        {
            _alertForm.Width = _alertForm._width;
            _alertForm.Height = _alertForm._height;
            _alertForm.Opacity = 1;
            _alertForm.ShowInTaskbar = true;
        }

        #endregion

        #region Форма Опции

        private void ShowParamsForm()
        {
            // заглушка
            if (_opt != null)
            {
                _opt.TopMost = true;
                _opt.TopMost = false;
                return;
            }

            _opt = new Options(_watch, IsOnLine()) {Login = Login.Text, Password = Password.Text};


            _opt.WhiteListReadyEvent += opt_WhiteListReadyEvent;
            _opt.BlackListReadyEvent += opt_BlackListReadyEvent;
            _opt.FormClosed += opt_FormClosed;
            _opt.btnShowWatch.Click += opt_ShowWatch;

            if (IsOnLine())
            {
                _opt.Protect.Visible = true;
                _connection.SendMessage(ClientConnection.Messages.GetBw);
            }
            else
            {
                _opt.Protect.Visible = false;
            }

            _opt.Show();
        }

        private void opt_FormClosed(object sender, FormClosedEventArgs e)
        {
            _opt = null;
        }

        private void opt_BlackListReadyEvent(ArrayList blackList)
        {
            _connection.SendMessage(ClientConnection.Messages.ToBlack, (string[]) blackList.ToArray(typeof(string)));
        }

        private void opt_WhiteListReadyEvent(ArrayList whiteList)
        {
            _connection.SendMessage(ClientConnection.Messages.ToWhite, (string[]) whiteList.ToArray(typeof(string)));
        }

        private void opt_ShowWatch(object sender, EventArgs e)
        {
            try
            {
                Debug = true;
                if (_watch == null) WatchFormCreate();
                _watch.Visible = true;
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        #endregion

        #region Watch Form

        private Watch _watch;

        private void WatchReceive(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => WatchReceive(message)));
                return;
            }
            _watch?.Receive.Items.Add(message);
        }

        private void WatchSend(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => WatchSend(message)));
                return;
            }
            _watch?.Send.Items.Add(message);
        }

        private void WatchFormInitialize()
        {
            HackWatchForm();
            SplashStep();
            _watch.Show();
            SplashStep();

            _watch.Visible = false;

            RecoverWatchForm();
            SplashStep();
        }

        private void WatchFormCreate()
        {
            _watch = new Watch(this);
            HackWatchForm();
            _watch.Show();
            RecoverWatchForm();
        }

        private void HackWatchForm()
        {
            _watch.Width = 0;
            _watch.Height = 0;
            _watch.Opacity = 0;
            _watch.ShowInTaskbar = false;
        }

        private void RecoverWatchForm()
        {
            _watch.Width = Width;
            _watch.Height = Height;
            _watch.Left = Right + 1;
            _watch.Top = Top;
            _watch.Opacity = 1;
            _watch.ShowInTaskbar = true;
        }

        private void WatchMimikrie()
        {
            try
            {
                if (_watch != null)
                {
                    _watch.Left = Right + 1;
                    _watch.Top = Top;
                    _watch.Width = Width;
                    _watch.Height = Height;
                }
            }
            catch (Exception)
            {
                if (Debug) throw;
            }
        }

        private void WatchUp()
        {
            if (_watch != null)
            {
                _watch.TopMost = true;
                _watch.TopMost = false;
            }
        }

        #endregion

        #region Privats Form

        private readonly ArrayList _privats = new ArrayList();

        private void UserView_DoubleClick(object sender, EventArgs e)
        {
            SendPrivate();
        }

        ListViewGroup GetListViewGroup(GroupType groupType)
        {
            return UserView.Groups[(int)groupType];
        }
        private void SendPrivate()
        {
            try
            {
                if (UserView.SelectedItems.Count != 0)
                {
                    var userInfoItem = UserView.SelectedItems[0];
                    var userStateItem = UserView.SelectedItems[0].SubItems[1];
                    var blackGroup= GetListViewGroup(GroupType.Black);

                    if ((State)userStateItem.Tag == State.Off || userInfoItem.Group == blackGroup)
                    {
                        Report.Warning(
                            "Невозможно отправить мгновенное сообщение пользователю с состоянием 'отключён'\n или находящемуся в чёрном списке");
                    }
                    else if ((State)userStateItem.Tag == State.Invisible)
                    {
                        Report.Warning(
                            "Невозможно отправить мгновенное сообщение пользователю т.к. он установил состояние 'Off'");
                    }
                    else
                    {
                        PrivateInitialize(userInfoItem.Text);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "SendPrivate() in MainForm.cs", Debug);
            }
        }

        private void SendMail()
        {
            try
            {
                if (UserView.SelectedItems.Count != 0)
                {
                    var li = UserView.SelectedItems[0];
                    _connection.SendMessage(ClientConnection.Messages.GetEmail, li.Text);
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "SendMail() in MainForm.cs", Debug);
            }
        }

        private void MoveUser()
        {
            try
            {
                if (UserView.SelectedItems.Count != 0)
                {
                    var userInfoItem = UserView.SelectedItems[0];
                    _connection.SendMessage(
                        userInfoItem.Group == GetListViewGroup(GroupType.White)
                            ? ClientConnection.Messages.ToBlack
                            : ClientConnection.Messages.ToWhite, 
                        userInfoItem.Text);
                    UVC_MoveUser.Enabled = false;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "MoveUser() in MainForm.cs", Debug);
            }
        }

        private void PrivateInitialize(string user)
        {
            #region VerifyOnExist

            foreach (var item in _privats)
            {
                var pvt = (PrivateForm) item;
                if (String.Compare(pvt.Interlocutor, user, StringComparison.Ordinal) == 0)
                {
                    pvt.TopMost = true;
                    pvt.TopMost = false;
                    return;
                }
            }

            #endregion

            var th = new Thread(DoPrivateShow);
            th.Start(user);
        }

        /// <summary>
        ///     C начальной инициализацией
        /// </summary>
        /// <param name="data">user(string),message(string),color(Color),font(Font)</param>
        private void PrivateInitializeEx(ArrayList data)
        {
            try
            {
                #region VerifyOnExist
                foreach (var item in _privats)
                {
                    var pvt = item as PrivateForm;
                    if (string.Compare(pvt?.Interlocutor, data[0].ToString(), StringComparison.Ordinal) == 0) return;
                }

                #endregion

                var th = new Thread(DoPrivateShowEx);
                th.Start(data);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "PrivateInitializeEx in MainForm.cs", Debug);
            }
        }

        private void DoPrivateShow(object data)
        {
            try
            {
                var user = data.ToString();
                PrivateFormCreate(user);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "DoPrivateShow in MainForm.cs", Debug);
            }
        }

        /// <summary>
        ///     C начальной инициализацией
        /// </summary>
        /// <param name="dataArray">message,color,font</param>
        private void DoPrivateShowEx(object dataArray)
        {
            try
            {
                var data = (ArrayList) dataArray;
                var user = data[0].ToString();

                PrivateFormCreate(user, data[1].ToString(), (Color) data[2], (Font) data[3]);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "DoPrivateShowEx in MainForm.cs", Debug);
            }
        }


        /// <summary>
        ///     для использования в потоке только
        /// </summary>
        private void PrivateFormCreate(string user, params object[] data)
        {
            var pvt = new PrivateForm(user, Login.Text);
            if (data != null && data.Length != 0)
            {
                pvt.StartMessageNeed = true;
                pvt.StartMessage = data[0].ToString();
                pvt.StartColor = (Color) data[1];
                pvt.StartFont = (Font) data[2];
            }

            pvt.SayEvent += pvt_SayEvent;
            pvt.UserToBlackEvent += pvt_UserToBlackEvent;
            pvt.FormClosed += pvt_FormClosed;
            _privats.Add(pvt);

            Application.Run(pvt);
        }

        private void pvt_FormClosed(object sender, FormClosedEventArgs e)
        {
            _privats.Remove(sender);
        }

        private void pvt_UserToBlackEvent(string login)
        {
            _connection.SendMessage(ClientConnection.Messages.ToBlack, login);
        }

        private void pvt_SayEvent(string toUser, string tirada, Color color, string fontName, string fontSize)
        {
            if (IsOnLine())
                _connection.SendMessage(ClientConnection.Messages.Private, toUser, tirada, color.ToArgb().ToString(), fontName,
                    fontSize);
        }

        private void PrivateProcessing(string fromUser, string message, string colorArgb, string fontName,
            string fontSize)
        {
            #region ConvertParams

            Color color;
            Font font;
            try
            {
                color = Color.FromArgb(int.Parse(colorArgb));
            }
            catch
            {
                color = _ps.PChatViewForeColor;
            }

            try
            {
                font = new Font(fontName, float.Parse(fontSize));
            }
            catch
            {
                font = Parametres.GetDefault().PChatOwnerFont;
            }

            #endregion

            foreach (var item in _privats)
            {
                var pvt = (PrivateForm) item;
                if (string.Compare(pvt.Interlocutor, fromUser, StringComparison.Ordinal) == 0)
                {
                    if (!pvt.InterfaceEnabled) pvt.EnableInterface();
                    pvt.OnRecive(message, color, font);
                    return;
                }
            }

            #region Инициализация новой (первое входящее сообщение)

            var data = new ArrayList {fromUser, message, color, font};
            PrivateInitializeEx(data);

            #endregion
        }

        /// <summary>
        ///     при отсутствии соединения с сервером
        /// </summary>
        private void PrivatesBlocking(bool blocking)
        {
            PrivatesForceDisconnect(false);
            PrivatesBlocking(blocking, "В данный момент отсутствует соединение с сервером");
        }

        private void PrivatesBlocking(bool blocking, string reason)
        {
            foreach (var item in _privats)
            {
                var pvt = (PrivateForm) item;
                if (blocking)
                {
                    pvt.SwitchToDisconnectState(reason);
                }
                else
                {
                    if (!pvt.InterfaceEnabled) pvt.EnableInterface();
                }
            }
        }

        private bool PrivatesForceDisconnect(bool enable)
        {
            foreach (var item in _privats)
            {
                var pvt = item as PrivateForm;
                System.Diagnostics.Debug.Assert(pvt != null, nameof(pvt) + " != null");
                return enable ? pvt.ForceDisconnectStart() : pvt.ForceDisconnectStop();
            }

            return false;
        }

        private void PrivatesKill()
        {
            foreach (var item in _privats)
            {
                var pvt = (PrivateForm) item;
                pvt.Close();
            }
        }

        private void PrivateForceDisconnectDisable()
        {
            if (PrivatesForceDisconnect(false) && IsOnLine())
                    _connection.SendMessage(ClientConnection.Messages.GetBwState);
        }

        private void PrivateForceDisconnectEnable()
        {
            PrivatesForceDisconnect(true);
        }

        #endregion

        #region Служебные

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Login.Text = @"Lehamain";
            Password.Text = @"gecnbK`[e";
            btnLogin_Click(sender, e);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Login.Text = @"User";
            Password.Text = @"qweqwe";
            btnLogin_Click(sender, e);
        }

        #endregion

        
    }
}