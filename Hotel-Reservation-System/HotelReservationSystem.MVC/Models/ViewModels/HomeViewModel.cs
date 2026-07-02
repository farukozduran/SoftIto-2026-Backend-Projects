using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.MVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<RoomType> RoomTypes { get; set; }
    }
}