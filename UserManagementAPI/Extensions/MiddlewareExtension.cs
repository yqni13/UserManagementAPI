using UserManagementAPI.Middleware;

namespace UserManagementAPI.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder RegisterMiddleware(this IApplicationBuilder app)
    {
        app.UseErrorMiddleware();
        app.UseAuthorizationMiddleware();

        return app;
    }
}