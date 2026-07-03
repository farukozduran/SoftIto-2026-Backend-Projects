namespace Project.Shop.Models
{
    public class DashboardSummaryReport
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }
    }

    public class TopSellingProductReport
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int SalesCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class TopCustomerReport
    {
        public string CustomerName { get; set; }
        public string? ImageUrl { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class CategorySalesReport
    {
        public string CategoryName { get; set; }
        public int SalesCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
