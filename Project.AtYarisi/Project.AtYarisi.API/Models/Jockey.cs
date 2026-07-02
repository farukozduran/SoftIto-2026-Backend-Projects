using System.ComponentModel.DataAnnotations;

namespace Project.AtYarisi.API.Models
{
    public class Jockey
    {
        [Key]
        public int JockeyId { get; set; }
        public string JockeyName { get; set; }
        public decimal Weight { get; set; }
        public int Experience { get; set; }
        public bool IsLicenseActive { get; set; }
    }
}
