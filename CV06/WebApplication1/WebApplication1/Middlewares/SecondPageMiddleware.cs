using System.Diagnostics.Contracts;

namespace WebApplication1.Middlewares
{
    public class SecondPageMiddleware
    {
        private readonly RequestDelegate next;
        public SecondPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            throw new NotImplementedException();
            if (context.Request.Path == "/second")
            {
                context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                await context.Response.WriteAsync("<h1>Druhá stránka</h1>");
                return;
            }
            else
            {
                await this.next(context);
            }
        }
    }
}
