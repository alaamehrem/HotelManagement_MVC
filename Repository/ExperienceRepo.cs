using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class ExperienceRepo : IExperienceRepo
    {
        public HotelContext context;
        public ExperienceRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
