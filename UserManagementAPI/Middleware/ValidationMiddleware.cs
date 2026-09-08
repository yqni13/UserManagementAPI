using System.Text;
using System.Text.Json;
using UserManagementAPI.Attributes;
using UserManagementAPI.Mapping;
using UserManagementAPI.Shared.Utilities.Exceptions;
using UserManagementAPI.Shared.Utilities.Structs;
using UserManagementAPI.Shared.Wrappers;

namespace UserManagementAPI.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string exName = ExceptionName.EMPTYPAYLOAD;
        try
        {
            // Read request body as json string from stream.
            string payloadString = "";
            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                payloadString = await reader.ReadToEndAsync();
            }
            context.Request.Body.Position = 0;

            payloadString = payloadString.Replace("\n", string.Empty);
            payloadString = payloadString.Replace(" ", string.Empty);

            // Validate request for empty body or payload without content.
            if (payloadString == "" || payloadString == "{}" || payloadString == "[]")
            {
                string val = payloadString == "" ? "null" : payloadString;
                ValidationResponse response = BuildValidationResponse(exName, val);
                throw new EmptyPayloadException(response);
            }

            await _next(context);
        }
        catch (JsonException)
        {
            // Handle exception for requests with expected payload but missing body (null-based value).
            ValidationResponse response = BuildValidationResponse(exName, "null");
            throw new EmptyPayloadException(response);
        }
    }

    private static ValidationResponse BuildValidationResponse(string error, string value)
    {
        List<ValidationError> data = [
            new ValidationError
            (
                "request", "payload", value, "arg-empty-payload", "NotNullValidator"
            )
        ];
        return ExceptionMapper.ToValidationResponse(error, data);
    }
}

public static class ValidationMiddlewareExtension
{
    public static IApplicationBuilder UseValidationMiddleware(this IApplicationBuilder app)
    {
        // Register middleware only for specific endpoints, defined by metadata attributes within controller.
        return app.UseWhen(
            context => context.GetEndpoint()?.Metadata.GetMetadata<RequestValidationAttribute>() != null,
            appBuilder => appBuilder.UseMiddleware<ValidationMiddleware>()
        );
    }
}