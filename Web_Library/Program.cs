using Microsoft.EntityFrameworkCore;
using Web_Library.Data;
using Web_Library.Services.Core.Interfaces;
using Web_Library.Services.Core;

namespace Web_Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });

            builder.Services.AddScoped<IBooksService,BooksService>();

            builder.Services.AddScoped<ISystemsService,SystemsService>();

            builder.Services.AddScoped<IUsersService, UsersService>();

            builder.Services.AddScoped<IWelcomeService, WelcomeService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Welcome}/{action=index}/{id?}");

            app.Run();
        }
    }
}
