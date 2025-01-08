public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);
        Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
    }
}
