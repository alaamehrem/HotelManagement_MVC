using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.ViewModel;
using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Controllers
{
    public class BookingDiningController : Controller
    {
        IBookingDiningRepo BookingDiningRepo;
        IWebHostEnvironment webHostEnvironment;

        public BookingDiningController(IBookingDiningRepo BookingDiningRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.BookingDiningRepo = BookingDiningRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public IActionResult SaveNew(int diningId, BookingDiningVM bookingDiningVM)
        {
            if (ModelState.IsValid)
            {
                var dining = BookingDiningRepo.GetDiningById(diningId);
                if (dining == null)
                {
                    return View(); // Or handle the error as appropriate
                }

                var bookingDining = new BookingDining
                {
                    Id = diningId,
                    Date = bookingDiningVM.Date,
                    NumAdults = bookingDiningVM.NumAdults,
                    SpecialRequest = bookingDiningVM.SpecialRequest,
                    GuestId = 1, // WILL CHANGE TO ACTUAL GUEST ID
                    Price = dining.Price,
                    // Additional properties related to dining can be set here if needed
                };

                BookingDiningRepo.Insert(bookingDining);
                BookingDiningRepo.Save();

                return View("DiningDetails"); // Redirect to a success page or another action
            }
            return View();
        }
    }
}
