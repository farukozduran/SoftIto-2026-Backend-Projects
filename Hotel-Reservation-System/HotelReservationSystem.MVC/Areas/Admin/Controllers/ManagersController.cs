using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using HotelReservationSystem.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagersController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IHotelService _hotelService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ManagersController(IManagerService managerService, IHotelService hotelService, IWebHostEnvironment hostEnvironment)
        {
            _managerService = managerService;
            _hotelService = hotelService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var managerList = await _managerService.GetAllManagersAsync();
            return View(managerList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            var hotels = await _hotelService.GetAllHotelsAsync();

            ManagerViewModel managerVM = new ManagerViewModel()
            {
                Manager = new Manager(),
                HotelList = hotels.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id == null || id <= 0) return View(managerVM);

            managerVM.Manager = await _managerService.GetManagerByIdAsync(id.Value);
            if (managerVM.Manager == null) return View(managerVM);

            return View(managerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(ManagerViewModel managerVM, IFormFile? file)
        {
            if (file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\managers");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot)) Directory.CreateDirectory(uploadRoot);

                if (!string.IsNullOrEmpty(managerVM.Manager.Photo))
                {
                    var oldPicPath = Path.Combine(wwwRootPath, managerVM.Manager.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                managerVM.Manager.Photo = @"\img\managers\" + fileName + extension;
            }

            if (managerVM.Manager.Id <= 0)
                await _managerService.CreateManagerAsync(managerVM.Manager);
            else
                await _managerService.UpdateManagerAsync(managerVM.Manager);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var manager = await _managerService.GetManagerByIdAsync(id.Value);
            if (manager != null)
            {
                if (!string.IsNullOrEmpty(manager.Photo))
                {
                    var oldPicPath = Path.Combine(_hostEnvironment.WebRootPath, manager.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath)) System.IO.File.Delete(oldPicPath);
                }
                await _managerService.DeleteManagerAsync(manager);
            }
            return RedirectToAction("Index");
        }
    }
}