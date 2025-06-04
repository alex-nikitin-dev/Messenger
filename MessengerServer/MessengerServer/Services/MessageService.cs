using System.Collections;

namespace MessengerServer;

/// <summary>
/// Provides high level messaging methods for broadcasting to connected users.
/// </summary>
internal sealed class MessageService
{
    private readonly Hashtable _mainChatUsers;
    private readonly Hashtable _attachedUsers;

    public MessageService(Hashtable mainChatUsers, Hashtable attachedUsers)
    {
        _mainChatUsers = mainChatUsers;
        _attachedUsers = attachedUsers;
    }

    /// <summary>
    /// Send a message to all attached users regardless of their state.
    /// </summary>
    public void Broadcast(MessageHelper.Messages message, string payload)
    {
        foreach (string clientName in _attachedUsers.Keys)
        {
            var connection = (UserConnection)_attachedUsers[clientName];
            connection.SendMessage(message, payload);
        }
    }

    /// <summary>
    /// Send a message to all users currently connected to the main chat room.
    /// </summary>
    public void SendToMainChat(MessageHelper.Messages message, string payload)
    {
        foreach (string clientName in _mainChatUsers.Keys)
        {
            var connection = (UserConnection)_mainChatUsers[clientName];
            connection.SendMessage(message, payload);
        }
    }

    public void ServerBroadcast(string text) => SendToMainChat(MessageHelper.Messages.Server, text);
}
