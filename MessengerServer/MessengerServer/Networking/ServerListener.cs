using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MessengerServer;

/// <summary>
///     Listens for incoming TCP connections and exposes them as <see cref="UserConnection"/> instances.
/// </summary>
internal sealed class ServerListener
{
    private readonly int _port;
    private TcpListener? _listener;
    private Thread? _listenerThread;
    private readonly List<UserConnection> _clients = new();
    private volatile bool _stop;

    public ServerListener(int port = 1100)
    {
        _port = port;
    }

    /// <summary>Raised whenever a new client connection is accepted.</summary>
    public event Action<UserConnection>? ClientAccepted;
    /// <summary>Raised when an unhandled exception occurs inside the listener loop.</summary>
    public event Action<Exception>? ListenerException;

    /// <summary>Start accepting connections.</summary>
    public void Start()
    {
        _stop = false;
        _listenerThread = new Thread(ListenLoop) { IsBackground = true };
        _listenerThread.Start();
    }

    /// <summary>Stop the listener and wait for the thread to terminate.</summary>
    public void Stop()
    {
        _stop = true;
        _listener?.Stop();
        _listenerThread?.Join(1000);
    }

    private void ListenLoop()
    {
        try
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            while (!_stop)
            {
                try
                {
                    var tcpClient = _listener.AcceptTcpClient();
                    var connection = new UserConnection(tcpClient);
                    _clients.Add(connection);
                    ClientAccepted?.Invoke(connection);
                }
                catch (SocketException)
                {
                    if (_stop) break;
                    throw;
                }
            }
        }
        catch (Exception ex)
        {
            if (_stop) return;
            ListenerException?.Invoke(ex);
        }
    }

    /// <summary>Remove a connection from the internal list.</summary>
    /// <param name="connection">The connection to remove.</param>
    public void Remove(UserConnection connection) => _clients.Remove(connection);
}

