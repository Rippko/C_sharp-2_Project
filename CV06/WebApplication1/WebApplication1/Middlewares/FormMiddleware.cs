using System.Net;

namespace WebApplication1.Middlewares
{
    public class FormMiddleware
    {
        private readonly RequestDelegate next;

        public FormMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DataService dataService)
        {

            if (context.Request.Path == "/form")
            {
                if (context.Request.Method == "POST")
                {
                    context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                    string name = context.Request.Form["Jméno"];
                    context.Response.WriteAsync("Data: " + WebUtility.HtmlEncode(name));
                    return;
                }
                context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                await context.Response.WriteAsync(@"
                <form method=""POST""> 
                    <input name =""Jméno""/>
                    <button type=""submit""> Odeslat </button>
                </form>
                ");

                return;
            }
            else
            {
                await next(context);
            }
        }
    }
}
