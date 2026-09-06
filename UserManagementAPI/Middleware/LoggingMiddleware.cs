namespace UserManagementAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string method = context.Request.Method;
        string path = context.Request.Path;

        await _next(context);

        int statusCode = context.Response.StatusCode;

        // Write summary (method, path, statuscode of result) to the end of logging process each request.
        _logger.LogInformation("{Method} {Path} => {StatusCode}", method, path, statusCode);
    }
}

public static class RequestLoggingMiddlewareExtension
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}