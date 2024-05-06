using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelRoomTypeRepo : IHotelRoomTypeRepo
    {
        public HotelContext context;
        public HotelRoomTypeRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
