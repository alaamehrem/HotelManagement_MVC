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
        private readonly IOfferRepo offerRepo;
        private readonly IHotelRoomRepo hotelRoomRepo;
        private readonly IHotelRoomTypeRepo hotelRoomTypeRepo;
        private readonly IHotelFloorRepo hotelFloorRepo;

        public BookingRoomController(IBookingRoomRepo bookingRoomRepo,IOfferRepo offerRepo,
            IHotelRoomRepo hotelRoomRepo,IHotelRoomTypeRepo hotelRoomTypeRepo,IHotelFloorRepo hotelFloorRepo)
        {
            this.bookingRoomRepo = bookingRoomRepo;
            this.offerRepo = offerRepo;
            this.hotelRoomRepo = hotelRoomRepo;
            this.hotelRoomTypeRepo = hotelRoomTypeRepo;
            this.hotelFloorRepo = hotelFloorRepo;
        }


        [HttpGet]
        public IActionResult BookingRoom()
        {
            BookingRoom bookingRoom = new BookingRoom();
            ViewData["OfferList"] = offerRepo.GetAll();
            ViewData["FloorList"] = hotelFloorRepo.GetAll();
            ViewData["RoomTypeList"] = hotelRoomTypeRepo.GetAll();
            return View("BookingRoom",bookingRoom);
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
            ViewData["OfferList"] = offerRepo.GetAll();
            ViewData["FloorList"] = hotelFloorRepo.GetAll();
            ViewData["RoomTypeList"] = hotelRoomTypeRepo.GetAll();
            return View("BookingRoom", bookingRoom);
        }
    }
}
