using EgyptExploring.Models;
using EgyptExploring.Repositories;
using EgyptExploring.RepositryInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EgyptExploring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<ICityRepositry,CityRepositry>();
            builder.Services.AddScoped<IDestinationRepository,DestinationRepositry>();
            builder.Services.AddScoped<ITripRepository,TripRepository>();
            builder.Services.AddScoped<IAppUserRepository,AppUserRepository>();
            builder.Services.AddScoped<IBookinRepository,BookingRepository>();
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(option => {

                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
            
            })
                
                .AddEntityFrameworkStores<AppDbContext>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
