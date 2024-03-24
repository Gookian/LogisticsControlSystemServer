using LogisticsСontrolSystemServer.Middlewares;

namespace LogisticsСontrolSystemServer.Extensions
{
    public static class TokenAuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TokenAuthenticationMiddleware>();
        }
    }
}
