using System.ComponentModel.DataAnnotations;

namespace Project.AtYarisi.API.Models
{
    public class Horse
    {
        [Key]
        public int HorseId { get; set; }
        public string HorseName { get; set; }
        public int HorseAge { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
    }
}
