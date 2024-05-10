using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class BookingExperienceRepo : IBookingExperienceRepo
    {
        public HotelContext context;
        public BookingExperienceRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
