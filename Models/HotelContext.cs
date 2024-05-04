using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_MVC.Models
{
    public class HotelContext:IdentityDbContext<ApplicationUser>
    {
        //public DbSet<HotelRoom> Room { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options)
          : base(options)  { }//inject ==>IOC resolve

        //fill some data in table flut api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
        }
}
