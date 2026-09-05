using UserManagementAPI.Middleware;

namespace UserManagementAPI.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder app)
    {
        app.UseErrorMiddleware();

        return app;
    }
}