using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class OfferRepo : IOfferRepo
    {
        public HotelContext context;
        public OfferRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
