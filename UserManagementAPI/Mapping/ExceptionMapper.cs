using UserManagementAPI.Shared.Utilities.Structs;
using UserManagementAPI.Shared.Wrappers;

namespace UserManagementAPI.Mapping;

public static class ExceptionMapper
{
    public static ValidationResponse ToValidationResponse(string error, List<ValidationError> data)
    {
        ValidationResponse response;
        switch (error)
        {
            case ExceptionName.INVALIDPROPERTIES:
                response = BuildInvalidPropertiesResponse(data);
                break;
            case ExceptionName.EMPTYPAYLOAD:
            default:
                response = BuildEmptyPayloadResponse(data);
                break;
        }

        return response;
    }

    public static ValidationResponse BuildEmptyPayloadResponse(List<ValidationError> data)
    {
        return new ValidationResponse
        {
            Headers = new ValidationResponseHeader
            {
                Error = ExceptionName.EMPTYPAYLOAD,
                Status = StatusCodes.Status400BadRequest,
                Message = "arg-empty-payload",
                Data = data
            }
        };
    }

    public static ValidationResponse BuildInvalidPropertiesResponse(List<ValidationError> data)
    {
        return new ValidationResponse
        {
            Headers = new ValidationResponseHeader
            {
                Error = ExceptionName.INVALIDPROPERTIES,
                Status = StatusCodes.Status400BadRequest,
                Message = "arg-invalid-properties",
                Data = data
            }
        };
    }
}