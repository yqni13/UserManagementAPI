using Microsoft.Extensions.Options;
using UserManagementAPI.Configs;
using UserManagementAPI.Shared.Utilities.Exceptions;

namespace UserManagementAPI.Middleware;

// Lightweight authorization as it was described in last task as a simple token validation.
public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly EnvSecrets _secrets;
    public AuthorizationMiddleware(RequestDelegate next, IOptions<EnvSecrets> secrets)
    {
        _next = next;
        _secrets = secrets.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string rawToken = context.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrWhiteSpace(rawToken))
        {
            throw new MissingAuthTokenException();
        }

        string token = rawToken.Replace("Bearer ", "");
        if (token != _secrets.AuthToken)
        {
            throw new InvalidAuthTokenException();
        }

        await _next(context);
    }
}

public static class AuthorizationMiddlewareExtension
{
    public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AuthorizationMiddleware>();
    }
}