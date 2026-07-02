using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
