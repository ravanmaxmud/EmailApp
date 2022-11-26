using EmailApp.Database;
using Microsoft.EntityFrameworkCore;

namespace EmailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services
    .AddDbContext<DataContext>(o => o.UseSqlServer("Server=DESKTOP-0A48AOT\\SQLEXPRESS;Database=EmailServices;Trusted_Connection=True;TrustServerCertificate=True;"))
    .AddMvc();

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=email}/{action=list}");

            app.Run();
        }
    }
}