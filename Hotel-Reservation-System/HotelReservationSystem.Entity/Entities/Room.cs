using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Entity.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }
        public decimal NightlyPrice { get; set; }
        public string? Photo { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
