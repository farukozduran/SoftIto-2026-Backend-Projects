using System;

namespace Rent.App.Models
{
    public class RentalDetailReport
    {
        public string CustomerName { get; set; } = null!;
        public string CustomerSurname { get; set; } = null!;
        public string CarBrand { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public DateOnly RentDate { get; set; }
        public decimal? TotalPrice { get; set; }
    }

    public class CustomerSpendingReport
    {
        public string CustomerName { get; set; } = null!;
        public string CustomerSurname { get; set; } = null!;
        public int RentalCount { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class CarRentalCountReport
    {
        public string CarBrand { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public string Plate { get; set; } = null!;
        public int RentalCount { get; set; }
    }
}
