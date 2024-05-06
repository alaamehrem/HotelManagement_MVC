using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class DiningRepo : IDiningRepo
    {
        public HotelContext context;
        public DiningRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
