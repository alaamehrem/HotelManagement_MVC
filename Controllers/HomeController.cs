using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using HotelManagement_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagement_MVC.Controllers
{
    public class HomeController : Controller
    {     
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelRoomTypeRepo hotelRoomTypeRepo;
        private readonly IExperienceRepo experienceRepo;
        private readonly IDiningRepo diningRepo;

        public HomeController(ILogger<HomeController> logger,IHotelRoomTypeRepo hotelRoomTypeRepo,IExperienceRepo experienceRepo,IDiningRepo diningRepo)
        {
            _logger = logger;
            this.hotelRoomTypeRepo = hotelRoomTypeRepo;
            this.experienceRepo = experienceRepo;
            this.diningRepo = diningRepo;
        }

        public IActionResult Index()
        {

            List<HotelRoomType> HotRoomTypList=hotelRoomTypeRepo.GetAll();
            return View(HotRoomTypList.GetRange(2,3));
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
            AllBookingEventsViewModel allBookingEventsViewModel = new AllBookingEventsViewModel();
            allBookingEventsViewModel.Dining = diningRepo.GetAll();
            allBookingEventsViewModel.Experience = experienceRepo.GetAll();
            allBookingEventsViewModel.HotelRoomType = hotelRoomTypeRepo.GetAll();
            return View(allBookingEventsViewModel);
        }

    }
}
