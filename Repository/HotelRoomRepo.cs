using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelRoomRepo : IHotelRoomRepo
    {
        public HotelContext context;
        public HotelRoomRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
