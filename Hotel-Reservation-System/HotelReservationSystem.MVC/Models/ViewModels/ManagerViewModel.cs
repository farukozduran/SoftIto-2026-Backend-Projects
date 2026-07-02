using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservationSystem.MVC.Models.ViewModels
{
    public class ManagerViewModel
    {
        public Manager Manager { get; set; }
        public IEnumerable<SelectListItem> HotelList { get; set; }
    }
}