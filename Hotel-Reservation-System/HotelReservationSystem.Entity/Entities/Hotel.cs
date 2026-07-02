using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Entity.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public int StarRating { get; set; }
        public string? Photo { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
    }
}
