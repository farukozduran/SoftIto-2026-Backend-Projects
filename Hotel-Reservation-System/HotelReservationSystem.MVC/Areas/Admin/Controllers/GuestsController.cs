using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuestsController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GuestsController(IGuestService guestService, IWebHostEnvironment hostEnvironment)
        {
            _guestService = guestService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var guestList = await _guestService.GetAllGuestsAsync(); 
            return View(guestList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            if (id == null || id <= 0) return View(new Guest());

            var guest = await _guestService.GetGuestByIdAsync(id.Value);
            if (guest == null) return View(new Guest());

            return View(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(Guest guest, IFormFile? file)
        {
            if (file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\guests");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot)) Directory.CreateDirectory(uploadRoot);

                if (!string.IsNullOrEmpty(guest.Photo))
                {
                    var oldPicPath = Path.Combine(wwwRootPath, guest.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                guest.Photo = @"\img\guests\" + fileName + extension;
            }

            if (guest.Id <= 0)
                await _guestService.CreateGuestAsync(guest);
            else
                await _guestService.UpdateGuestAsync(guest);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var guest = await _guestService.GetGuestByIdAsync(id.Value);
            if (guest != null)
            {
                if (!string.IsNullOrEmpty(guest.Photo))
                {
                    var oldPicPath = Path.Combine(_hostEnvironment.WebRootPath, guest.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }
                await _guestService.DeleteGuestAsync(guest);
            }
            return RedirectToAction("Index");
        }
    }
}