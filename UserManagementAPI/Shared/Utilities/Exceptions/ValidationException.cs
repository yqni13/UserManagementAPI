using UserManagementAPI.Shared.Wrappers;

namespace UserManagementAPI.Shared.Utilities.Exceptions;

public class ValidationException : Exception
{
    public ValidationResponse ValidData { get; }
    public ValidationException
    (
        ValidationResponse validData
    ) : base()
    {
        ValidData = validData;
    }
}

public class InvalidPropertiesException : ValidationException
{
    public InvalidPropertiesException(ValidationResponse validData) : base(validData) {}
}

public class EmptyPayloadException : ValidationException
{
    public EmptyPayloadException(ValidationResponse validData) : base(validData) {}
}