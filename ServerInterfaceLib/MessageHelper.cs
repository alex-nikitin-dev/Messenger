using System;


namespace ServerInterfaceLib;

public static class MessageHelper
{
       
        public static string MessagesGetString(Messages message) => Enum.GetName(typeof(Messages), message);
        public static Messages GetMessages(string message) => (Messages) Enum.Parse(typeof(Messages), message);
    public enum Messages
    {
        /// <summary>
        /// Special server message.
        /// </summary>
        Server,
        /// <summary>
        /// Notifies a user that someone added them to contacts.
        /// </summary>
        Alert,

        /// <summary>
        /// User successfully authorised and attached.
        /// </summary>
        Attached,

        /// <summary>
        /// Message for the main chat.
        /// </summary>
        Chat,

        /// <summary>
        /// List of all active users in the main chat.
        /// </summary>
        Listusers,

        /// <summary>
        /// Registration failed.
        /// </summary>
        RegistrationFailed,

        /// <summary>
        /// Registration failed for an unspecified reason.
        /// </summary>
        RegistrationFailedDefault,

        /// <summary>
        /// Registration failed because the login already exists.
        /// </summary>
        RegistrationFailedLoginAlreadyExist,

        /// <summary>
        /// Error forming the registration data packet on the client.
        /// </summary>
        RegistrationVerifydataError,

        /// <summary>
        /// The server received an invalid message.
        /// </summary>
        Refuse,

        /// <summary>
        /// Attempt to authorize a user who is already connected.
        /// </summary>
        WasAttached,

        /// <summary>
        /// Attempted to re-register in the main chat.
        /// </summary>
        WasRegister,

        /// <summary>
        /// Registration completed successfully.
        /// </summary>
        RegistrationPassed,

        /// <summary>
        /// User was lost due to disconnect.
        /// </summary>
        Userlost,

        /// <summary>
        /// Successfully joined the main chat.
        /// </summary>
        MchatEnterPassed,

        /// <summary>
        /// Left the main chat.
        /// </summary>
        MchatExit,

        /// <summary>
        /// Unable to join due to server error.
        /// </summary>
        MchatEnterFailed,

        /// <summary>
        /// Reply from the server that it is running.
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
        /// Successfully added to the white list.
        /// </summary>
        WhiteAddPass,

        /// <summary>
        /// Error while adding to the white list.
        /// </summary>
        WhiteAddError,

        /// <summary>
        /// Adding failed because the user is already in the list.
        /// </summary>
        WhiteAddWrong,

        /// <summary>
        /// Adding to the black list failed because the user already exists.
        /// </summary>
        BlackAddWrong,

        /// <summary>
        /// Successfully added to the black list.
        /// </summary>
        BlackAddPass,

        /// <summary>
        /// Error while adding to the black list.
        /// </summary>
        BlackAddError,
        WhiteList,
        BlackList,

        /// <summary>
        /// Error sending black and white lists.
        /// </summary>
        GetBwError,

        /// <summary>
        /// Finished sending black and white lists.
        /// </summary>
        SendBwFinished,

        /// <summary>
        /// Sending state information for users in the white list.
        /// </summary>
        WhiteUserState,

        /// <summary>
        /// Sending state information for users in the black list.
        /// </summary>
        BlackUserState,

        /// <summary>
        /// Finished sending states for black and white lists.
        /// </summary>
        SendBwUserStateFinished,
        Disconnect,
        AddContactPass,
        AddContactWrong,

        /// <summary>
        /// Private message: fromUser,message,colorName,fontName,fontSize
        /// </summary>
        Private,
        Email,

        /// <summary>
        /// Error retrieving the email address.
        /// </summary>
        EmailAps,
        MchatBan
    }
}
