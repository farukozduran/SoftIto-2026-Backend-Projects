using System.ComponentModel.DataAnnotations;

namespace CafeManagementAdoNet.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [Required(ErrorMessage = "Gider başlığı zorunludur.")]
        public string ExpenseTitle { get; set; }

        [Required(ErrorMessage = "Tutar zorunludur.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Gider tarihi zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        public string? Description { get; set; }
    }
}
