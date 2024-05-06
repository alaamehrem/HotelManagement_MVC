using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelDiningRepo :IHotelDiningRepo
    {
        public HotelContext context;
        public HotelDiningRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
