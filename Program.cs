using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HotelContext>();


            builder.Services.AddDbContext<HotelContext>(
                Options => Options.
                UseSqlServer(builder.Configuration.GetConnectionString("cs")));//inject Dbcontext & inject Hotelcontext

            builder.Services.AddScoped<IAdminRepo, AdminRepo>();
            builder.Services.AddScoped<IHotelFloorRepo, HotelFloorRepo>();
            builder.Services.AddScoped<IHotelRoomRepo, HotelRoomRepo>();
            builder.Services.AddScoped<IBookingDiningRepo, BookingDiningRepo>();
            builder.Services.AddScoped<IBookingRoomRepo, BookingRoomRepo>();
            builder.Services.AddScoped<IDiningRepo, DiningRepo>();
            builder.Services.AddScoped<IExperienceRepo, ExperienceRepo>();
            builder.Services.AddScoped<IGuestRepo, GuestRepo>();
            builder.Services.AddScoped<IHotelReviewRepo, HotelReviewRepo>();
            builder.Services.AddScoped<IHotelRoomTypeRepo, HotelRoomTypeRepo>();
            builder.Services.AddScoped<IOfferRepo, OfferRepo>();
            builder.Services.AddScoped<IBookingExperienceRepo, BookingExperienceRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
