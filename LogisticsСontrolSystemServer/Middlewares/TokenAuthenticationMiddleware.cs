namespace LogisticsСontrolSystemServer.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private Authenticator _authenticator;

        public TokenAuthenticationMiddleware(RequestDelegate next, Authenticator authenticator)
        {
            _next = next;
            _authenticator = authenticator;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestPath = context.Request.Path;

            if (requestPath != "/api/Authenticator")
            {
                string? token = context.Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Missing or invalid token.");
                    return;
                }
                else
                {
                    if (!_authenticator.IsAuthenticated(Guid.Parse(token)))
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Missing or invalid token.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
