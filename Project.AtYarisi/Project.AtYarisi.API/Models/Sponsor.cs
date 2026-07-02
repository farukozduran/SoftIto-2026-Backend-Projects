using System.ComponentModel.DataAnnotations;

namespace Project.AtYarisi.API.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        public string BrandName { get; set; }
        public string Sector { get; set; }
        public decimal AnnualBudget { get; set; }
        public string Email { get; set; }
    }
}
