using System.ComponentModel.DataAnnotations;

namespace Project.Shop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Tagline { get; set; }
    }
}
