using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class HotelRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
