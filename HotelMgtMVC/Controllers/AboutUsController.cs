using Microsoft.AspNetCore.Mvc;

namespace HotelMgtMVC.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
