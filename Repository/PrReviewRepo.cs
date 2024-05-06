using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class PrReviewRepo : IPrReviewRepo
    {
        public HotelContext context;
        public PrReviewRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
