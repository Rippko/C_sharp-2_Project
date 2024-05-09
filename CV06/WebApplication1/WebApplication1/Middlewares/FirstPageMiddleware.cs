namespace WebApplication1.Middlewares
{
    public class FirstPageMiddleware
    {
        private readonly RequestDelegate next;

        public FirstPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DataService dataService)
        {
            if (context.Request.Path == "/")
            {
                context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                await context.Response.WriteAsync("<h1>Hello World!</h1><p>žluťoučký</p>");
                await context.Response.WriteAsync(dataService.Msg);
                return;
            }
            await next(context);
        }
    }
}
