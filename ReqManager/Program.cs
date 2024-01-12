using ReqManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using ReqManager.Data;
using ReqManager.Areas.Identity.Data;

namespace ReqManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RequestDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            builder.Services.AddDbContext<ReqManagerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            builder.Services.AddDefaultIdentity<ReqManagerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ReqManagerContext>();

            builder.Services.AddDbContext<RequestDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Requests}/{action=Index}/{id?}");

            app.Run();
        }
    }
}