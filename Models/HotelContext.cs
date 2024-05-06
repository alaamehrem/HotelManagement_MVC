using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            base.OnModelCreating(modelBuilder);

        }


    }
}
