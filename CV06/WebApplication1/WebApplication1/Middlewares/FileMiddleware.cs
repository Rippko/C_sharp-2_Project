namespace WebApplication1.Middlewares
{
    public class FileMiddleware
    {
        private readonly RequestDelegate next;
        public FileMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path;
            path = path.TrimStart('/');

            string dir = @"C:\Users\adamm\Downloads";
            path = Path.Combine(dir, path);
            if (File.Exists(path))
            {
                context.Response.ContentType = "image/png";
                context.Response.SendFileAsync(path);
            }
            else
            {
                await this.next(context);
            }
        }
    }
}
