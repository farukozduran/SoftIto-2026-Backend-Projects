using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Entity.Entities;
using HotelReservationSystem.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;

        public ReservationsController(IReservationService reservationService, IGuestService guestService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _guestService = guestService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var resList = await _reservationService.GetAllReservationsAsync();
            return View(resList);
        }

        public async Task<IActionResult> Crup(int? id = 0)
        {
            var guests = await _guestService.GetAllGuestsAsync();
            var rooms = await _roomService.GetAllRoomsAsync();

            ReservationViewModel resVM = new ReservationViewModel()
            {
                Reservation = new Reservation(),
                GuestList = guests.Select(x => new SelectListItem
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.Id.ToString()
                }),
                RoomList = rooms.Select(x => new SelectListItem
                {
                    Text = x.RoomNumber,
                    Value = x.Id.ToString()
                })
            };

            if (id == null || id <= 0) return View(resVM);

            resVM.Reservation = await _reservationService.GetReservationByIdAsync(id.Value);
            if (resVM.Reservation == null) return View(resVM);

            return View(resVM);
        }

        [HttpPost]
        public async Task<IActionResult> Crup(ReservationViewModel resVM)
        {
            if (resVM.Reservation.Id <= 0)
            {
                await _reservationService.CreateReservationAsync(resVM.Reservation);
            }
            else
            {
                await _reservationService.UpdateReservationAsync(resVM.Reservation);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var reservation = await _reservationService.GetReservationByIdAsync(id.Value);
            if (reservation != null)
            {
                await _reservationService.DeleteReservationAsync(reservation);
            }

            return RedirectToAction("Index");
        }
    }
}