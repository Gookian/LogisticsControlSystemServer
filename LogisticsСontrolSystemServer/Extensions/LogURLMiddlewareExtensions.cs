using LogisticsСontrolSystemServer.Middlewares;

namespace LogisticsСontrolSystemServer.Extensions
{
    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogURLMiddleware>();
        }
    }
}
