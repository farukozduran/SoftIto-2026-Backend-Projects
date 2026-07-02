using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservationSystem.MVC.Models.ViewModels
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public IEnumerable<SelectListItem> GuestList { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }
    }
}