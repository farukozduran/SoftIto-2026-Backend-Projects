using HotelReservationSystem.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Data.Contexts;

namespace HotelReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly HotelDbContext _context;

        public DashboardController(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Misafirler, Odalar, Oda Tipleri ve Oteller arasında Join işlemi yapıyoruz
            var reservationsReport = await _context.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room).ThenInclude(rm => rm.Hotel)
                .Include(r => r.Room).ThenInclude(rm => rm.RoomType)
                .Select(r => new ReservationReportDto
                {
                    ReservationId = r.Id,
                    GuestFullName = r.Guest.FirstName + " " + r.Guest.LastName,
                    HotelName = r.Room.Hotel.Name,
                    RoomNumber = r.Room.RoomNumber,
                    RoomTypeName = r.Room.RoomType.TypeName,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    TotalAmount = r.TotalAmount
                }).ToListAsync();

            var model = new DashboardReportViewModel
            {
                ReservationReports = reservationsReport
            };

            return View(model);
        }
    }
}