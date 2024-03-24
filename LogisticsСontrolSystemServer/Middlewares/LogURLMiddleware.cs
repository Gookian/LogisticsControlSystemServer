using Microsoft.AspNetCore.Http.Extensions;

namespace LogisticsСontrolSystemServer.Middlewares
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;

        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"[{context.Request.Method}] Request URL: {UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }
}
