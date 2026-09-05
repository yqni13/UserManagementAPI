namespace UserManagementAPI.Shared.Utilities.Exceptions;

public abstract class BaseException : Exception
{
    public string Error { get; }
    public int StatusCode { get; }
    public BaseException(string message, string error, int statusCode) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
    }
}