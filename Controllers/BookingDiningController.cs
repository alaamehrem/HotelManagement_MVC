using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class BookingDiningController : Controller
    {
        public IActionResult SaveNew()
        {
            return View();
        }
    }
}
