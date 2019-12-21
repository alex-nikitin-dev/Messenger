using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using ServerParametresLib;
using SE= ServerExceptionLib;
namespace UserConnectionLib
{
    public delegate void Receive(UserConnection sender, string message);

    public class UserConnection
    {
        #region Конструктор

        public UserConnection(TcpClient client)
        {
#if DEBUG
            _debug = true;
#endif
            try
            {
                var ps = Parametres.Load();
                _sendDelay = ps.MessageDelay;
            }
            catch (Exception)
            {
                if (_debug)
                    throw;
            }

            CurrentState = State.OnLine;

            Client = client;
            Ip = ((IPEndPoint) Client.Client.RemoteEndPoint).Address;

            _stream = Client.GetStream();

            _stream.BeginRead(_buffer, 0, _buffer.Length, StreamReceiver, null);
        }

        #endregion

        #region поля и свойства

        public enum State
        {
            OnLine,
            Busy,
            Away
        }

        private readonly bool _debug;

        private const int BufferSize = 4096;
        private readonly int _sendDelay = 10;

        public TcpClient Client;

        public State CurrentState { get; set; }

        public ArrayList White { get; set; } = new ArrayList();

        public ArrayList Black { get; set; } = new ArrayList();


        private readonly byte[] _buffer = new byte[BufferSize];

        private readonly NetworkStream _stream;

        public event Receive Receive;

        public bool IsAttached { get; set; }

        public bool IsMChatActive { get; set; } = false;

        private string _name = "";

        public string Name
        {
            get => _name;
            set
            {
                if (_Text.IsEmpty(value)) throw new SE.ServerException(SE.ServerException.Error.EmptyUserName);
                _name = value;
            }
        }

        private string[] _dataArray;

        public string[] DataArray
        {
            get => _dataArray;
            set => _dataArray = value ?? throw new SE.ServerException(SE.ServerException.Error.EmptyDataArray);
        }

        public IPAddress Ip { get; }

        public int Id { get; private set; }

        public string FistName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Description { get; private set; }

        public string Password { get; private set; } = "";

        #endregion

        #region взаимодействие с базой пользователей

        public delegate void ReplaceUserIp(UserConnection sender, string oldIp, string newIp);

        public event ReplaceUserIp ReplaceUserIpEvent;

        public void FillData()
        {
            try
            {
                var ds = new UserDataSet.AccountDataTable();
                var adapter = new AccountTableAdapter();


                adapter.Fill(ds);
                var id = FindUserPosition(_name, ds);
                if (id == -1)
                {
                    _name = "";
                    IsAttached = false;
                    throw new _Exception(_Exception.error.WrongUserInit);
                }

                if (id > -1)
                {
                    var row = (UserDataSet.AccountRow) ds.Rows[id];
                    Id = row.Id;
                    FistName = row.Firstname;
                    LastName = row.Lastname;
                    Email = row.Email;
                    Description = row.Description;
                    Password = row.Password;

                    try
                    {
                        var oldIp = row.IP;

                        row.IP = Ip.ToString();
                        adapter.Update(ds);
                        if (string.Compare(oldIp, row.IP, StringComparison.Ordinal) != 0)
                            ReplaceUserIpEvent?.Invoke(this, oldIp, row.IP);
                    }
                    catch (Exception e)
                    {
                        ErrorsProc.WriteErrorToLog(e, "FillData (Set IP in AccountTable) in UserConnection.cs");
                    }
                }


                BW_Fill(ds);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "FillData in UserConnection.cs", true);
            }
        }

        #region Заполнение белого и чёрного списков

        /// <summary>
        ///     когда некогда разбираться с адаптарами :)
        /// </summary>
        public void WhiteListFill()
        {
            try
            {
                var wt = new UserDataSet.WhiteDataTable();
                var wa = new WhiteTableAdapter();

                var at = new UserDataSet.AccountDataTable();
                var ad = new AccountTableAdapter();


                wa.Fill(wt);
                ad.Fill(at);

                White.Clear();

                foreach (var row in wt)
                    if (row.Login == Id)
                        White.Add(at.FindById(row.Friend).Login);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "WhiteListFill in UserConnection.cs", _debug);
            }
        }

        public void WhiteListFill(UserDataSet.AccountDataTable at)
        {
            try
            {
                var wt = new UserDataSet.WhiteDataTable();
                var wa = new WhiteTableAdapter();

                wa.Fill(wt);

                White.Clear();

                foreach (var row in wt)
                    if (row.Login == Id)
                        White.Add(at.FindById(row.Friend).Login);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e,
                    "WhiteListFill(UserDataSet.AccountDataTable at) in UserConnection.cs", _debug);
            }
        }

        /// <summary>
        ///     когда некогда разбираться с адаптарами :)
        /// </summary>
        public void BlackListFill()
        {
            try
            {
                var bt = new UserDataSet.BlackDataTable();
                var ba = new BlackTableAdapter();

                var at = new UserDataSet.AccountDataTable();
                var ad = new AccountTableAdapter();


                ba.Fill(bt);
                ad.Fill(at);

                Black.Clear();

                foreach (var row in bt)
                    if (row.Login == Id)
                        Black.Add(at.FindById(row.Enemy).Login);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "BlackListFill in UserConnection.cs", _debug);
            }
        }

        public void BlackListFill(UserDataSet.AccountDataTable at)
        {
            try
            {
                var bt = new UserDataSet.BlackDataTable();
                var ba = new BlackTableAdapter();

                ba.Fill(bt);

                Black.Clear();

                foreach (var row in bt)
                    if (row.Login == Id)
                        Black.Add(at.FindById(row.Enemy).Login);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e,
                    "BlackListFill(UserDataSet.AccountDataTable at) in UserConnection.cs", _debug);
            }
        }

        public void BW_Fill()
        {
            try
            {
                // не используется BlackListFill и WhiteListFill 
                // чтобы не создавать лишних объектов AccountDataTable и AccountTableAdapter

                var wt = new UserDataSet.WhiteDataTable();
                var wa = new WhiteTableAdapter();

                var bt = new UserDataSet.BlackDataTable();
                var ba = new BlackTableAdapter();

                var at = new UserDataSet.AccountDataTable();
                var ad = new AccountTableAdapter();

                ba.Fill(bt);
                wa.Fill(wt);
                ad.Fill(at);

                White.Clear();
                Black.Clear();

                foreach (var row in wt)
                    if (row.Login == Id)
                        White.Add(at.FindById(row.Friend).Login);

                foreach (var row in bt)
                    if (row.Login == Id)
                        Black.Add(at.FindById(row.Enemy).Login);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "BW_Fill() in UserConnection.cs", _debug);
            }
        }

        public void BW_Fill(UserDataSet.AccountDataTable at)
        {
            try
            {
                WhiteListFill(at);
                BlackListFill(at);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "BW_Fill(UserDataSet.AccountDataTable at) in UserConnection.cs",
                    _debug);
            }
        }

        #endregion

/*
        private int FindUserId(string login, UserDataSet.AccountDataTable accountTable)
        {
            try
            {
                foreach (UserDataSet.AccountRow row in accountTable.Rows)
                    if (string.Compare(row.Login, login, StringComparison.OrdinalIgnoreCase) == 0)
                        return row.Id;

                return -1;
            }
            catch (Exception _E)
            {
                ErrorsProc.WriteErrorAndMessage(_E, "FindUserId in UserConnection.cs", true);
                return -2;
            }
        }
*/

        private int FindUserPosition(string login, UserDataSet.AccountDataTable accountTable)
        {
            try
            {
                for (var i = 0; i < accountTable.Rows.Count; i++)
                {
                    var row = (UserDataSet.AccountRow) accountTable.Rows[i];
                    if (string.Compare(row.Login, login, StringComparison.OrdinalIgnoreCase) == 0) return i;
                }

                return -1;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "FindUserPosition in UserConnection.cs", true);
                return -2;
            }
        }

        #endregion

        #region Сетевое взаимодействие

        public void StreamReceiver(IAsyncResult ar)
        {
            try
            {
                var countByte = _stream.EndRead(ar);
                var message = Encoding.GetEncoding(1251).GetString(_buffer, 0, countByte);

                Receive?.Invoke(this, message);
                _stream.BeginRead(_buffer, 0, _buffer.Length, StreamReceiver, null);
            }
            catch (IOException)
            {
                DisconnectEvent?.Invoke(this, DisconnectReason.Terminate);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorToLog(e.Message, "StreamReceiver in UserConnection.cs");
#if DEBUG
                MessageBox.Show(e.Message + @" return StreamReceiver in UserConnection.cs", @"Error report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
#endif
            }
        }

        public enum DisconnectReason
        {
            Default,

            /// <summary>
            ///     принудительно завершено
            /// </summary>
            Terminate,

            /// <summary>
            ///     был вызван метод ShutDown
            /// </summary>
            Shutdown
        }

        public delegate void Disconnect(UserConnection sender, DisconnectReason reason);

        /// <summary>
        ///     необходимо закрыть соединение при возникновении этого события
        /// </summary>
        public event Disconnect DisconnectEvent;

        public void CloseConnection()
        {
            try
            {
                if (Client.Client != null && Client.Client.Connected) Client.Client.Shutdown(SocketShutdown.Both);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e.Message, "CloseConnection in UserConnection.cs", _debug);
            }
        }

        /// <summary>
        ///     Этот метод ничего с сокетом не делает!!! он отправляет ДИСКОННЕКТ
        /// </summary>
        public void ShutDown()
        {
            try
            {
                SendMessage(Messages.Disconnect);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, " ShutDown() in UserConnection.cs", _debug);
            }
            finally
            {
                DisconnectEvent?.Invoke(this, DisconnectReason.Shutdown);
            }
        }

        #endregion

        #region Отправка сообщений

        public delegate void MessageSend(UserConnection sender, string message);

        public event MessageSend SendMessageEvent;

        public void SendMessage(string message)
        {
            try
            {
                Thread.Sleep(_sendDelay);
                var sw = new StreamWriter(_stream);
                sw.Write(message.Trim());
                sw.Flush();
            }
            catch (Exception e)
            {
#if DEBUG
                ErrorsProc.WriteErrorAndMessage(e, "SendMessage in UserConnection.cs", true);
                throw;
#endif
            }
            finally
            {
                SendMessageEvent?.Invoke(this, message);
//#if DEBUG
//                    _main.ChatAddString("юзеру " + _name + " отправлено сообщение: " + message);
//#endif
            }
        }

        public void SendMessage(Messages message)
        {
            SendMessage(MessagesGetString(message));
        }

        public void SendMessage(Messages message, params string[] additional)
        {
            var send = MessagesGetString(message);
            foreach (var str in additional) send += "|" + str;
            SendMessage(send);
        }

        public void SendMessage(Messages message, int delay, params string[] additional)
        {
            Thread.Sleep(delay);
            SendMessage(message, additional);
        }

        public void SendMessage(Messages message, int delay)
        {
            Thread.Sleep(delay);
            SendMessage(message);
        }

        public void SendMessage(string message, int delay)
        {
            Thread.Sleep(delay);
            SendMessage(message);
        }

        #region MESSAGES

        public enum Messages
        {
            /// <summary>
            ///     сообщение юзеру что кто-то добавил его в контакты
            /// </summary>
            Alert,

            /// <summary>
            ///     Авторизован и присоеденён
            /// </summary>
            Attached,

            /// <summary>
            ///     сообщение для главного чата
            /// </summary>
            Chat,

            /// <summary>
            ///     список всех активных пользователей главного чата
            /// </summary>
            Listusers,

            /// <summary>
            ///     неудачная регистрация
            /// </summary>
            RegistrationFailed,

            /// <summary>
            ///     неудачная регистрация по неопределённой причине
            /// </summary>
            RegistrationFailedDefault,

            /// <summary>
            ///     неудачная регистрация по причине совпадения логина.
            ///     такой логин уже существует в базе
            /// </summary>
            RegistrationFailedLoginAlreadyExist,

            /// <summary>
            ///     ошибка формирования пакета данных на клиенте
            /// </summary>
            RegistrationVerifydataError,

            /// <summary>
            ///     на сервер пришло ошибочное сообщение
            /// </summary>
            Refuse,

            /// <summary>
            ///     попытка повторной авторизации
            /// </summary>
            WasAttached,

            /// <summary>
            ///     попытка повторной регистрации в главном чате
            /// </summary>
            WasRegister,

            /// <summary>
            ///     регистрация прошла успешно(в базу добавлена запись)
            /// </summary>
            RegistrationPassed,

            /// <summary>
            ///     пользователь потерян(в случае дисконнекта)
            /// </summary>
            Userlost,

            /// <summary>
            ///     успешно вошел в главный чат
            /// </summary>
            MchatEnterPassed,

            /// <summary>
            ///     вышел из чата
            /// </summary>
            MchatExit,

            /// <summary>
            ///     невозможно войти т.к. ошибка сервера
            /// </summary>
            MchatEnterFailed,

            /// <summary>
            ///     ответ сервера что он действует
            /// </summary>
            ServerAlive,
            AutorizeFailedWrongPassword,
            AutorizeFailedNotRegistered,
            AutorizeFailedServerError,

            /// <summary>
            ///     в ответ на запрос клиента личных данных
            /// </summary>
            Profile,

            /// <summary>
            ///     для отправки ответа клиенту, что на сервере произошла ошибка
            ///     и его запрос не может быть обработан
            /// </summary>
            ServerError,

            /// <summary>
            ///     отправка списка всех зарегистрированных пользователей
            ///     в ответ на запрос GET_ALL_USERS
            /// </summary>
            ListAllUsers,

            /// <summary>
            ///     успешное добавление в белый список
            /// </summary>
            WhiteAddPass,

            /// <summary>
            ///     ошибка при добавлении в белый список
            /// </summary>
            WhiteAddError,

            /// <summary>
            ///     добавление невозможно т.к. такой пользователь уже есть в списке
            /// </summary>
            WhiteAddWrong,

            /// <summary>
            ///     добавление невозможно т.к. такой пользователь уже есть в списке
            /// </summary>
            BlackAddWrong,

            /// <summary>
            ///     успешное добавление в чёрный список
            /// </summary>
            BlackAddPass,

            /// <summary>
            ///     ошибка при добавлении в чёрный список
            /// </summary>
            BlackAddError,
            WhiteList,
            BlackList,

            /// <summary>
            ///     ошибка при отправке черного и белого списков
            /// </summary>
            GetBwError,

            /// <summary>
            ///     отправка черного и белого списков завершена
            /// </summary>
            SendBwFinished,

            /// <summary>
            ///     отправка состояний из белого  спискa
            /// </summary>
            WhiteUserState,

            /// <summary>
            ///     отправка состояний из  чёрного спискa
            /// </summary>
            BlackUserState,

            /// <summary>
            ///     отправка состояний черного и белого списков завершена
            /// </summary>
            SendBwUserStateFinished,
            Disconnect,
            AddContactPass,
            AddContactWrong,

            /// <summary>
            ///     личное сообщение: fromUser,message,colorName,fontName,fontSize
            /// </summary>
            Private,
            Email,

            /// <summary>
            ///     ошибка при получении адреса почты
            /// </summary>
            EmailAps,
            MchatBan
        }

        public static string MessagesGetString(Messages message)
        {
            return Enum.GetName(typeof(Messages), message);
        }

        #endregion

        #endregion
    }
}