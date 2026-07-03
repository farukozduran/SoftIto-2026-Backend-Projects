using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.AtYarisi.API.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        public string BrandName { get; set; }
        public string Sector { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AnnualBudget { get; set; }
        public string Email { get; set; }
    }
}
