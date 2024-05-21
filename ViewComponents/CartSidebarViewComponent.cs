using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.IRepository;
using NuGet.Protocol.Plugins;
namespace HotelManagement_MVC.ViewComponents
{
    public class CartSidebarViewComponent : ViewComponent
    {
        private readonly ICartRepo _cartRepository;

        public CartSidebarViewComponent(ICartRepo cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cartList = _cartRepository.GetAll();
            return View(cartList);
        }
    }
}