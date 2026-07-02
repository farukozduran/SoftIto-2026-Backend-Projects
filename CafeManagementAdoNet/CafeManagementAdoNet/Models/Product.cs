using System.ComponentModel.DataAnnotations;

namespace CafeManagementAdoNet.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok zorunludur.")]
        public int Stock { get; set; }
    }
}
