namespace WebApplication1.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate next;
        public AuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DataService dataService)
        {
            string au = context.Request.Headers.UserAgent;

            dataService.Msg = au;

            if (au.Contains("Edg"))
            {
                await next(context);
                context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                await context.Response.WriteAsync("přístup byl povolen");
            }
            else
            {
                context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                context.Response.WriteAsync("přístup odepřen");
            }
        }

    }
}
