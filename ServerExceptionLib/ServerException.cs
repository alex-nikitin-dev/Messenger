using System;

namespace ServerExceptionLib;

/// <summary>
/// Custom exception for handling server side errors in a user friendly way.
/// </summary>
public class ServerException : ApplicationException
{
    private readonly Error _error;
    private string _message = string.Empty;

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
        _message = _error switch
        {
            Error.NoProblem => "No issues detected",
            Error.BadValue => "Value does not meet requirements",
            Error.EmptyUserName => "User name cannot be empty. User is not attached",
            Error.EmptyDataArray => "Data array is null",
            Error.WrongUserInit => "User name does not exist in the database for this connection",
            _ => string.Empty
        };
    }

    private string GetMessage() => Message;
}
