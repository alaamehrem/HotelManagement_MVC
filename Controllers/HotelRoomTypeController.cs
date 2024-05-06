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
        public IActionResult RoomTypes(string search)
        {
            List<HotelRoomType> HotRoomTypList;
            if (!string.IsNullOrEmpty(search))
            {
                HotRoomTypList = HotelRoomTypeRepo.Search(search);
            }
            else
            {
                HotRoomTypList = HotelRoomTypeRepo.GetAll();
            }
            return View("RoomTypes", HotRoomTypList);
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

        public IActionResult Details(int Id)
        {
            HotelRoomType hotelRoomType = HotelRoomTypeRepo.GetById(Id);
            return View("Details",hotelRoomType);
        }

        [HttpGet]
        public IActionResult New()
        {
            HotelRoomType hotelRoomType = new HotelRoomType();

            return View("New", hotelRoomType);
        }
    }
}
