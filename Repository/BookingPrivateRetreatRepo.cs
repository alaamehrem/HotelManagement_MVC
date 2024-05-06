using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class BookingPrivateRetreatRepo : IBookingPrivateRetreatRepo
    {
        public HotelContext context;
        public BookingPrivateRetreatRepo(HotelContext _context)
        {
            context = _context;
        }

    }
}
