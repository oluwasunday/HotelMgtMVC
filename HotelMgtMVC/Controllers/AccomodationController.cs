using HotelMgtModel.ViewModels;
using HotelMgtMVC.Dtos;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class AccomodationController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public AccomodationController(IRoomTypeService roomTypeService, IRoomService roomService, IBookingService bookingService)
        {
            _roomTypeService = roomTypeService;
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypes = await _roomTypeService.GetRoomTypesAsync();
            var rooms = await _roomService.GetRoomsAsync();

            var accVm = new AccomodationViewModel() { RoomTypes = roomTypes.ToList(), Rooms = rooms.ToList()};
            return View(accVm);
        }

        public async Task<IActionResult> RoomDetails(string roomTypeId)
        {
            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(roomTypeId);
            var rooms = await _roomService.GetRoomByRoomTypeIdAsync(roomTypeId);
            var amenities = await _roomTypeService.GetAmenitiesForRoomTypeIdAsync(roomTypeId);

            var accVm = new RoomTypeDetailsViewModel() { RoomType = roomType, Rooms = rooms.ToList(), Amenities = amenities.ToList() };
            return View(accVm);
        }

        //public IActionResult Book()
        //{
        //    return View();
        //}

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Book(AddBookingDto bookingDto)
        {
            var user = HttpContext.Session.GetString("User");
            if(user == null)
                return RedirectToAction("Login", "Authentication");

            var book = await _bookingService.BookAsync(bookingDto);
            if (book.Succeeded)
                return Redirect(book.Data.AuthorizationUrl);

            ViewBag.Error = book.Message;
            ModelState.AddModelError(string.Empty, book.Message);
            return View();
        }

        [HttpGet("SuccessBooking")]
        public IActionResult SuccessBooking()
        {
            return View();
        }
    }
}
