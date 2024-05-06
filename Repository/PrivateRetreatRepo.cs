using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class PrivateRetreatRepo : IPrivateRetreatRepo
    {
        public HotelContext context;
        public PrivateRetreatRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
