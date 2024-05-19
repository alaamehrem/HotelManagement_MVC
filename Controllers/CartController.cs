using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class CartController : Controller
    {
        ICartRepo CartRepo;
        IWebHostEnvironment webHostEnvironment;

        public CartController(ICartRepo CartRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.CartRepo = CartRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult GetAll()
        {
            List<Cart> CartList = CartRepo.GetAll();
            return View("AllCarts", CartList);
        }
        public IActionResult Details(int Id)
        {
            Cart cartFromDB = CartRepo.GetById(Id);
            return View("CartDetails", cartFromDB);
        }
        public IActionResult GetByGuestId(int Id) //May do it a SearchByUser
        {
            Cart Cart = CartRepo.GetCartByGuestId(Id);
            return View("CartDetails", Cart);
        }

    }
}
