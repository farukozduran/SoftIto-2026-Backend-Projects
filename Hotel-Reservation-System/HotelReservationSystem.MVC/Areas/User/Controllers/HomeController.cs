using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.MVC.Areas.User.Controllers
{
    // Bu Controller'ın User Area'sına ait olduğunu belirtiyoruz
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomTypeService _roomTypeService;

        public HomeController(IHotelService hotelService, IRoomTypeService roomTypeService)
        {
            _hotelService = hotelService;
            _roomTypeService = roomTypeService;
        }

        public async Task<IActionResult> Index()
        {
            // Otelleri ve Oda Tiplerini ana dizindeki gibi çekiyoruz
            var hotels = await _hotelService.GetAllHotelsAsync();
            var roomTypes = await _roomTypeService.GetAllRoomTypesAsync();

            var model = new HomeViewModel
            {
                Hotels = hotels,
                RoomTypes = roomTypes
            };

            return View(model);
        }
    }
}