
using Account_Task.BLL.Interfaces;
using Account_Task.BLL.Repositories;
using Account_Task.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Account_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer("Server= .; Database=AccountDb;Trusted_Connection=true;MultipleActiveResultSets=true;");
            });
            builder.Services.AddScoped<IUsersRepositories, UserRepositories>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}