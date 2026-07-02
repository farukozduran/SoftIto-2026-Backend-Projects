using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using HotelReservationSystem.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IHotelService _hotelService;
        private readonly IWebHostEnvironment _hostEnvironment; 

        public RoomsController(IRoomService roomService,
                               IRoomTypeService roomTypeService,
                               IHotelService hotelService,
                               IWebHostEnvironment hostEnvironment)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _hotelService = hotelService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var roomList = await _roomService.GetAllRoomsAsync();
            return View(roomList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypesAsync();
            var hotels = await _hotelService.GetAllHotelsAsync();

            RoomViewModel roomVM = new RoomViewModel()
            {
                Room = new Room(),
                RoomTypeList = roomTypes.Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.Id.ToString()
                }),
                HotelList = hotels.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id == null || id <= 0)
            {
                return View(roomVM);
            }

            roomVM.Room = await _roomService.GetRoomByIdAsync(id.Value);
            if (roomVM.Room == null)
            {
                return View(roomVM);
            }

            return View(roomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(RoomViewModel roomVM, IFormFile? file) 
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString(); 
                var uploadRoot = Path.Combine(wwwRootPath, @"img\rooms");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot))
                {
                    Directory.CreateDirectory(uploadRoot);
                }

                if (!string.IsNullOrEmpty(roomVM.Room.Photo))
                {
                    var oldPicPath = Path.Combine(wwwRootPath, roomVM.Room.Photo.TrimStart('\\', '/'));

                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                roomVM.Room.Photo = @"\img\rooms\" + fileName + extension;
            }

            if (roomVM.Room.Id <= 0)
            {
                await _roomService.CreateRoomAsync(roomVM.Room);
            }
            else
            {
                await _roomService.UpdateRoomAsync(roomVM.Room);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var room = await _roomService.GetRoomByIdAsync(id.Value);
            if (room != null)
            {
                if (!string.IsNullOrEmpty(room.Photo))
                {
                    var oldPicPath = Path.Combine(_hostEnvironment.WebRootPath, room.Photo.TrimStart('\\', '/'));
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }

                await _roomService.DeleteRoomAsync(room);
            }

            return RedirectToAction("Index");
        }
    }
}