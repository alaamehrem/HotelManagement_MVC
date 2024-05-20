using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagement_MVC.Controllers
{
    public class HomeController : Controller
    {     
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelRoomTypeRepo hotelRoomTypeRepo;

        public HomeController(ILogger<HomeController> logger,IHotelRoomTypeRepo hotelRoomTypeRepo)
        {
            _logger = logger;
            this.hotelRoomTypeRepo = hotelRoomTypeRepo;
        }

        public IActionResult Index()
        {

            List<HotelRoomType> HotRoomTypList=hotelRoomTypeRepo.GetAll();
            return View(HotRoomTypList.GetRange(7,3));
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult AboutUs()
		{
			return View();
		}
        public IActionResult Calendar()
        {
            return View();
        }

    }
}
