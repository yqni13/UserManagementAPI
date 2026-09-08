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

            // [Copilot]: I used AI as debugging assistent to solve the problem on why I didn't catch an exception
            // when a request didn't match the existing routes.

            // Check if routing misses endpoint -> throw exception as .NET does NOT throw one itself in these cases.
            if (!context.Response.HasStarted)
            {
                // Route does not exist entirely => not found.
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                    throw new RouteNotFoundException();

                // Route does only exist for other http methods => not allowed.
                if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
                    throw new MethodNotAllowedException();
            }
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
        catch (ValidationException ex)
        {
            var err = ex.ValidData.Headers;
            context.Response.StatusCode = ex.ValidData.Headers.Status;
            await context.Response.WriteAsJsonAsync(new
            {
                headers = ex.ValidData.Headers
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