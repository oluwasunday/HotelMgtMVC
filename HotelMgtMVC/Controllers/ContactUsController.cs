using Microsoft.AspNetCore.Mvc;

namespace HotelMgtMVC.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
