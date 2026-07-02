using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservationSystem.MVC.Models.ViewModels
{
    public class RoomViewModel
    {
        public Room Room { get; set; }

        public IEnumerable<SelectListItem> RoomTypeList { get; set; }
        public IEnumerable<SelectListItem> HotelList { get; set; }
    }
}
