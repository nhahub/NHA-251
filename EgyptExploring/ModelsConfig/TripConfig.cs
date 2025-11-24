using EgyptExploring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptExploring.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {


            builder.HasData(LoadTrips());
        }
        private List<Trip> LoadTrips()
        {
            return new List<Trip>
            {
                new Trip
                {
                    TripId = 1,
                    TripName = "Cairo Historical Adventure",
                    TripDescription = "Explore the ancient wonders of Cairo including the Egyptian Museum, Cairo Tower, and Khan El Khalili bazaar.",
                    TripPrice = 2500,
                    CityId = 1
                },
                new Trip
                {
                    TripId = 2,
                    TripName = "Giza Pyramids & Sphinx",
                    TripDescription = "Visit the iconic Pyramids of Giza, Great Sphinx, and Saqqara Step Pyramid.",
                    TripPrice = 1800,
                    CityId = 2
                },
                new Trip
                {
                    TripId = 3,
                    TripName = "Alexandria Heritage Tour",
                    TripDescription = "Discover Alexandria's Greco-Roman history including Bibliotheca Alexandrina, Qaitbay Citadel, and Pompey's Pillar.",
                    TripPrice = 2300,
                    CityId = 3
                },
                new Trip
                {
                    TripId = 4,
                    TripName = "Luxor Temple Discovery",
                    TripDescription = "A cultural journey through Luxor’s famous temples and the Valley of the Kings.",
                    TripPrice = 3200,
                    CityId = 4
                },
                new Trip
                {
                    TripId = 5,
                    TripName = "Aswan Nile Cruise",
                    TripDescription = "Enjoy a luxury cruise along the Nile from Aswan to Kom Ombo, visiting Philae Temple and High Dam.",
                    TripPrice = 4000,
                    CityId = 5
                },
                new Trip
                {
                    TripId = 6,
                    TripName = "Sharm El-Sheikh Diving Tour",
                    TripDescription = "Experience world-class diving and snorkeling in the Red Sea with a relaxing resort stay.",
                    TripPrice = 3500,
                    CityId = 6
                },
                new Trip
                {
                    TripId = 7,
                    TripName = "Hurghada Beach Escape",
                    TripDescription = "Relax on the stunning beaches of Hurghada with optional water sports and desert safari.",
                    TripPrice = 2800,
                    CityId = 7
                },
                new Trip
                {
                    TripId = 8,
                    TripName = "Fayoum Nature Escape",
                    TripDescription = "A relaxing eco-trip exploring Wadi El Rayan waterfalls and Qarun Lake.",
                    TripPrice = 2000,
                    CityId = 8
                },
                new Trip
                {
                    TripId = 9,
                    TripName = "Sinai Adventure Package",
                    TripDescription = "Explore Mount Sinai, Saint Catherine’s Monastery, and the beautiful Colored Canyon.",
                    TripPrice = 3700,
                    CityId = 9
                },
                new Trip
                {
                    TripId = 10,
                    TripName = "Marsa Alam Coral Reefs Tour",
                    TripDescription = "Dive into the crystal-clear waters of Marsa Alam to explore colorful marine life and visit Wadi El Gemal National Park.",
                    TripPrice = 4600,
                    CityId = 10
                },
                new Trip
{
    TripId = 11,
    TripName = "Matrouh Mediterranean Escape",
    TripDescription = "Relax on the stunning white sandy beaches of Cleopatra Beach and Al Aghla, explore the historic Rommel Museum, and enjoy the beautiful turquoise waters along Marsa Matrouh Corniche.",
    TripPrice = 3800,
    CityId = 11
}



            };
        }
    }
}
