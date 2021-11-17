using HotelMgtModel.Dtos;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(AddContactUsDto contactUsDto)
        {
            var req = await _contactService.AddContactUsAsync(contactUsDto);
            if(req != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Something went wrong, try again";
            return View();
        }
    }
}
