using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_MVC.Models
{

    public class HotelContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> HotelSet { get; set; }

        //public DbSet<HotelRoom> Room { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options)
          : base(options)  { }//inject ==>IOC resolve

        //fill some data in table flut api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Id(PK) ,HotelName, Location, Gallery, PhoneNum, Description.
            modelBuilder.Entity<Hotel>().HasData(new Hotel() 
            { Id=1,Images="1.png",Description="Very Good", Location="Cairo", Name="ITI", Phone="12338587"});

            base.OnModelCreating(modelBuilder);

        }


    }
}
