using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.IRepository;
using NuGet.Protocol.Plugins;
using HotelManagement_MVC.Models;
using Microsoft.AspNetCore.Identity;
namespace HotelManagement_MVC.ViewComponents
{
    public class CartSidebarViewComponent : ViewComponent
    {
        public ICartRepo _cartRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CartSidebarViewComponent(ICartRepo cartRepository , UserManager<ApplicationUser> userManager)
        {
            _cartRepository = cartRepository;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            List<Cart> cartList;
            if (User.Identity.IsAuthenticated != true) //If the user is not logedin redirect the view to the login
            {
                 cartList = null;
                return View(cartList);
            }
                 cartList = _cartRepository.GetAll();
            return View(cartList);
        }
    }
}