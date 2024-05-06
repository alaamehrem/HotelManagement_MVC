using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelManagement_MVC.Models
{

    public class HotelContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BookingDining> BookingDinings { get; set; }
        public DbSet<BookingPrivateRetreat> BookingPrivateRetreats { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<Dining> Dinings { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelDining>  HotelDinings { get; set; }
        public DbSet<HotelExperience> HotelExperiences { get; set; }
        public DbSet<HotelFloor> HotelFloors { get; set; }
        public DbSet<HotelOffer> HotelOffers { get; set; }
        public DbSet<HotelReview> HotelReviews { get; set; }
        public DbSet<HotelRoomType> HotelRoomTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PrExperience> PrExperiences { get; set; }
        public DbSet<PrivateRetreat> PrivateRetreats { get; set; }
        public DbSet<PrOffer> PrOffers { get; set; }
        public DbSet<PrReview> PrReviews { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options)
          : base(options)  { }//inject ==>IOC resolve

        //fill some data in table flut api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoomType>().HasData(new HotelRoomType
            {
                Id =6,
                Name = "Premium King Room",
                Description = "Experience luxury and comfort in our Premium King Room, a corner room offering unparalleled views and deluxe amenities. Relax in a spacious environment featuring one King-size bed adorned with Frette Linens, a separate sitting area, and floor-to-ceiling windows showcasing breathtaking vistas. Stay productive with a full-size work desk and stay entertained with a large screen HDTV equipped with Google Chromecast. Pamper yourself in the luxurious marble shower and indulge in C.O Bigelow bath amenities. Perfect for discerning travelers seeking the ultimate in sophistication and relaxation.",
                Images = "PremiumKingRoom.jpg",
                BedCount = 1,
                BathCount = 1,
                MaxGuestCount = 2,
                Price = 6000,
                Area = 250,
                BedType = "Panel bed with plush Frette Linens",
                View = "Spectacular sea view from floor-to-ceiling windows",
                Decor = "Modern decor with elegant touches",
                UniqueFeatures = "Spacious corner room with abundant natural light, High-end furnishings and decor, Marble bathroom with luxurious jacuzzi bathtub, Complimentary high-speed Wi-Fi, In-room dining available 24/7, Personalized concierge service for all your needs."
            });


            base.OnModelCreating(modelBuilder);

        }


    }
}
