using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
