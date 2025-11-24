using EgyptExploring.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EgyptExploring.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppUserConfig).Assembly);
     
       
       

        }

            
        }

    }

