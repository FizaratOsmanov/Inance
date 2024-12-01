using Inance.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<InanceDBContext>(
            options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
             );
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(

                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
