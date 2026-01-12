namespace UCP.API.Middleware;

/// <summary>
/// Middleware to validate required UCP headers
/// </summary>
public class UcpHeaderValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UcpHeaderValidationMiddleware> _logger;

    public UcpHeaderValidationMiddleware(RequestDelegate next, ILogger<UcpHeaderValidationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip validation for discovery endpoint
        if (context.Request.Path.StartsWithSegments("/.well-known"))
        {
            await _next(context);
            return;
        }

        // Skip validation for non-UCP endpoints
        if (!context.Request.Path.StartsWithSegments("/checkout-sessions") && 
            !context.Request.Path.StartsWithSegments("/orders"))
        {
            await _next(context);
            return;
        }

        // TODO: Implement header validation
        // UCP requires these headers for security:
        // 1. Request-Signature (required) - Message authenticity and integrity
        // 2. Idempotency-Key (required for POST/PUT) - Prevent duplicate operations
        // 3. Request-Id (optional) - Request tracing
        // 4. Authorization (optional) - OAuth token
        // 5. X-API-Key (optional) - API key authentication

        // For now, just log headers for development
        _logger.LogInformation("UCP Request to {Path}", context.Request.Path);
        
        if (context.Request.Headers.ContainsKey("Request-Signature"))
        {
            _logger.LogDebug("Request-Signature present");
            // TODO: Validate signature using your signing key
        }
        
        if (context.Request.Headers.ContainsKey("Idempotency-Key"))
        {
            var idempotencyKey = context.Request.Headers["Idempotency-Key"].ToString();
            _logger.LogDebug("Idempotency-Key: {Key}", idempotencyKey);
            // TODO: Check if this request was already processed
            // TODO: Store idempotency key and response in your database
        }

        await _next(context);
    }
}

/// <summary>
/// Extension method to register UCP header validation middleware
/// </summary>
public static class UcpHeaderValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseUcpHeaderValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UcpHeaderValidationMiddleware>();
    }
}
