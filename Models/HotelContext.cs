using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_MVC.Models
{
    public class HotelContext:IdentityDbContext<ApplicationUser>
    {  
        public DbSet<Guest> Guests { get; set; }
        //public HotelContext(DbContextOptions<HotelContext> options)
        //  : base(options)  { }//inject ==>IOC resolve

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");
        //fill some data in table flut api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
                               new Guest { Id = 1, Name = "Ahmed", Email = "ahmed@gmail.com", Address = "Cairo", Phone = "0120000000", Username = "ahmed", Password = "ahmed97" });
            base.OnModelCreating(modelBuilder);
        }
        }
}
