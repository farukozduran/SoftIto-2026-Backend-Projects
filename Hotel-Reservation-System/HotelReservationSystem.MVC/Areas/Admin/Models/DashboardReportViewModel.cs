namespace HotelReservationSystem.MVC.Areas.Admin.Models
{
    public class DashboardReportViewModel
    {
        // Dashboard'da listelenecek rapor veri kümesi
        public IEnumerable<ReservationReportDto> ReservationReports { get; set; }
    }

    // Join işleminden elde edeceğimiz verileri tutacak sınıf
    public class ReservationReportDto
    {
        public int ReservationId { get; set; }
        public string GuestFullName { get; set; }
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}