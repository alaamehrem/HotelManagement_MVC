using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class PrExperienceRepo : IPrExperienceRepo
    {
        public HotelContext context;
        public PrExperienceRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
