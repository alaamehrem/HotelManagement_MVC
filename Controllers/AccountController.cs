using HotelManagement_MVC.Models;
using HotelManagement_MVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelManagement_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //create user
        [HttpGet]//open link
        public IActionResult register()
        {
            return View("register");
        }

        [HttpPost]//Press submit
        public async Task<IActionResult> register(RegisterViewModel userFromReq)
        {
            //save to database
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                //mapping           
                user.UserName = userFromReq.Username;
                user.PasswordHash = userFromReq.Password;
                user.Email = userFromReq.Email;
                user.PhoneNumber = userFromReq.Phone;
                user.Fname = userFromReq.Fname;
                user.Lname = userFromReq.Lname;
                user.Address = userFromReq.Address;
                //add user database ==>usermanager
                IdentityResult result = await userManager.CreateAsync(user, userFromReq.Password);
                if (result.Succeeded == true)
                {
                    //add role Admin
                    //IdentityResult roleResult = await userManager.AddToRoleAsync(user, "Admin");
                    //create cookie //id,name,role
                    await signInManager.SignInAsync(user, false);//session cookie
                    return RedirectToAction("Index", "Home");
                }
                //fail to save database
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            //data wrong 
            return View("register", userFromReq);
        }
        //login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel UserFromReq)
        {
            if (ModelState.IsValid)
            {
                //check
                ApplicationUser userFromDb = await userManager.FindByNameAsync(UserFromReq.Username);
                if (userFromDb != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userFromDb, UserFromReq.Password);
                    if (found == true)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userFromDb, UserFromReq.RememberMe);
                        //if i want to add something else in the cookie data from the user that is not assigned in signinManager
                        //as the defaulted data assigned in cookie is (id,name,role)
                        //List<Claim> claims = new List<Claim>();
                        //claims.Add(new Claim("Address", userFromDb.Address));
                        //await signInManager.SignInWithClaimsAsync(userFromDb, UserFromReq.RememberMe, claims);


                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login");
        }


        //Logout
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

