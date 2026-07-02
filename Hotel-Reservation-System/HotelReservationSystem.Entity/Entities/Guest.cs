using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Entity.Entities
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string IdentityNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        public string? Photo { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
