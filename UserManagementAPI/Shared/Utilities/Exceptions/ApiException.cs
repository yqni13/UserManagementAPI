namespace UserManagementAPI.Shared.Utilities.Exceptions;

public class ApiException : BaseException
{
    public ApiException
    (
        string message = "arg-api-exception",
        string error = "ApiException",
        int statusCode = StatusCodes.Status404NotFound
    ) : base(message, error, statusCode) {}
}

public class RouteNotFoundException : ApiException
{
    public RouteNotFoundException
    (
        string message = "arg-unimplemented-route",
        string error = "RouteNotFoundException"
    ) : base(message, error) {}
}

public class MethodNotAllowedException : ApiException
{
    public MethodNotAllowedException
    (
        string message = "arg-notallowed-route",
        string error = "MethodNotAllowedException",
        int statusCode = StatusCodes.Status405MethodNotAllowed
    ) : base(message, error, statusCode) {}
}