using Microsoft.AspNetCore.Mvc;
using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using HotelManagement_MVC.Repository;

namespace HotelManagement_MVC.Controllers
{
    public class CartController : Controller
    {
        ICartRepo CartRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CartController(ICartRepo CartRepo, IWebHostEnvironment webHostEnvironment, IConfiguration configuration,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.CartRepo = CartRepo;
        }

        public IActionResult GetAll()
        {
            List<Cart> cartList = CartRepo.GetAll();
            return PartialView("_CartSidebar", cartList);
        }

        // This action confirms the cart and initiates payment
        public async Task<IActionResult> ConfirmCart()
        {
            if (User.Identity.IsAuthenticated == true) //If the user is not logedin redirect the view to the login
            {

                Claim ClaimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string Id = ClaimId.Value;
                Cart cart = CartRepo.GetCartByGuestId(Id);
                if (cart == null)
                {
                    return NotFound(); // Handle case where cart is not found
                }

                cart.paymentStatus = Enums.PaymentStatus.Pending; // Assuming you have a PaymentStatus enum
                CartRepo.Update(cart);
                CartRepo.Save();

                // Call CreatePaymentIntent method
                var paymentUrl = await CreatePaymentIntent(cart);

                if (!string.IsNullOrEmpty(paymentUrl))
                {
                    // Redirect user to payment page
                    return Redirect(paymentUrl);
                }
                else
                {
                    // Handle payment creation failure
                    return RedirectToAction("PaymentError");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // This method creates the payment intent
        private async Task<string> CreatePaymentIntent(Cart cart)
        {
            var paymobApiKey = _configuration["Paymob:ApiKey"];
            var paymobBaseUrl = "https://accept.paymobsolutions.com/api";

            using (var client = new HttpClient())
            {
                // Step 1: Authentication
                var authContent = new StringContent(
                    $"{{\"api_key\":\"{paymobApiKey}\"}}",
                    Encoding.UTF8,
                    "application/json");
                var authResponse = await client.PostAsync($"{paymobBaseUrl}/auth/tokens", authContent);
                if (!authResponse.IsSuccessStatusCode)
                {
                    // Handle authentication failure
                    return null;
                }

                var authResult = JObject.Parse(await authResponse.Content.ReadAsStringAsync());
                var token = authResult["token"].ToString();
                var amount = cart.ShippingPrice * 100; // Convert amount to cents

                // Construct the request body
                var requestBody = new
                {
                    auth_token = token,
                    delivery_needed = false,
                    amount_cents = amount, // Use the cart total as the amount
                    currency = "EGP",
                    items = new List<Object>(),
                };

                // Serialize the request body
                var requestBodyJson = JsonConvert.SerializeObject(requestBody);

                // Step 2: Create Order
                var orderContent = new StringContent(
                    requestBodyJson,
                    Encoding.UTF8,
                    "application/json");

                var orderResponse = await client.PostAsync($"{paymobBaseUrl}/ecommerce/orders", orderContent);
                if (!orderResponse.IsSuccessStatusCode)
                {
                    // Handle order creation failure
                    var errorMessage = await orderResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Order creation failed: {errorMessage}");
                    return null;
                }

                var orderResult = JObject.Parse(await orderResponse.Content.ReadAsStringAsync());
                var orderId = orderResult["id"].ToString();

                // Step 3: Create Payment Key
                var paymentKeyContent = new
                {
                    auth_token = token,
                    amount_cents = amount,
                    expiration = 3600,
                    order_id = orderId,
                    billing_data = new
                    {
                        apartment = "NA",
                        email = "NA",
                        floor = "NA",
                        first_name = "NA",
                        street = "NA",
                        building = "NA",
                        phone_number = "NA",
                        shipping_method = "NA",
                        postal_code = "NA",
                        city = "NA",
                        country = "NA",
                        last_name = "NA",
                        state = "NA"
                    },
                    currency = "EGP",
                    integration_id = 4579761
                };
                var paymentKeyContentJson = JsonConvert.SerializeObject(paymentKeyContent);
                var paymentContent = new StringContent(paymentKeyContentJson,Encoding.UTF8,"application/json");

                var paymentKeyResponse = await client.PostAsync($"{paymobBaseUrl}/acceptance/payment_keys", paymentContent);
                if (!paymentKeyResponse.IsSuccessStatusCode)
                {
                    // Handle payment key creation failure
                    var errorMessage = await paymentKeyResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Payment key creation failed: {errorMessage}");
                    return null;
                }

                var paymentKeyResult = JObject.Parse(await paymentKeyResponse.Content.ReadAsStringAsync());
                var paymentKey = paymentKeyResult["token"].ToString();

                // Redirect to payment
                return $"https://accept.paymobsolutions.com/api/acceptance/iframes/847676?payment_token={paymentKey}";
            }
        }
    }
}

