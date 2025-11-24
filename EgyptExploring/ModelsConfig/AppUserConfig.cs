using EgyptExploring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptExploring.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
          

         


            builder.HasMany(u => u.Trips)
                .WithMany(t => t.Users)
                .UsingEntity<Booking>();
        }
    }
}
