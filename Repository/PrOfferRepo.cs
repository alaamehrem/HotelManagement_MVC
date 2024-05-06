using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class PrOfferRepo : IPrOfferRepo
    {
        public HotelContext context;
        public PrOfferRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
