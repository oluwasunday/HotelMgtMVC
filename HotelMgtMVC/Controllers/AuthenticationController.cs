using HotelMgtModel.Dtos.AuthDtos;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public static string role = string.Empty;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                var reg = await _authenticationService.Register(register);
                if(reg != null)
                    return Redirect("Index");
            }
            ViewBag.Error = "Error occur, pls check all required fields and try again";
            return View(register);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginDto login)
        {

            if (ModelState.IsValid)
            {
                var response = await _authenticationService.Login(login);
                var result = response.Data;

                if (result == null || !response.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, response.Message = "Invalid Credentials" ?? response.Message);
                    return View();
                }

                var user = new LoginResponseDto()
                {
                    Id = result.Claims.ElementAt(0).Value,
                    FirstName = result.Claims.ElementAt(2).Value,
                    LastName = result.Claims.ElementAt(3).Value,
                    Avatar = result.Claims.ElementAt(4).Value
                };

                var Role = result.Claims.ElementAt(5).Value;
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                if (Role == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to log you in at this time.");
                    return View();
                }
                else if (Role == "Manager" || Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin", new { userId = result.Id });
                }
                else if (Role == "Customer")
                {
                    ViewBag.LogInfo = new { userId = result.Id, email = result.Email, name = $"{user.FirstName} {user.LastName}" };
                    ViewBag.Username = $"{user.FirstName} {user.LastName}";
                    return RedirectToAction("Dashboard", "Home", ViewBag.LogInfo);//, new { userId = result.Id, email = result.Email, name = $"{user.FirstName} {user.LastName}" });
                }
            }
            ViewBag.Error = "Error occur, pls check all required fields and try again";
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("User");
            //HttpContext.Session.Abandon();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
