namespace DebtManagement.Middlewares
{
    public class Authen
    {
        private readonly RequestDelegate _next;

        public Authen(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            List<string> publicUrls = new List<string>()
            {
                "/shared/login",
                "/shared/register",
                "/shared/logout"
            };
            int? userId = context.Session.GetInt32("userId");

            //check if not logged in and route is not / signin => redirect to signin
            if (userId == null && !publicUrls.Contains(context.Request.Path.ToString().ToLower()))
            {
                // No active session, redirect to login page
                context.Response.Redirect("/shared/login");
                return;
            }
            else if (userId != null && publicUrls.Contains(context.Request.Path.ToString().ToLower()))
            {
                context.Response.Redirect("/");
                return;
            }
            await _next(context);
        }
    }
}
