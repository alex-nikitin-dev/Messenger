using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ErrorsProcessingLib;
using ParametresLib;

namespace ClientConnectionLib
{
    public delegate void Receive(ClientConnection sender, string message);

    public class ClientConnection
    {
        public ClientConnection(IPAddress serverIp, int port)
        {
#if DEBUG
            _debug = true;
#endif
            try
            {
                if (!L()) throw new Exception();
                try
                {
                    var ps = Parametres.Load();
                    _sendDelay = ps.SendDelay;
                }
                catch (Exception e)
                {
                    ErrorsProc.WriteErrorToLog(e, "ClientConnection() in ClientConnection.cs");
                }

                Port = port;
                ServerIp = serverIp;
                _client = new TcpClient();
                _client.Connect(serverIp, port);
                _stream = _client.GetStream();

                if (_stream.CanRead)
                    _stream.BeginRead(_buffer, 0, _buffer.Length, DoRead, _stream);
                else
                    throw new Exception("can't read from stream ClientConnection() in ClientConnection.cs");
            }
            catch (Exception e)
            {

                ErrorsProc.WriteErrorAndMessage(e, "ClientConnection() in ClientConnection.cs", false);
                throw;
            }
        }

        private bool L()
        {
            try
            {
                var asm = Assembly.LoadFrom(Application.ExecutablePath);

                var copyright = AssemblyCopyright(asm);
                if (string.Compare(copyright, @"Copyright © Алексей HukumuH 2006", StringComparison.Ordinal) != 0)
                    return false;
                var cmp = AssemblyCompany(asm);
                if (string.Compare(cmp, @"Алексей HukumuH", StringComparison.Ordinal) != 0) return false;
                var desc = AssemblyDescription(asm);
                if (string.Compare(desc, @"По всем вопросам обращаться lehanet@mksat.net,lehamain@yandex.ru",
                        StringComparison.Ordinal) != 0) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region поля и свойства

        #region поля

        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly bool _debug;
        private const int BufferSize = 4096;
        private readonly byte[] _buffer = new byte[BufferSize];

        #endregion

        #region Свойства

        public IPAddress ServerIp { get; }

        public int Port { get; }

        public bool IsNowAttached { get; set; }

        #endregion

        #endregion

        #region Assembly Attribute Accessors


        private string AssemblyDescription(Assembly asm)
        {
            // Get all Description attributes on this assembly
            var attributes = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Description attribute, return its value
            return ((AssemblyDescriptionAttribute) attributes[0]).Description;
        }

        private string AssemblyCopyright(Assembly asm)
        {
            // Get all Copyright attributes on this assembly
            var attributes = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
        }

        private string AssemblyCompany(Assembly asm)
        {
            // Get all Company attributes on this assembly
            var attributes = asm.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            // If there aren't any Company attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Company attribute, return its value
            return ((AssemblyCompanyAttribute) attributes[0]).Company;
        }

        #endregion

        #region Сетевое взаимодействие

        /// <summary>
        ///    have message from server
        /// </summary>
        public event Receive Receive;

        private void DoRead(IAsyncResult ar)
        {
            try
            {
                var myNetworkStream = (NetworkStream)ar.AsyncState;
                var message = "";
                int bytesCount;

                bytesCount = myNetworkStream.EndRead(ar);
                message = string.Concat(message, Encoding.GetEncoding(1251).GetString(_buffer, 0, bytesCount));
                while (myNetworkStream.DataAvailable)
                {
                    myNetworkStream.BeginRead(_buffer, 0, _buffer.Length, DoRead, myNetworkStream);
                }

                Receive?.Invoke(this, message);
                _stream.BeginRead(_buffer, 0, _buffer.Length, DoRead, _stream);
            }
            catch (IOException)
            {
                DisconnectEvent?.Invoke(this, DisconnectReason.Terminate);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, " DoRead() in ClientConnection.cs", _debug);
            }
        }

        public delegate void MessageSend(ClientConnection sender, string message);

        public event MessageSend SendMessageEvent;

        public delegate void Disconnect(ClientConnection sender, DisconnectReason reason);

        /// <summary>
        ///     Close connection while this event
        /// </summary>
        public event Disconnect DisconnectEvent;


        public void Close()
        {
            try
            {
                if (_stream != null && _client != null)
                    if (_client.Client != null && _client.Client.Connected)
                        _client.Client.Shutdown(SocketShutdown.Both);
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, " Close() in ClientConnection.cs", _debug);
            }
        }

        public enum DisconnectReason
        {
            Default,

            /// <summary>
            ///     close connection immediately
            /// </summary>
            Terminate,

            /// <summary>
            ///    call shutdown method
            /// </summary>
            Shutdown
        }

        /// <summary>
        ///    This method only send shutdown. It does nothing with socket
        /// </summary>
        public void ShutDown()
        {
            try
            {
                SendMessage(Messages.Disconnect);
            }
            catch (Exception e)
            {
                if (_debug) throw;
                ErrorsProc.WriteErrorAndMessage(e, " ShutDown() in ClientConnection.cs", _debug);
            }
            finally
            {
                DisconnectEvent?.Invoke(this, DisconnectReason.Shutdown);
            }
        }

        #endregion

        #region Отправка сообщений

        private readonly int _sendDelay = 10;

        private void SendMessage(string message)
        {
            try
            {
                Thread.Sleep(_sendDelay);
                var sw = new StreamWriter(_stream, Encoding.GetEncoding(1251));
                sw.Write(message.Trim());
                sw.Flush();
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, " SendMessage() in ClientConnection.cs", _debug);
            }
            finally
            {
                SendMessageEvent?.Invoke(this, message);
            }
        }

        public void SendMessage(Messages message, int delay)
        {
            Thread.Sleep(delay);
            SendMessage(message);
        }

        public static string MessagesGetString(Messages message)
        {
            return Enum.GetName(typeof(Messages), message);
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

        public static Messages GetMessage(string message)
        {
            return (Messages) Enum.Parse(typeof(Messages), message);
        }

        public enum Messages
        {
            /// <summary>
            ///     create new room (groupChat)
            /// </summary>
            CreateRoom,

            /// <summary>
            ///     сообщение в главный чат
            /// </summary>
            Chat,

            /// <summary>
            ///     вход в главный чат
            /// </summary>
            MchatEnter,

            /// <summary>
            ///     выход из главного чата
            /// </summary>
            MchatExit,

            /// <summary>
            ///     запрос списка юзеров
            /// </summary>
            Listusers,

            /// <summary>
            ///     запрос на подключение с авторизацией
            /// </summary>
            Connect,

            /// <summary>
            ///     запрос на отключение
            /// </summary>
            Disconnect,

            /// <summary>
            ///     запрос на регистрацию(с отправкой регистрационного пакета данных)
            /// </summary>
            Registration,

            /// <summary>
            ///     запрос о дееспособности сервера
            /// </summary>
            YouAlive,

            /// <summary>
            ///     запрос личных данных
            /// </summary>
            GetProfile,

            /// <summary>
            ///     запрос списка всех зарегистрированных пользователей
            /// </summary>
            GetAllUsers,

            /// <summary>
            ///     запрос на добавление юзеров в белый список
            /// </summary>
            ToWhite,

            /// <summary>
            ///     запрос на добавление юзеров в чёрный список
            /// </summary>
            ToBlack,

            /// <summary>
            ///     отправка критериев поиска
            /// </summary>
            FindUser,

            /// <summary>
            ///     запрос белого и чёрного списка
            /// </summary>
            GetBw,
            GetBwState,

            /// <summary>
            ///     добавление контакта первый раз
            /// </summary>
            AddContact,
            Private,

            /// <summary>
            ///     изменить состояние
            /// </summary>
            State,
            GetEmail
        }

        #endregion
    }
}

///// <summary>
/////     неудачная регистрация
///// </summary>
//RegistrationFailed,

///// <summary>
/////     неудачная регистрация по неопределённой причине
///// </summary>
//RegistrationFailedDefault,

///// <summary>
/////     неудачная регистрация по причине совпадения логина.
/////     такой логин уже существует в базе
///// </summary>
//RegistrationFailedLoginAlreadyExist,

///// <summary>
/////     регистрация прошла успешно(в базу добавлена запись)
///// </summary>
//RegistrationPassed,

///// <summary>
/////     ответ сервера что он действует
///// </summary>
//ServerAlive,