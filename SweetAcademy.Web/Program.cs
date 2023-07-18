using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Web.Infrastructure.Extensions;

namespace SweetAcademy.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                      throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<SweetAcademyDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = builder.Configuration
                        .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                    options.Password.RequireLowercase = builder.Configuration
                        .GetValue<bool>("Identity:Password:RequireLowercase");

                    options.Password.RequireUppercase = builder.Configuration
                        .GetValue<bool>("Identity:Password:RequireUppercase");

                    options.Password.RequireNonAlphanumeric = builder.Configuration
                        .GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

                    options.Password.RequiredLength = builder.Configuration
                        .GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddEntityFrameworkStores<SweetAcademyDbContext>();
            builder.Services.AddApplicationServices(typeof(I);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}