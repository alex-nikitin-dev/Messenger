using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ErrorsProcessingLib;
using MessengerServer.UserDataSetTableAdapters;
using TextOperations;
using ServerExceptionLib;
using ServerInterfaceLib;
using State = ClientConnectionLib.MessageHelper.State;
namespace MessengerServer
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
            Ip = (Client.Client.RemoteEndPoint as IPEndPoint)?.Address;

            _stream = Client.GetStream();
            if (_stream.CanRead)
                _stream.BeginRead(_buffer, 0, _buffer.Length, StreamReceiver, _stream);
            else
                throw new Exception("unable create UserConnection object: _stream cannot be read");
        }

        #endregion

        #region поля и свойства

        
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
                if (_Text.IsEmpty(value)) throw new ServerException(ServerException.Error.EmptyUserName);
                _name = value;
            }
        }

        private string[] _dataArray;

        public string[] DataArray
        {
            get => _dataArray;
            set => _dataArray = value ?? throw new ServerException(ServerException.Error.EmptyDataArray);
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
                    throw new ServerException(ServerException.Error.WrongUserInit);
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
                var myNetworkStream = (NetworkStream)ar.AsyncState;
                var message = "";
                int bytesCount;

                bytesCount= myNetworkStream.EndRead(ar);
                message = string.Concat(message, Encoding.GetEncoding(1251).GetString(_buffer, 0, bytesCount));
                while (myNetworkStream.DataAvailable)
                {
                    myNetworkStream.BeginRead(_buffer, 0, _buffer.Length,StreamReceiver, myNetworkStream);
                }

                Receive?.Invoke(this, message);

                _stream.BeginRead(_buffer, 0, _buffer.Length, StreamReceiver, _stream);
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
        ///    this method do nothing except sending disconnect
        /// </summary>
        public void ShutDown()
        {
            try
            {
                SendMessage(MessageHelper.Messages.Disconnect);
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
#if DEBUG
                ErrorsProc.WriteErrorAndMessage(e, "SendMessage in UserConnection.cs", true);
                throw;
#endif
            }
            finally
            {
                SendMessageEvent?.Invoke(this, message);
            }
        }

        public void SendMessage(MessageHelper.Messages message)
        {
            SendMessage(MessageHelper.MessagesGetString(message));
        }

        public void SendMessage(MessageHelper.Messages message, params string[] additional)
        {
            var send = MessageHelper.MessagesGetString(message);
            foreach (var str in additional) send += "|" + str;
            SendMessage(send);
        }

        public void SendMessage(MessageHelper.Messages message, int delay, params string[] additional)
        {
            Thread.Sleep(delay);
            SendMessage(message, additional);
        }
        #endregion
    }
}