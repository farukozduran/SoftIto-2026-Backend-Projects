using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HotelsController(IHotelService hotelService, IWebHostEnvironment hostEnvironment)
        {
            _hotelService = hotelService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var hotelList = await _hotelService.GetAllHotelsAsync();
            return View(hotelList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            if (id == null || id <= 0)
                return View(new Hotel());

            var hotel = await _hotelService.GetHotelByIdAsync(id.Value);
            if (hotel == null)
                return View(new Hotel());

            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(Hotel hotel, IFormFile? file)
        {
            if (file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\hotels");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot)) Directory.CreateDirectory(uploadRoot);

                if (!string.IsNullOrEmpty(hotel.Photo))
                {
                    var oldPicPath = Path.Combine(wwwRootPath, hotel.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                hotel.Photo = @"\img\hotels\" + fileName + extension;
            }

            if (hotel.Id <= 0)
                await _hotelService.CreateHotelAsync(hotel);
            else
                await _hotelService.UpdateHotelAsync(hotel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var hotel = await _hotelService.GetHotelByIdAsync(id.Value);
            if (hotel != null)
            {
                if (!string.IsNullOrEmpty(hotel.Photo))
                {
                    var oldPicPath = Path.Combine(_hostEnvironment.WebRootPath, hotel.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }
                await _hotelService.DeleteHotelAsync(hotel);
            }

            return RedirectToAction("Index");
        }
    }
}