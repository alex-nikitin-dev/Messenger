using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ClientConnectionLib;
using ErrorsProcessingLib;
using ParametresLib;
using ServerMessages = ServerInterfaceLib.MessageHelper.Messages;
using ServerMessageHelper =  ServerInterfaceLib.MessageHelper;
//using TextOperations;

namespace Messenger_Client
{
    public partial class RegistrationForm : Form
    {
        public delegate void ConnectSuccess(bool ok);

        private bool _debug;
        public bool IsEdit = false;

        public string Login = "";
        public string Password = "";


        private ParamsStruct _ps;
        private readonly Watch _watch;
        private bool _cancelClose = true;
        private bool _cancelIsOk;
        private bool _closingInProcess;
        private ClientConnection _connect;

        private readonly string[] _controlsFalse;

        private readonly string[] _controlsInverse;
        private readonly string[] _controlsTrue;
        private string _resultAdd = "";
        private Color _resultColor = Color.Green;
        private string _resultMessage = "";
        private readonly int UserData_RowCount = 6;
        public bool IsThingAllowed;

        public RegistrationForm(Watch watch)
        {
            InitializeComponent();
#if DEBUG
            IsThingAllowed = true;
#else
            IsThingAllowed = false;
#endif
            _watch = watch;
            _controlsFalse = new[] {
                lblInfo.Name,
                HiddenInfo.Name,//"HiddenInfo",
                Progress.Name,//"Progress",
                lblResultInfo.Name,//"ResultInfo",
                lblResultAdditionInfo.Name//"ResultAdditionInfo"
            };
            _controlsTrue= new[] { btnCancel.Name};
            _controlsInverse = new[] {btnSendFirst.Name};
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (string.Compare(txtPassword.Text, txtConfirm.Text, StringComparison.Ordinal) != 0)
            {
                Report("Пароли не совпадают");
                txtPassword.Text = "";
                txtConfirm.Text = "";
                return;
            }

            var dt = VerifyData(txtLogin.Text, txtPassword.Text, txtFirstname.Text, txtLastname.Text, txtEMail.Text, txtDescription.Text);
            if (dt != UserData.Success)
            {
                ProcessingErrors(dt);
                return;
            }

            SendData();
        }

        private void ConnectToServer()
        {
            try
            {
                ConnectTimer.Start();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "ConnectToServer() in RegistrationForm.cs", _debug);
            }
        }

        private void connect_SendMessageEvent(ClientConnection sender, string message)
        {
            try
            {
                _watch?.Send.Items.Add(message);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "connect_SendMessageEvent() in RegistrationForm.cs", _debug);
            }
        }

        private void SendData()
        {
            Report(@"Ошибок не обнаружено", Color.Green);
            if (IsEdit)
                _connect.SendMessage(ClientConnection.Messages.Registration,
                    Login,
                    Password,
                    txtLogin.Text,
                    txtPassword.Text,
                    txtFirstname.Text,
                    txtLastname.Text,
                    txtEMail.Text,
                    txtDescription.Text);
            else
                _connect.SendMessage(ClientConnection.Messages.Registration,
                    txtLogin.Text,
                    txtPassword.Text,
                    txtFirstname.Text,
                    txtLastname.Text,
                    txtEMail.Text,
                    txtDescription.Text);
        }

        private void connect_DisconnectEvent(ClientConnection sender, ClientConnection.DisconnectReason reason)
        {
            try
            {
                if (_connect != null)
                {
                    sender.Close();
                    _connect = null;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "connect_DisconnectEvent() in RegistrationForm.cs", _debug);
            }
            finally
            {
                if (reason == ClientConnection.DisconnectReason.Terminate)
                    Close(ClosingReason.FailedConnection);
                else if (reason == ClientConnection.DisconnectReason.Default) Close(ClosingReason.Disconnect);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cancelIsOk)
            {
                base.Close();
                return;
            }

            if (ConnectTimer.Enabled) ConnectTimer.Stop();

            Close(ClosingReason.CloseButtonPress);
        }

/*
        private string Msg(ClientConnection.Messages message)
        {
            return Enum.GetName(typeof(ClientConnection.Messages), message);
        }
*/

        /// <summary>
        ///     за исключением некоторых
        /// </summary>
        /// <param name="show"></param>
        public void ShowAllControls(bool show)
        {
            var arrFalse = new ArrayList(_controlsFalse);
            var arrInverse = new ArrayList(_controlsInverse);
            var arrTrue = new ArrayList(_controlsTrue);
           
            for (var i = 0; i < Controls.Count; i++)
            {
                var name = Controls[i].Name;
                if (arrFalse.Contains(name))
                    Controls[i].Visible = false;
                else if (arrInverse.Contains(name))
                    Controls[i].Visible = !show;
                else if (arrTrue.Contains(name))
                    Controls[i].Visible = true;
                else
                    Controls[i].Visible = show;
            }
        }

        /// <summary>
        ///     Все без исключений
        /// </summary>
        /// <param name="show"></param>
        public void ShowAllControlsAdv(bool show)
        {
            for (var i = 0; i < Controls.Count; i++)
                Controls[i].Visible = show;
        }

        public event ConnectSuccess ConnectSuccessEvent;

        private void OnConnectSuccess(bool ok)
        {
            var th = new Thread(()=>ShowAllControls(ok));
            th.Start();
            RequestData();
        }

        private void ProgressThreadTerminate()
        {
            if (_progressThread != null)
                if (_progressThread.IsAlive)
                {
                    _progressThread.Abort();
                    _progressThread = null;
                }
        }

        private void connect_Receive(ClientConnection sender, string message)
        {
            try
            {
                _watch?.Receive.Items.Add(message);
                var messSplit = message.Split('|');
                ServerMessages serverMessage;
                try
                {
                    serverMessage = ServerMessageHelper.GetMessages(messSplit[0]);
                }
                catch (Exception e)
                {
                    ErrorsProc.WriteErrorToLog(e, "");
                    return;
                }
                switch (serverMessage)
                {
                    case ServerMessages.ServerAlive:
                        Thread.Sleep(500);
                        ProgressThreadTerminate();
                        Debug.Assert(ConnectSuccessEvent != null, nameof(ConnectSuccessEvent) + " != null");
                        ConnectSuccessEvent(true);
                        break;
                    case ServerMessages.RegistrationFailed:
                        Close(ClosingReason.RegistrationFailed);
                        break;
                    case ServerMessages.RegistrationFailedDefault://"REGISTRATION_FAILED_DEFAULT":
                        Close(ClosingReason.RegistrationFailedDefault);
                        break;
                    case ServerMessages.RegistrationFailedLoginAlreadyExist: //"REGISTRATION_FAILED_LOGIN_ALREADY_EXIST":
                        _closingReasonFlag = ClosingReason.RegistrationFailedLoginAlreadyExist;
                        ProcessingClosingEvent();
                        break;
                    case ServerMessages.RegistrationVerifydataError:  //"REGISTRATION_VERIFYDATA_ERROR":
                        _closingReasonFlag = ClosingReason.RegistrationVerifyDataError;
                        ProcessingClosingEvent();
                        break;
                    case ServerMessages.RegistrationPassed://"REGISTRATION_PASSED":
                        Close(ClosingReason.RegistrationPassed);
                        break;
                    case ServerMessages.Profile: //"PROFILE":
                        var arr = new ArrayList();
                        for (var i = 1; i < messSplit.Length; i++) arr.Add(messSplit[i]);
                        FillProfile(arr);
                        break;
                    case ServerMessages.ServerError://"SERVER_ERROR":
                        Report("При обработке запроса, произошла ошибка на сервере");
                        break;
                    case ServerMessages.Disconnect: //"DISCONNECT":
                        Close(ClosingReason.Disconnect);
                        break;
                    default:
                        ErrorsProc.WriteErrorAndMessage("There is an unexpected  server message: " + message,
                            "connect_Receive in RegistrationForm.cs",
                            _debug);
                        break;
                }
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "connect_Receive in RegistrationForm.cs", _debug);
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            _debug = true;
#endif
            if (IsEdit) Text = @"Изменение личных данных";

            _ps = Parametres.Load();
            IsThingAllowed = _ps.Bayda;

            ConnectSuccessEvent += OnConnectSuccess;
            ShowAllControls(false);
        }

        private void RequestData()
        {
            if (IsEdit) _connect.SendMessage(ClientConnection.Messages.GetProfile, Login, Password);
        }

        private void FillProfile(ArrayList profile)
        {
            try
            {
                if (profile.Count != UserData_RowCount)
                {
                    if (_debug)
                        MessageBox.Show(@"Данные которые прислал сервер не содержат "
                                        + UserData_RowCount
                                        + @" элементов установленные в константу UserData_RowCount"
                                        + @"return FillProfile in RegistrationForm.cs");
                    return;
                }

                txtLogin.Text = profile[0].ToString();
                txtPassword.Text = profile[1].ToString();
                txtConfirm.Text = profile[1].ToString();
                txtFirstname.Text = profile[2].ToString();
                txtLastname.Text = profile[3].ToString();
                txtEMail.Text = profile[4].ToString();
                txtDescription.Text = profile[5].ToString();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "FillProfile in RegistrationForm.cs", _debug);
            }
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancelClose;
        }

        private void Close(ClosingReason reson)
        {
            if (!_closingInProcess)
            {
                _closingInProcess = true;
                _closingReasonFlag = reson;
                var th = new Thread(ProcessingClosingEvent);
                th.Start();
                th.Join();


                ProgressThreadTerminate();
                if (!_cancelClose) DoShowResult();
            }
        }

        private int GetLeftCoord(int parentWidth, int childWidth)
        {
            return (int) Math.Round((double) (parentWidth - childWidth) / 2);
        }

        private void DoShowResult()
        {
            if (!_debug)
                if (_closingReasonFlag == ClosingReason.CloseButtonPress)
                {
                    _cancelClose = false;
                    base.Close();
                    return;
                }

            lblResultInfo.ForeColor = _resultColor;
            lblResultInfo.Text = _resultMessage;
            lblResultAdditionInfo.Text = _resultAdd;

            btnCancel.Text = @"OK";
            _cancelIsOk = true;

            lblResultInfo.Left = GetLeftCoord(Width, lblResultInfo.Width);
            lblResultAdditionInfo.Left = GetLeftCoord(Width, lblResultAdditionInfo.Width);

            ShowAllControlsAdv(false);


            lblResultInfo.Visible = true;
            lblResultAdditionInfo.Visible = true;
            btnCancel.Visible = true;
        }

        private void ProcessingClosingEvent()
        {
            var message = "";
            var add = "";
            var color = Color.Red;
            var cc = false;

            switch (_closingReasonFlag)
            {
                case ClosingReason.Unknown:
                    message = "Соединение разорвано";
                    add = "Неожиданное закрытие диалога регистрации";
                    break;
                case ClosingReason.CloseButtonPress:
                    message = "Действие было отменено пользователем";
                    if (_connect != null) _connect.ShutDown();
                    break;
                case ClosingReason.Disconnect:
                    message = !IsEdit ? "Неудачная регистрация" : "Неудачное изменение личных данных";
                    add = "соединение было принудительно разорвано сервером";
                    if (_connect != null) _connect.ShutDown();
                    break;
                case ClosingReason.FailedConnection:
                    message = !IsEdit ? "Неудачная регистрация" : "Неудачное изменение личных данных";
                    add = "Потеряно соединение с сервером";
                    break;
                case ClosingReason.RegistrationFailed:
                    message = !IsEdit ? "Неудачная регистрация" : "Неудачное изменение личных данных";
                    add = "Неожиданное сообщение сервера";
                    _connect.ShutDown();
                    break;
                case ClosingReason.RegistrationFailedDefault:
                    message = !IsEdit ? "Неудачная регистрация" : "Неудачное изменение личных данных";
                    add = "Сбой на сервере либо неверный пакет данных";
                    _connect.ShutDown();
                    break;
                case ClosingReason.RegistrationFailedLoginAlreadyExist:
                    Report("Ваш логин уже зарегистрирован. Попробуйте другой логин");
                    cc = true;
                    break;
                case ClosingReason.RegistrationVerifyDataError:
                    Report("Неверный ввод данных.Ошибка формирования пакета");
                    cc = true;
                    break;
                case ClosingReason.RegistrationPassed:
                    color = Color.Green;
                    if (!IsEdit)
                    {
                        message = "Регистрация прошла успешно";
                        add = "Теперь, чтобы авторизоваться, достаточно ввести свой логин и пароль в главном окне";
                    }
                    else
                    {
                        message = "Личные данные успешно изменены";
                        add = "изменения вступят в силу при следующей авторизации";
                    }

                    _connect.ShutDown();
                    break;
            }

            _cancelClose = cc;
            _resultColor = color;
            _resultMessage = message;
            _resultAdd = add;

        }

        private void btnSendFirst_Click(object sender, EventArgs e)
        {
            try
            {
                _progressThread = new Thread(DoProgress);
                _progressThread.Start();

                HiddenInfo.Text = @"Подождите, выполняется подключение";

                HiddenInfo.Visible = true;
                Progress.Visible = true;
                btnSendFirst.Enabled = false;

                ConnectToServer();
            }
            catch (Exception exception)
            {
                ErrorsProc.WriteErrorAndMessage(exception, "btnSendFirst_Click in RegistrationForm.cs", _debug);
            }
        }

        private void ConnectTimer_Tick(object sender, EventArgs e)
        {
            var ip = IPAddress.Parse(_ps.ServerIp);
            int port = _ps.Port;
            try
            {
                _connect = new ClientConnection(ip, port);

                _connect.Receive += connect_Receive;
                _connect.DisconnectEvent += connect_DisconnectEvent;
                _connect.SendMessageEvent += connect_SendMessageEvent;

                _connect.SendMessage(ClientConnection.Messages.YouAlive);
                ConnectTimer.Stop();
            }
            catch
            {
                #region Experimentally

                if (_connect != null)
                    ErrorsProc.WriteErrorToLog("connect != null", "ConnectTimer_Tick() in RegistrationForm.cs");
                //if (connect != null) { connect.Close(); }

                #endregion
            }
        }

        #region

        private ClosingReason _closingReasonFlag = ClosingReason.Unknown;

        public enum ClosingReason
        {
            CloseButtonPress,
            FailedConnection,
            RegistrationFailed,
            RegistrationFailedDefault,
            RegistrationFailedLoginAlreadyExist,
            RegistrationVerifyDataError,
            RegistrationPassed,
            Disconnect,
            Unknown
        }

        private void ProcessingErrors(UserData dt)
        {
            if (dt == UserData.Error) Close();

            switch (dt)
            {
                case UserData.Логин:
                    var s = string.Format("{0}{1}", "логин не может быть пустым и не должен содержать символ",
                        (char) char.GetNumericValue('&'));
                    Report(s);
                    break;
                case UserData.Пароль:
                    Report("пароль не может быть меньше 6 символов");
                    break;
                case UserData.Имя:
                    Report("имя может содержать только буквы и не может быть пустым");
                    break;
                case UserData.Фамилия:
                    Report("фамилия может содержать только буквы и не может быть пустым");
                    break;
                case UserData.Email:
                    Report("email должен соответствовать user@domain.domain");
                    break;
                case UserData.Описание:
                    Report("Описание не может быть пустым(null)");
                    break;
            }
        }

        private void Report(string error)
        {
            lblInfo.ForeColor = Color.Red;
            lblInfo.Text = error;
            lblInfo.Visible = true;
        }

        private void Report(string error, Color color)
        {
            lblInfo.ForeColor = color;
            lblInfo.Text = error;
            lblInfo.Visible = true;
        }

        public enum UserData : uint
        {
            /// <summary>
            ///     логин не может быть пустым
            /// </summary>
            Логин = 0,

            /// <summary>
            ///     пароль не может быть менее 6 символов
            /// </summary>
            Пароль,

            /// <summary>
            ///     имя может содержать только буквы
            /// </summary>
            Имя,

            /// <summary>
            ///     фамилия может содержать только буквы
            /// </summary>
            Фамилия,
            Email,
            Описание,
            Error,
            Success
        }

        /// <summary>
        ///     Проверка корректности личных данных пользователя
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private UserData VerifyData(params string[] data)
        {
            try
            {
                var rName = new Regex(@"^[A-Za-zА-Яа-я-]+$");
                var rMail = new Regex(@"^[^ @]+@[^ @]+\.[^ \.@]+$");

                for (var i = 0; i < UserData_RowCount; i++)
                    switch ((UserData) i)
                    {
                        case UserData.Логин:
                            if (String.IsNullOrEmpty(data[i])) return UserData.Логин;
                            if (data[i].Contains("&")) return UserData.Логин;
                            data[i] =data[i];
                            break;
                        case UserData.Пароль:
                            if (data[i].Length < 6) return UserData.Пароль;
                            if (data[i].Contains("&")) return UserData.Пароль;
                            break;
                        case UserData.Имя:
                            if (rName.Matches(data[i]).Count == 0) return UserData.Имя;
                            if (data[i].Contains("&")) return UserData.Имя;
                            break;
                        case UserData.Фамилия:
                            if (rName.Matches(data[i]).Count == 0) return UserData.Фамилия;
                            if (data[i].Contains("&")) return UserData.Фамилия;
                            break;
                        case UserData.Email:
                            if (rMail.Matches(data[i]).Count == 0) return UserData.Email;
                            if (data[i].Contains("&")) return UserData.Email;
                            break;
                        case UserData.Описание:
                            if (data[i] == null) return UserData.Описание;
                            if (data[i].Contains("&")) return UserData.Описание;
                            break;
                    }

                return UserData.Success;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "VerifyData in RegistrationForm.cs", _debug);
                return UserData.Error;
            }
        }

        private readonly string[] _progressText =
        {
            "", ".", "..", "...", "....", ".....", "......", ".......", "........", "........", ".........",
            "..........", "..........."
        };

        private void DoProgress()
        {
            while (true)
            {
                foreach (var item in _progressText)
                {
                    Progress.Text = item;
                    Thread.Sleep(150);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private Thread _progressThread;

        #endregion
    }
}