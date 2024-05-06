using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelOfferRepo : IHotelOfferRepo
    {
        public HotelContext context;
        public HotelOfferRepo(HotelContext _context)
        {
            context = _context;
        }
    }
}
