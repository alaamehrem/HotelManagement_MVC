using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using HotelManagement_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;

namespace HotelManagement_MVC.Controllers
{
    public class DiningController : Controller
    {
        IDiningRepo DiningRepo;
        IWebHostEnvironment webHostEnvironment;

        public DiningController(IDiningRepo DiningRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.DiningRepo = DiningRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult GetAll()
        {
            List<Dining> DiningList = DiningRepo.GetAll();
            return View("AllDining", DiningList);
        }
        public IActionResult Search(string searchStr)
        {
            List<Dining> list = DiningRepo.Search(searchStr);
            if (searchStr != null)
            {
                List<Dining> newList = [];
                foreach (var item in list)
                {
                    if (item.Name.ToLower().Contains(searchStr.ToLower()))
                    {
                        newList.Add(item);
                    }
                }//Need To make this search view
                return View("Search", newList);
            }
            return RedirectToAction("AllDining");
        }
        public IActionResult Details(int Id,BookingDiningVM bookingDiningVM)
        {
            Dining diningFromDB = DiningRepo.GetById(Id);
            bookingDiningVM = new BookingDiningVM()
            {
                DiningId = diningFromDB.Id,
                Name = diningFromDB.Name,
                Duration = diningFromDB.Duration,
                Description = diningFromDB.Description,
                TimeOfDay = diningFromDB.TimeOfDay,
                Images = diningFromDB.Images,
                Price = diningFromDB.Price
            };
            return View("DiningDetails", bookingDiningVM);
        }

    }
}