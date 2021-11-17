using HotelMgtModel.Dtos.AuthDtos;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
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
                var log = await _authenticationService.Login(login);
                if (log != null)
                    return RedirectToAction("Index","Home");
            }
            ViewBag.Error = "Error occur, pls check all required fields and try again";
            return View(login);
        }
    }
}
