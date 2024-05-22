using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using HotelManagement_MVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HotelManagement_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task <IActionResult> Index(string search, int pg = 1)
        {
            if (string.IsNullOrEmpty(search))
            {
                var users = userManager.Users.Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    FName = u.Fname,
                    LName = u.Lname,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    //Roles = userManager.GetRolesAsync(u).Result
                });
                const int pageSize = 5;
                if (pg < 1) pg = 1;
                int recsCount = users.Count();
                Pager pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = users.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                return View(data);
            }
            else
            {
               var user=await userManager.FindByNameAsync(search);
                var mappedUser = new UserViewModel()
                {
                    Id = user.Id,
                    FName = user.Fname,
                    LName = user.Lname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    //Roles = userManager.GetRolesAsync(user).Result
                };
                return View(mappedUser);
            }

        }
        public async Task<IActionResult> Details(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var mappedUser = new UserViewModel()
            {
                Id = user.Id,
                FName = user.Fname,
                LName = user.Lname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                //Roles = userManager.GetRolesAsync(user).Result
            };
            return View("Details", mappedUser);
        }

    }
}
