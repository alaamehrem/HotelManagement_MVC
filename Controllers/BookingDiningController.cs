using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.ViewModel;
using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using Newtonsoft.Json;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HotelManagement_MVC.Controllers
{
    public class BookingDiningController : Controller
    {
        IBookingDiningRepo BookingDiningRepo;
        IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        ICartRepo CartRepo;

        public BookingDiningController(IBookingDiningRepo BookingDiningRepo,ICartRepo cartRepo, IWebHostEnvironment webHostEnvironment, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.BookingDiningRepo = BookingDiningRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.CartRepo = cartRepo;
        }
        [HttpPost]
        public IActionResult SaveNew(int id, BookingDiningVM bookingDiningVM )
        {

                var dining = BookingDiningRepo.GetDiningById(id);
                if (dining == null)
                {
                return RedirectToAction("GetAll", "Dining"); // Or handle the error as appropriate
                 }

            if (User.Identity.IsAuthenticated == true) //If the user is not logedin redirect the view to the login
            {

                Claim ClaimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string Id = ClaimId.Value;
                var bookingDining = new BookingDining
                {
                    Date = bookingDiningVM.Date,
                    NumAdults = bookingDiningVM.NumAdults,
                    SpecialRequest = bookingDiningVM.SpecialRequest,
                    ApplicationUserId = Id, // WILL CHANGE TO ACTUAL GUEST ID
                    Price = dining.Price,
                    DiningId = dining.Id
                    // Additional properties related to dining can be set here if needed
                };

                // Add the new booking to the cart
                var cart = CartRepo.GetCartByGuestId(Id); // Assuming a method exists to get the cart by guest ID

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
                CartRepo.Insert(cart);// Update the cart in the database
                CartRepo.Save();
            }
            return RedirectToAction("GetAll", "Dining"); // Redirect to a success page or another action
        }
    }
}
