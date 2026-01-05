using System.Net;
using System.Text.Json;

namespace ResumeApi.Middleware;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next; 
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var traceId = context.TraceIdentifier;

            _logger.LogError(ex, "Unhandled exception for {Method} {Path}. TraceId: {TraceId}. Message: {Message}",
                context.Request.Method,
                context.Request.Path,
                traceId, 
                ex.Message);

            context.Response.ContentType = "application/problem+json";  
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problem = new
            {
                type = "https://httpstatuses.com/500",
                title = "An unexpected error occurred.",
                status = 500,
                traceId
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}


  