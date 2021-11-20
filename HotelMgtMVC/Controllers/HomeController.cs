using HotelMgtModel.ViewModels;
using HotelMgtMVC.Models;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgtMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRatingService _ratingService;

        public HomeController(ILogger<HomeController> logger, IRoomTypeService roomTypeService, IRatingService ratingService)
        {
            _logger = logger;
            _roomTypeService = roomTypeService;
            _ratingService = ratingService;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypes = await _roomTypeService.GetRoomTypesAsync();
            var ratings = await _ratingService.GetRatingsAsync();

            var homeVm = new HomeViewModel() { RoomTypes = roomTypes.ToList(), Ratings = ratings.ToList()};
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
