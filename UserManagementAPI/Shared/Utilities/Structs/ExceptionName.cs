namespace UserManagementAPI.Shared.Utilities.Structs;

public struct ExceptionName
{
    // ApiExceptions
    public const string ROUTENOTFOUND = "RouteNotFoundException";
    public const string METHODNOTALLOWED = "MethodNotAllowedException";

    // AuthExceptions
    public const string AUTHENTICATION = "AuthenticationException";
    public const string AUTHORIZATION = "AuthorizationException";
    public const string MISSINGAUTHTOKEN = "MissingAuthTokenException";
    public const string INVALIDAUTHTOKEN = "InvalidAuthTokenException";

    // CommonExceptions
    public const string NOTFOUND = "NotFoundException";
    public const string CONFLICT = "ConflictException";
    public const string INTERNALSERVER = "InternalServerException";

    // ValidationExceptions
    public const string EMPTYPAYLOAD = "EmptyPayloadException";
    public const string INVALIDPROPERTIES = "InvalidPropertiesException";
}