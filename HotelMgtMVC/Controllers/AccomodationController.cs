using Microsoft.AspNetCore.Mvc;

namespace HotelMgtMVC.Controllers
{
    public class AccomodationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
