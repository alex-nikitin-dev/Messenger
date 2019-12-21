using System;


namespace ServerInterfaceLib
{
    public class MessageHelper
    {
       
        public static string MessagesGetString(Messages message) => Enum.GetName(typeof(Messages), message);
        public static Messages GetMessages(string message) => (Messages) Enum.Parse(typeof(Messages), message);
        public enum Messages
        {
            /// <summary>
            ///  special server message
            /// </summary>
            Server,
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
    }
}
