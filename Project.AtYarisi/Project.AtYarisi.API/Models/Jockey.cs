using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.AtYarisi.API.Models
{
    public class Jockey
    {
        [Key]
        public int JockeyId { get; set; }
        public string JockeyName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public int Experience { get; set; }
        public bool IsLicenseActive { get; set; }
    }
}
