using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class HotelRoomTypeController : Controller
    {
        private readonly IHotelRoomTypeRepo HotelRoomTypeRepo;

        public HotelRoomTypeController(IHotelRoomTypeRepo HotelRoomTypeRepo)
        {
            this.HotelRoomTypeRepo = HotelRoomTypeRepo;
        }
        public IActionResult Index(string search) 
        {
            List<HotelRoomType> HotRoomTypList;
            if(!string.IsNullOrEmpty(search))
            {
                HotRoomTypList = HotelRoomTypeRepo.Search(search);
            }
            else
            {
                HotRoomTypList= HotelRoomTypeRepo.GetAll();
            }
            return View("Index",HotRoomTypList);
        }
    }
}
