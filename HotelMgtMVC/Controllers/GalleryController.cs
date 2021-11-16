using Microsoft.AspNetCore.Mvc;

namespace HotelMgtMVC.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
