using WebApplication1.Middlewares;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //pøidáváni service prodle toho co potøebujeme
            //builder.Services.AddSingleton();
            //builder.Services.AddScoped();
            //builder.Services.AddTransient();

            builder.Services.AddScoped<ErrorHandler>();
            builder.Services.AddScoped<IMyLogger, TxtLogger>();
            builder.Services.AddScoped<DataService>();

            var app = builder.Build();

            //U middleware je duležité poøadí jak je registruji u service to je jedno
            //app.UseStaticFiles();
            app.UseMiddleware<ErrorMiddleware>();
            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<FileMiddleware>();
            app.UseMiddleware<FirstPageMiddleware>();
            app.UseMiddleware<SecondPageMiddleware>();
            app.UseMiddleware<FormMiddleware>();


            app.MapGet("/", () => TypedResults.Content("<h1>Hello World!</h1>", "text/html"));
            app.MapGet("/second", () => "Second page");

            app.Run();
        }
    }
}
