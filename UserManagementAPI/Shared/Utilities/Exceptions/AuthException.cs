namespace UserManagementAPI.Shared.Utilities.Exceptions;

public class AuthException : BaseException
{
    public AuthException
    (
        string message = "arg-auth-exception",
        string error = "AuthException",
        int statusCode = StatusCodes.Status401Unauthorized
    ) : base(message, error, statusCode) { }
}

public class AuthenticationException : AuthException
{
    public AuthenticationException
    (
        string message = "arg-invalid-authentication",
        string error = "AuthenticationException"
    ) : base(message, error) {}
}

public class AuthorizationException : AuthException
{
    public AuthorizationException
    (
        string message = "arg-invalid-authorization",
        string error = "AuthorizationException"
    ) : base(message, error) {}
}

public class MissingAuthTokenException : AuthException
{
    public MissingAuthTokenException
    (
        string message = "arg-missing-authtoken",
        string error = "MissingAuthTokenException"
    ) : base(message, error) {}
}

public class InvalidAuthTokenException : AuthException
{
    public InvalidAuthTokenException
    (
        string message = "arg-invalid-authtoken",
        string error = "InvalidAuthTokenException"
    ) : base(message, error) {}
}