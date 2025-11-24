using EgyptExploring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptExploring.Configurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.HasMany(c => c.Destinations)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Trips)
                .WithOne(t => t.City)
                .HasForeignKey(t => t.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(LoadCities());
        }
        private List<City> LoadCities()
        {
            return new List<City>
    {
            new City { CityId = 1, CityName = "Cairo", Image = "~/images/Cairo/CairoTower.jpg" },
            new City { CityId = 2, CityName = "Giza", Image = "~/images/pyramid-giza.jpg" },
            new City { CityId = 3, CityName = "Alexandria", Image = "~/images/library-alexandria-anniversary-closure.jpg" },
            new City { CityId = 4, CityName = "Luxor", Image = "~/images/low-angle-shot-main-entrance-temple-horus-edfu-egypt.jpg" },
            new City { CityId = 5, CityName = "Aswan", Image = "~/images/shot-numerous-boats-berthed-by-pier-straight-lines-sunset.jpg" },
            new City { CityId = 6, CityName = "Sharm El Sheikh", Image = "~/images/beautiful-tropical-beach-sea-ocean-with-coconut-palm-tree-umbrella-chair-blue-sky-white-cloud.jpg" },
            new City { CityId = 7, CityName = "Hurghada", Image = "~/images/scenic-view-private-sandy-beach-with-sun-beds-parasokamy-sea-mountains-resort.jpg" },
            new City { CityId = 8, CityName = "Fayoum", Image = "~/images/Fayoum/WaterfallsofWadiElRayan.jpg" },
            new City { CityId = 9, CityName = "Sinai", Image = "~/images/raimond-klavins-zfeY8HkSAOE-unsplash.jpg" },
            new City { CityId = 10, CityName = "Marsa Alam", Image = "~/images/caption.jpg" },
            new City { CityId = 11, CityName = "Matrouh", Image = "~/images/date-palms-oasis-sahara-desert.jpg" }

    };
        }

    }
}

