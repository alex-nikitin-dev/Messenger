using System;

namespace ServerExceptionLib
{
    public class ServerException: ApplicationException
    {
        private Error  _error;
        private string _message;

        public enum Error
        {
            NoProblem = -1,
            BadValue,
            EmptyUserName,
            EmptyDataArray,
            WrongUserInit
        }
        public new string Message => _message;

        public ServerException(Error sendError)
        {
            _error = sendError;
            SetMessage();
        }
        public ServerException(string sendError)
        {
            _message = sendError;
        }
        private void SetMessage()
        {
            switch (_error)
            {
                case Error.NoProblem:
                    _message = "Проблем не обнаружено";
                    break;
                case Error.BadValue:
                    _message = "Значение не соответствует требованиям";
                    break;
                case Error.EmptyUserName:
                    _message = "Значение имени пользователя пустая строка. Пользователь не присоеденён";
                    break;
                case Error.EmptyDataArray:
                    _message = "Массив данных не определён(null)";
                    break;
                case Error.WrongUserInit:
                    _message = "Имя пользователя не существует в базе. Попытка присвоить несущетвующее имя в данном подключении";
                    break;
                    
            }
        }
        private string GetMessage()
        {
            return Message;
        }
    }
}
