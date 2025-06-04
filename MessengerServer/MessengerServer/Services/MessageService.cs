using ServerInterfaceLib;
using System.Collections.Generic;

namespace MessengerServer;

internal interface IMessageService
{
    void Broadcast(MessageHelper.Messages message, string payload);
    //void Broadcast(MessageHelper.Messages disconnect, string empty);
    void SendToMainChat(MessageHelper.Messages message, string payload);
    void ServerBroadcast(string text);
}

/// <summary>
/// Provides high level messaging methods for broadcasting to connected users.
/// </summary>
internal sealed class MessageService : IMessageService
{
    private readonly IDictionary<string, UserConnection> _mainChatUsers;
    private readonly IDictionary<string, UserConnection> _attachedUsers;

    public MessageService(IDictionary<string, UserConnection> mainChatUsers,
        IDictionary<string, UserConnection> attachedUsers)
    {
        _mainChatUsers = mainChatUsers;
        _attachedUsers = attachedUsers;
    }

    /// <summary>
    /// Send a message to all attached users regardless of their state.
    /// </summary>
    public void Broadcast(MessageHelper.Messages message, string payload)
    {
        foreach (var connection in _attachedUsers.Values)
        {
            connection.SendMessage(message, payload);
        }
    }

    /// <summary>
    /// Send a message to all users currently connected to the main chat room.
    /// </summary>
    public void SendToMainChat(MessageHelper.Messages message, string payload)
    {
        foreach (var connection in _mainChatUsers.Values)
        {
            connection.SendMessage(message, payload);
        }
    }

    public void ServerBroadcast(string text) => SendToMainChat(MessageHelper.Messages.Server, text);
}
