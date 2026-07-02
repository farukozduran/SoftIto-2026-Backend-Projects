using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Entity.Entities
{
    public class RoomType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }

        public int MaxCapacity { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public string? Photo { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
