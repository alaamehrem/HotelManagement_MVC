using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class BookingRoomController : Controller
    {
        private readonly IBookingRoomRepo bookingRoomRepo;

        public BookingRoomController(IBookingRoomRepo bookingRoomRepo)
        {
            this.bookingRoomRepo = bookingRoomRepo;
        }


        [HttpGet]
        public IActionResult BookingRoom()
        {
            BookingRoom bookingRoom = new BookingRoom();

            return View("BookingRoom", bookingRoom);
        }

        [HttpPost]
        public IActionResult SaveNew(BookingRoom bookingRoom)
        {
            if (ModelState.IsValid)
            {
                bookingRoomRepo.Insert(bookingRoom);
                bookingRoomRepo.Save();

                return RedirectToAction("Index", "Home");
            }

            return View("BookingRoom", bookingRoom);
        }
    }
}
