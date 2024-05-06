using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelRepo : IHotelRepo
    {
        public HotelContext context;
        public HotelRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
