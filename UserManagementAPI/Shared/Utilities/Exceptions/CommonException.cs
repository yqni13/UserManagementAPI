namespace UserManagementAPI.Shared.Utilities.Exceptions;

public class CommonException : BaseException
{
    public CommonException
    (
        string message = "arg-common-exception",
        string error = "CommonException",
        int statusCode = StatusCodes.Status500InternalServerError
    ) : base(message, error, statusCode) { }
}

public class NotFoundException : CommonException
{
    public NotFoundException
    (
        string message ="arg-invalid-notfound",
        string error = "NotFoundException",
        int statusCode = StatusCodes.Status404NotFound
    ) : base(message, error, statusCode) {}
}

public class ConflictException : CommonException
{
    public ConflictException
    (
        string message = "arg-invalid-conflict",
        string error = "ConflictException",
        int statusCode = StatusCodes.Status409Conflict
    ) : base(message, error, statusCode) {}
}

public class InternalServerException : CommonException
{
    public InternalServerException
    (
        string message = "arg-invalid-internalserver",
        string error = "InternalServerException"
    ) : base(message, error) {}
}