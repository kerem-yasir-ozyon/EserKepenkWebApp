using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Concrete;
using EserKepenk.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EserKepenk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.Cookie.Name = "HmsApp.Session";
                    opt.Cookie.MaxAge = TimeSpan.FromSeconds(1000);
                    opt.LoginPath = "/Account/Login";     // Account/Login
                    opt.LogoutPath = "/Account/Logout";   // Account/Logout
                    //opt.ExpireTimeSpan = TimeSpan.FromSeconds(200);
                    opt.SlidingExpiration = true;
                });

            builder.Services.AddSession(opt =>
            {
                opt.Cookie.Name = "HmsApp.Session";
                opt.IdleTimeout = TimeSpan.FromSeconds(297);
                opt.Cookie.IsEssential = true;
            });

            // Add services to the container.
            builder.Services.AddDbContext<EserKepenkDbContext>(options => {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("EserKepenkConStr"));
            }, ServiceLifetime.Scoped);


            builder.Services.AddControllersWithViews(opt =>
            {
                var x = opt.Filters;

                opt.Filters.Add<UserInfoActionFilter>();
            });

            builder.Services.AddAutoMapper(typeof(Assembly));

            builder.Services.AddScoped<ProductRepo>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ProductManager>();
             // Kategori Implimentation
            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<CategoryManager>();
                        
            builder.Services.AddScoped<AccountUserRepo>();
            builder.Services.AddScoped<AccountUserService>();
            builder.Services.AddScoped<AccountUserManager>();

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

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
