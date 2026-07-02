using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomTypesController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RoomTypesController(IRoomTypeService roomTypeService, IWebHostEnvironment hostEnvironment)
        {
            _roomTypeService = roomTypeService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypeList = await _roomTypeService.GetAllRoomTypesAsync();
            return View(roomTypeList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            if (id == null || id <= 0) return View(new RoomType());

            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(id.Value);
            if (roomType == null) return View(new RoomType());

            return View(roomType);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(RoomType roomType, IFormFile? file)
        {
            if (file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\roomtypes");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot)) Directory.CreateDirectory(uploadRoot);

                if (!string.IsNullOrEmpty(roomType.Photo))
                {
                    var oldPicPath = Path.Combine(wwwRootPath, roomType.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                roomType.Photo = @"\img\roomtypes\" + fileName + extension;
            }

            if (roomType.Id <= 0)
                await _roomTypeService.CreateRoomTypeAsync(roomType);
            else
                await _roomTypeService.UpdateRoomTypeAsync(roomType);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(id.Value);
            if (roomType != null)
            {
                if (!string.IsNullOrEmpty(roomType.Photo))
                {
                    var oldPicPath = Path.Combine(_hostEnvironment.WebRootPath, roomType.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }
                await _roomTypeService.DeleteRoomTypeAsync(roomType);
            }
            return RedirectToAction("Index");
        }
    }
}