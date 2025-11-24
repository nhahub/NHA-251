using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgyptExploring.Migrations
{
    /// <inheritdoc />
    public partial class OneForAllUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                    table.ForeignKey(
                        name: "FK_Destinations_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.TripId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "CityId", "CityName", "Image" },
                values: new object[,]
                {
                    { 1, "Cairo", "~/images/Cairo/CairoTower.jpg" },
                    { 2, "Giza", "~/images/pyramid-giza.jpg" },
                    { 3, "Alexandria", "~/images/library-alexandria-anniversary-closure.jpg" },
                    { 4, "Luxor", "~/images/low-angle-shot-main-entrance-temple-horus-edfu-egypt.jpg" },
                    { 5, "Aswan", "~/images/shot-numerous-boats-berthed-by-pier-straight-lines-sunset.jpg" },
                    { 6, "Sharm El Sheikh", "~/images/beautiful-tropical-beach-sea-ocean-with-coconut-palm-tree-umbrella-chair-blue-sky-white-cloud.jpg" },
                    { 7, "Hurghada", "~/images/scenic-view-private-sandy-beach-with-sun-beds-parasokamy-sea-mountains-resort.jpg" },
                    { 8, "Fayoum", "~/images/Fayoum/WaterfallsofWadiElRayan.jpg" },
                    { 9, "Sinai", "~/images/raimond-klavins-zfeY8HkSAOE-unsplash.jpg" },
                    { 10, "Marsa Alam", "~/images/caption.jpg" },
                    { 11, "Matrouh", "~/images/date-palms-oasis-sahara-desert.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "CityId", "Description", "DestinationName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "Home to the world's largest collection of ancient Egyptian artifacts, including the treasures of Tutankhamun and over 120,000 items spanning 5,000 years of Egyptian history.", "Egyptian Museum", "~/images/Cairo/EgyptionMuseum.jpg" },
                    { 2, 1, "A 187-meter tall tower offering panoramic views of Cairo, featuring a revolving restaurant at the top and designed to resemble a lotus flower.", "Cairo Tower", "~/images/Cairo/CairoTower.jpg" },
                    { 3, 1, "One of Cairo's oldest mosques and a center of Islamic learning for over a millennium, featuring stunning Fatimid architecture and beautiful courtyards.", "Al-Azhar Mosque", "~/images/Cairo/Alazhar.jpg" },
                    { 4, 1, "A historic bazaar dating back to 1382, filled with traditional shops, spice vendors, jewelry stores, and cafes in the heart of Islamic Cairo.", "Khan El Khalili", "~/images/Cairo/KhanKhalili.jpg" },
                    { 5, 1, "A medieval Islamic fortification built in the 12th century, housing the magnificent Muhammad Ali Mosque and offering sweeping views of Cairo.", "Citadel of Saladin", "~/images/Cairo/CitiadelofSalah.jpg" },
                    { 6, 1, "One of the oldest and largest mosques in Cairo, built in 879 AD, featuring a unique spiral minaret and spacious courtyard with stunning Islamic architecture.", "Ibn Tulun Mosque", "~/images/Cairo/CairoIbnTulunMoschee.jpg" },
                    { 7, 1, "A museum showcasing the rich history of Coptic Christianity in Egypt with manuscripts, textiles, icons, and artifacts from the Roman era to Islamic period.", "Coptic Museum", "~/images/Cairo/CopticMuseum.jpg" },
                    { 8, 1, "A historic street in Islamic Cairo lined with magnificent mosques, madrasas, and medieval architecture, recognized as one of the greatest concentrations of Islamic monuments in the world.", "Al-Muizz Street", "~/images/Cairo/al muizz.jpg" },
                    { 9, 2, "The last surviving wonder of the ancient world, featuring the Great Pyramid of Khufu, Pyramid of Khafre, and Pyramid of Menkaure, built over 4,500 years ago.", "Giza Pyramids", "~/images/Giza/Giza Pyramids.jpg" },
                    { 10, 2, "A colossal limestone statue with a lion's body and human head, standing guard at the Giza pyramid complex for millennia.", "Great Sphinx", "~/images/Giza/Great Sphinx.jpg" },
                    { 11, 2, "The oldest complete stone building complex known in history, built for Pharaoh Djoser around 2630 BC by architect Imhotep.", "Saqqara Step Pyramid", "~/images/Giza/Saqqara Step Pyramid.jpg" },
                    { 12, 2, "An outdoor museum showcasing artifacts from ancient Memphis, Egypt's first capital, including a massive limestone statue of Ramses II.", "Memphis Open-Air Museum", "~/images/Giza/Memphis Open-Air Museum.jpg" },
                    { 13, 2, "Home to the Bent Pyramid and Red Pyramid, offering a quieter alternative to Giza with well-preserved structures and fewer crowds.", "Dahshur Pyramids", "~/images/Giza/Dahshur Pyramids.jpg" },
                    { 14, 2, "Houses a reconstructed ancient Egyptian boat that was buried at the foot of the Great Pyramid, intended to carry Khufu through the afterlife.", "Solar Boat Museum", "~/images/Giza/Khufuship.jpg" },
                    { 15, 3, "A stunning modern library and cultural center built to commemorate the ancient Library of Alexandria, featuring millions of books and multiple museums.", "Bibliotheca Alexandrina", "~/images/Alex/Bibliotecha.jpg" },
                    { 16, 3, "A 15th-century defensive fortress built on the exact site of the ancient Lighthouse of Alexandria, one of the Seven Wonders of the Ancient World.", "Qaitbay Citadel", "~/images/Alex/CitadelofQaitbay.jpg" },
                    { 17, 3, "Sprawling royal gardens along the Mediterranean coast featuring beautiful landscapes, beaches, and the former summer residence of Egyptian royalty.", "Montaza Palace Gardens", "~/images/Alex/MontazaPalacegarden.jpg" },
                    { 18, 3, "A museum housed in an Italian-style palace, displaying artifacts from Alexandria's Pharaonic, Roman, Coptic, and Islamic periods.", "Alexandria National Museum", "~/images/Alex/AlexandriaNationalMuseum.jpg" },
                    { 19, 3, "A massive 27-meter red granite column erected in 297 AD, the largest ancient monument in Alexandria and a remnant of the Serapeum temple.", "Pompey's Pillar", "~/images/Alex/PompeysPillar.jpg" },
                    { 20, 3, "A modern landmark bridge along Alexandria's Corniche, beautifully illuminated at night and offering spectacular Mediterranean Sea views.", "Stanley Bridge", "~/images/Alex/StanleybridgeinAlexandria.jpg" },
                    { 21, 3, "A historical archaeological site featuring a complex of tombs blending Roman, Greek, and Egyptian cultural elements, dating from the 2nd century AD.", "Catacombs of Kom el Shoqafa", "~/images/Alex/CornicheAlexandria.jpg" },
                    { 22, 3, "A well-preserved Roman theater discovered in 1960, featuring marble seating, mosaic floors, and remains of ancient baths and villas.", "Roman Amphitheatre", "~/images/Alex/CornicheAlexandria.jpg" },
                    { 23, 4, "The largest ancient religious complex ever built, covering over 200 acres with massive columns, obelisks, and the famous Great Hypostyle Hall.", "Karnak Temple", "~/images/Luxuor/Karnak.jpg" },
                    { 24, 4, "A magnificent temple complex built around 1400 BC, beautifully illuminated at night and connected to Karnak by the ancient Avenue of Sphinxes.", "Luxor Temple", "~/images/Luxuor/Louxordromospylône.jpeg" },
                    { 25, 4, "An ancient necropolis containing 63 tombs of pharaohs including Tutankhamun, adorned with intricate hieroglyphics and colorful wall paintings.", "Valley of the Kings", "~/images/Luxuor/LuxorTalderKönige.jpg" },
                    { 26, 4, "A stunning mortuary temple built for Egypt's most successful female pharaoh, featuring three terraced levels carved into limestone cliffs.", "Hatshepsut Temple", "~/images/Luxuor/TemploHatshepsut.jpg" },
                    { 27, 4, "Two massive stone statues of Pharaoh Amenhotep III, standing 18 meters tall and guarding the entrance to his mortuary temple for 3,400 years.", "Colossi of Memnon", "~/images/Luxuor/Hotairballooning.jpg" },
                    { 28, 4, "A world-class museum displaying carefully curated artifacts from Thebes and the surrounding area, including royal mummies and exquisite statuary.", "Luxor Museum", "~/images/Luxuor/LuxorMuseum.jpg" },
                    { 29, 4, "An ancient burial site for queens and royal children, featuring beautifully decorated tombs including the famous tomb of Queen Nefertari.", "Valley of the Queens", "~/images/Luxuor/NileinLuxor.jpg" },
                    { 30, 4, "The mortuary temple of Ramses III, one of the best-preserved temples in Egypt with massive walls covered in detailed battle scenes and hieroglyphics.", "Medinet Habu", "~/images/Luxuor/NileinLuxor.jpg" },
                    { 31, 5, "An enchanting temple complex dedicated to the goddess Isis, relocated to Agilkia Island and beautifully preserved with stunning hieroglyphics and columns.", "Philae Temple", "~/images/Aswan/PhilaeTemple.jpg" },
                    { 32, 5, "A massive engineering marvel completed in 1970, controlling Nile flooding and creating Lake Nasser, one of the world's largest artificial lakes.", "Aswan High Dam", "~/images/Aswan/AswanHighDamNorth.jpg" },
                    { 33, 5, "An award-winning museum showcasing the rich history and culture of Nubia, with artifacts spanning from prehistoric times to the present day.", "Nubian Museum", "~/images/Aswan/NubianMuseum.jpg" },
                    { 34, 5, "A massive obelisk still attached to its bedrock, offering unique insights into ancient Egyptian stone-working techniques and quarrying methods.", "Unfinished Obelisk", "~/images/Aswan/UnfinishedObeliskinAswan.jpg" },
                    { 35, 5, "An ancient island settlement containing Nubian villages, archaeological ruins, and the Aswan Museum, set in the middle of the Nile River.", "Elephantine Island", "~/images/Aswan/Elephantine.jpeg" },
                    { 36, 5, "Two massive rock-cut temples built by Ramses II, featuring four colossal statues at the entrance and relocated to save them from Lake Nasser.", "Abu Simbel Temples", "~/images/Aswan/TemploRamsésIIAbu_Simbel.jpg" },
                    { 37, 5, "Colorful traditional villages where Nubian culture thrives, offering authentic experiences with local crafts, music, cuisine, and warm hospitality.", "Nubian Village", "~/images/Aswan/NubianVillage.jpg" },
                    { 38, 6, "Egypt's first national park featuring pristine coral reefs, diverse marine life, and stunning desert landscapes at the southern tip of the Sinai Peninsula.", "Ras Mohammed National Park", "~/images/SharmElshiekh/RasMuhammad.jpg" },
                    { 39, 6, "A vibrant beachfront promenade lined with restaurants, shops, and hotels, offering crystal-clear waters perfect for swimming and snorkeling.", "Naama Bay", "~/images/SharmElshiekh/NaamaBay.jpg" },
                    { 40, 6, "A modern entertainment complex featuring restaurants, ice skating, fountains, open-air cinema, and nightly cultural shows in a beautifully designed plaza.", "SOHO Square", "~/images/SharmElshiekh/SOHOSquare.jpg" },
                    { 41, 6, "A traditional Egyptian bazaar offering authentic shopping experiences with spices, textiles, souvenirs, and local handicrafts at bargain prices.", "Old Market", "~/images/SharmElshiekh/SharmElSheikhOldMarket.jpg" },
                    { 42, 6, "A tranquil beach area known for its excellent diving and snorkeling spots, with easy access to beautiful coral reefs and marine life.", "Shark's Bay", "~/images/SharmElshiekh/SharksBay.jpeg" },
                    { 43, 6, "A breathtaking island famous for its crystal-clear waters, rich coral reefs, and vibrant marine life—one of Sharm El Sheikh’s top snorkeling and diving destinations.", "Tiran Island", "~/images/SharmElshiekh/TiranIsland.jpg" },
                    { 44, 7, "A protected marine reserve with pristine white sandy beaches, crystal-clear turquoise waters, and some of the Red Sea's best snorkeling spots.", "Giftun Island", "~/images/Hurghada/Giftunisland.jpg" },
                    { 45, 7, "A modern waterfront development featuring luxury yachts, upscale restaurants, boutique shops, and vibrant nightlife along scenic boardwalks.", "Hurghada Marina", "~/images/Hurghada/HurghadaMarina.jpg" },
                    { 46, 7, "The historic heart of Hurghada with traditional Egyptian markets, authentic local eateries, and a glimpse into the city's fishing village origins.", "El Dahar Old Town", "~/images/Hurghada/SahlHasheesh.jpg" },
                    { 47, 7, "An impressive open-air museum featuring over 40 intricate sand sculptures depicting historical figures, mythology, and Egyptian landmarks.", "Sand City Hurghada", "~/images/Hurghada/ElGouna.jpg" },
                    { 48, 7, "A state-of-the-art aquarium showcasing Red Sea marine life, rainforest exhibits, and interactive experiences with diverse aquatic species.", "Hurghada Grand Aquarium", "~/images/Hurghada/Grand Aquarium.jpg" },
                    { 49, 7, "One of Africa's largest water parks featuring thrilling slides, wave pools, lazy rivers, and family-friendly attractions spread across 50 attractions.", "Makadi Water World", "~/images/Hurghada/MakadiBay.jpg" },
                    { 50, 8, "Egypt's only natural waterfalls, created when two artificial lakes were connected, surrounded by stunning desert landscapes and diverse wildlife.", "Wadi El Rayan Waterfalls", "~/images/Fayoum/WaterfallsofWadiElRayan.jpg" },
                    { 51, 8, "A UNESCO World Heritage Site known as Valley of the Whales, containing fossils of ancient whales that demonstrate their evolution from land mammals.", "Wadi El Hitan", "~/images/Fayoum/DimihElseba.jpg" },
                    { 52, 8, "Egypt's third-largest lake and oldest natural lake, offering birdwatching opportunities, fishing, and scenic desert views dating back 70 million years.", "Qarun Lake", "~/images/Fayoum/QarunLake.jpg" },
                    { 53, 8, "A charming artistic village known for pottery workshops, galleries, eco-lodges, and stunning views of Lake Qarun and surrounding landscapes.", "Tunis Village", "~/images/Fayoum/TunisVillage.jpg" },
                    { 54, 8, "An archaeological museum displaying artifacts from ancient Fayoum, including Greco-Roman period findings and the famous Fayoum portraits.", "Kom Oshim Museum", "~/images/Fayoum/HawaraPyramid.jpeg" },
                    { 55, 8, "A well-preserved Middle Kingdom temple dedicated to the serpent goddess Renenutet, featuring intact stone structures and ancient reliefs.", "Madinet Madi Temple", "~/images/Fayoum/MagicLake.jpg" },
                    { 56, 9, "A sacred mountain where Moses is believed to have received the Ten Commandments, offering spectacular sunrise views and spiritual significance to three major religions.", "Mount Sinai", "~/images/Sinai/sinaiMount.jpeg" },
                    { 57, 9, "The world's oldest continuously functioning Christian monastery, built in the 6th century and housing priceless icons, manuscripts, and the alleged burning bush.", "Saint Catherine's Monastery", "~/images/Sinai/Katharinenkloster.jpg" },
                    { 58, 9, "A stunning natural wonder featuring narrow passages between towering walls of multicolored sandstone in shades of red, yellow, purple, and gold.", "Colored Canyon", "~/images/Sinai/AbuGalumProtectorate.jpg" },
                    { 59, 9, "A world-famous diving site consisting of a 130-meter deep submarine sinkhole with crystal-clear waters and vibrant coral formations.", "Blue Hole Dahab", "~/images/Sinai/theBlueHole.jpg" },
                    { 60, 9, "A protected area of pristine beaches, coral reefs, and rugged mountains, accessible only by camel or foot, offering untouched natural beauty.", "Abu Galum Reserve", "~/images/Sinai/AbuGalumProtectorate.jpg" },
                    { 61, 9, "A historic Ottoman fortress overlooking the Gulf of Aqaba, offering insights into the region's strategic military history and coastal defense systems.", "Nuweiba Castle", "~/images/Sinai/Nuweiba.jpg" },
                    { 62, 10, "A sheltered bay famous for swimming with sea turtles and dugongs in crystal-clear shallow waters, ideal for snorkeling and underwater photography.", "Abu Dabbab Bay", "~/images/MarsaAlam/Abu_Dabbab.jpg" },
                    { 63, 10, "A horseshoe-shaped reef known for resident pods of spinner dolphins, offering unforgettable opportunities to swim alongside these playful marine mammals.", "Sataya Dolphin Reef", "~/images/MarsaAlam/Sataya Dolphin Reef.jpg" },
                    { 64, 10, "One of the northernmost mangrove forests on Earth, featuring unique ecosystems with diverse birdlife and marine species in protected coastal waters.", "El Qulan Mangrove Forest", "~/images/MarsaAlam/Qulan.jpg" },
                    { 65, 10, "A vast protected area encompassing desert mountains, pristine beaches, coral reefs, and Bedouin heritage sites along 60 kilometers of coastline.", "Wadi El Gemal National Park", "~/images/MarsaAlam/Wadi_el_Gemal.jpg" },
                    { 66, 10, "A luxurious resort marina offering waterfront dining, shopping, yacht charters, and diving excursions in an elegant Mediterranean-style setting.", "Port Ghalib Marina", "~/images/MarsaAlam/PortGhalibMarina.jpg" },
                    { 67, 10, "A protected horseshoe-shaped reef sanctuary where spinner dolphins rest during the day, offering regulated swimming encounters with these graceful creatures.", "Samadai Dolphin House", "~/images/MarsaAlam/samadi.jpg" },
                    { 68, 11, "A stunning beach surrounded by natural rock formations creating a protected swimming cove, where Cleopatra allegedly bathed during her visits.", "Cleopatra Beach", "~/images/Matrouh/Cleopatra.jpg" },
                    { 69, 11, "A scenic coastal promenade stretching along pristine Mediterranean beaches with turquoise waters, cafes, and stunning sunset views.", "Marsa Matrouh Corniche", "~/images/Matrouh/Marsa Matrouh Corniche.jpg" },
                    { 70, 11, "A beautiful white sand beach with crystal-clear shallow waters, perfect for families and swimmers seeking a peaceful Mediterranean coastal experience.", "Al Aghla Beach", "~/images/Matrouh/Algbla beach.jpg" },
                    { 71, 11, "A museum documenting the North African Campaign of World War II, featuring military artifacts, weapons, and exhibits about the desert battles.", "Matrouh War Museum", "~/images/Matrouh/warmuseum.webp" },
                    { 72, 11, "Located in a cave used as Field Marshal Rommel's headquarters during WWII, displaying military equipment and information about the Desert Fox's campaigns.", "Rommel Museum", "~/images/Matrouh/Rommel.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "CityId", "TripDescription", "TripName", "TripPrice" },
                values: new object[,]
                {
                    { 1, 1, "Explore the ancient wonders of Cairo including the Egyptian Museum, Cairo Tower, and Khan El Khalili bazaar.", "Cairo Historical Adventure", 2500m },
                    { 2, 2, "Visit the iconic Pyramids of Giza, Great Sphinx, and Saqqara Step Pyramid.", "Giza Pyramids & Sphinx", 1800m },
                    { 3, 3, "Discover Alexandria's Greco-Roman history including Bibliotheca Alexandrina, Qaitbay Citadel, and Pompey's Pillar.", "Alexandria Heritage Tour", 2300m },
                    { 4, 4, "A cultural journey through Luxor’s famous temples and the Valley of the Kings.", "Luxor Temple Discovery", 3200m },
                    { 5, 5, "Enjoy a luxury cruise along the Nile from Aswan to Kom Ombo, visiting Philae Temple and High Dam.", "Aswan Nile Cruise", 4000m },
                    { 6, 6, "Experience world-class diving and snorkeling in the Red Sea with a relaxing resort stay.", "Sharm El-Sheikh Diving Tour", 3500m },
                    { 7, 7, "Relax on the stunning beaches of Hurghada with optional water sports and desert safari.", "Hurghada Beach Escape", 2800m },
                    { 8, 8, "A relaxing eco-trip exploring Wadi El Rayan waterfalls and Qarun Lake.", "Fayoum Nature Escape", 2000m },
                    { 9, 9, "Explore Mount Sinai, Saint Catherine’s Monastery, and the beautiful Colored Canyon.", "Sinai Adventure Package", 3700m },
                    { 10, 10, "Dive into the crystal-clear waters of Marsa Alam to explore colorful marine life and visit Wadi El Gemal National Park.", "Marsa Alam Coral Reefs Tour", 4600m },
                    { 11, 11, "Relax on the stunning white sandy beaches of Cleopatra Beach and Al Aghla, explore the historic Rommel Museum, and enjoy the beautiful turquoise waters along Marsa Matrouh Corniche.", "Matrouh Mediterranean Escape", 3800m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CityId",
                table: "Trips",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
