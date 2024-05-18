using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.ViewModel;
using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using Newtonsoft.Json;
using HotelManagement_MVC.Repository;

namespace HotelManagement_MVC.Controllers
{
    public class BookingDiningController : Controller
    {
        IBookingDiningRepo BookingDiningRepo;
        IWebHostEnvironment webHostEnvironment;
        ICartRepo CartRepo;

        public BookingDiningController(IBookingDiningRepo BookingDiningRepo,ICartRepo cartRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.BookingDiningRepo = BookingDiningRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.CartRepo = cartRepo;
        }
        [HttpPost]
        public IActionResult SaveNew(int id, BookingDiningVM bookingDiningVM)
        {

                var dining = BookingDiningRepo.GetDiningById(id);
                if (dining == null)
                {
                return RedirectToAction("GetAll", "Dining"); // Or handle the error as appropriate
            }
                var bookingDining = new BookingDining
                {
                    Date = bookingDiningVM.Date,
                    NumAdults = bookingDiningVM.NumAdults,
                    SpecialRequest = bookingDiningVM.SpecialRequest,
                    GuestId = 1, // WILL CHANGE TO ACTUAL GUEST ID
                    Price = dining.Price,
                    DiningId = dining.Id
                    // Additional properties related to dining can be set here if needed
                };
            // Add the new booking to the cart
            var cart = CartRepo.GetCartByGuestId(bookingDining.GuestId); // Assuming a method exists to get the cart by guest ID
            if (cart != null)
            {
                if (cart.BookingDinings == null)
                {
                    cart.BookingDinings = new List<BookingDining>();
                }
                cart.BookingDinings.Add(bookingDining);

                // Calculate the total price of all booking items
                cart.ShippingPrice = (int)CartRepo.CalculateTotalPrice(cart);
            }
            BookingDiningRepo.Insert(bookingDining);
            BookingDiningRepo.Save();
            CartRepo.Update(cart);// Update the cart in the database
            CartRepo.Save();

            return RedirectToAction("GetAll", "Dining"); // Redirect to a success page or another action
        }
    }
}
