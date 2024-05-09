namespace WebApplication1.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ErrorHandler handler)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                handler.Handle(e);
            }

        }
    }

}
