using System;
using System.Net;
using System.Windows.Forms;
using ClientConnectionLib;
namespace TestClient
{
    public partial class Form1 : Form
    {
        private ClientConnection _client;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnReceive(ClientConnection sender, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnReceive(sender, message)));
                return;
            }

            txtRecieve.Text += $@"receive from server: {message}{Environment.NewLine}";
        }

        private void OnSendMessage(ClientConnection sender, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnSendMessage(sender, message)));
                return;
            }

            txtRecieve.Text += $@"send to server: {message}{Environment.NewLine}";
        }

        private void OnDisconnect(ClientConnection sender, ClientConnection.DisconnectReason reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnDisconnect(sender, reason)));
                return;
            }

            txtRecieve.Text += $@"disconnect event has occured. Reason is: {reason.ToString()}{Environment.NewLine}";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _client.SendMessage(ClientConnection.Messages.YouAlive);
            _client.SendMessage(ClientConnection.Messages.Connect,@"User|qweqwe");
            //_client.SendMessage(ClientConnection.Messages.Disconnect);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var ip = IPAddress.Parse("127.0.0.1");

            _client?.Close();
            _client = new ClientConnection(ip, 1100);
            _client.DisconnectEvent += OnDisconnect;
            _client.SendMessageEvent += OnSendMessage;
            _client.Receive += OnReceive;

            txtRecieve.Text += $@"new connection has established {Environment.NewLine}";
        }
    }
}
