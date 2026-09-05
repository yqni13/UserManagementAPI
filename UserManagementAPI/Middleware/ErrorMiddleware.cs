using UserManagementAPI.Shared.Utilities.Exceptions;

namespace UserManagementAPI.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Error,
                message = ex.Message,
                status = ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                error = "InternalServerException",
                message = ex.Message,
                status = StatusCodes.Status500InternalServerError
            });
        }
    }
}

public static class ErrorMiddlewareExtension
{
    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorMiddleware>();
    }
}