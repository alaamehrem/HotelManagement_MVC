using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class BookingDiningRepo : IBookingDiningRepo
    {
        public HotelContext context;
        public BookingDiningRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
