using System.ComponentModel.DataAnnotations;

namespace Project.Shop.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
