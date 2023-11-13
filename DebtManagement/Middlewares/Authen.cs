namespace DebtManagement.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            List<string> publicUrls = new List<string>()
            {
                "/Login",
                "/Register"
            };
            int? userId = context.Session.GetInt32("userId");

            if (!publicUrls.Contains(context.Request.Path) && userId == null)
            {
                context.Response.Redirect("/Login");
                return;
            }
            if (publicUrls.Contains(context.Request.Path))
            {
                context.Session.Clear();
            }

            await _next(context);
        }
    }

    public static class AuthenMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
