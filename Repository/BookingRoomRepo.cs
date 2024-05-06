using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class BookingRoomRepo : IBookingRoomRepo
    {
        public HotelContext context;
        public BookingRoomRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
