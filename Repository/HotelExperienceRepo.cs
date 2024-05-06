using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelExperienceRepo : IHotelExperienceRepo
    {
        public HotelContext context;
        public HotelExperienceRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
