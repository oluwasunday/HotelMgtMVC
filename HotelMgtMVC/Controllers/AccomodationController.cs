using HotelMgtModel.ViewModels;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class AccomodationController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;

        public AccomodationController(IRoomTypeService roomTypeService, IRoomService roomService)
        {
            _roomTypeService = roomTypeService;
            _roomService = roomService;
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

        public IActionResult Book()
        {
            return View();
        }
    }
}
