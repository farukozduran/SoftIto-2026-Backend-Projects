using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _connectionString;

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ProductPriceReport> TopPriceProducts { get; set; } = new();
        public List<ProductStockReport> LowStockProducts { get; set; } = new();

        public List<EmployeePositionReport> EmployeePositionReports { get; set; } = new();
        public List<EmployeeSalaryReport> TopSalaryEmployees { get; set; } = new();

        public List<MonthlyExpenseReport> MonthlyExpenseReports { get; set; } = new();
        public List<TopExpenseReport> TopExpenseReports { get; set; } = new();

        public void OnGet()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            GetTopPriceProducts(connection);
            GetLowStockProducts(connection);

            GetEmployeePositionReports(connection);
            GetTopSalaryEmployees(connection);

            GetMonthlyExpenseReports(connection);
            GetTopExpenseReports(connection);
        }

        private void GetTopPriceProducts(SqlConnection connection)
        {
            string query = @"
                SELECT TOP 5 ProductName, Category, Price
                FROM Products
                ORDER BY Price DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TopPriceProducts.Add(new ProductPriceReport
                {
                    ProductName = reader.GetString(0),
                    Category = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                });
            }
        }

        private void GetLowStockProducts(SqlConnection connection)
        {
            string query = @"
                SELECT TOP 5 ProductName, Category, Stock
                FROM Products
                ORDER BY Stock ASC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                LowStockProducts.Add(new ProductStockReport
                {
                    ProductName = reader.GetString(0),
                    Category = reader.GetString(1),
                    Stock = reader.GetInt32(2)
                });
            }
        }

        private void GetEmployeePositionReports(SqlConnection connection)
        {
            string query = @"
                SELECT Position, COUNT(*) AS EmployeeCount
                FROM Employees
                GROUP BY Position
                ORDER BY EmployeeCount DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EmployeePositionReports.Add(new EmployeePositionReport
                {
                    Position = reader.GetString(0),
                    EmployeeCount = reader.GetInt32(1)
                });
            }
        }

        private void GetTopSalaryEmployees(SqlConnection connection)
        {
            string query = @"
                SELECT TOP 5 FullName, Position, Salary
                FROM Employees
                ORDER BY Salary DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TopSalaryEmployees.Add(new EmployeeSalaryReport
                {
                    FullName = reader.GetString(0),
                    Position = reader.GetString(1),
                    Salary = reader.GetDecimal(2)
                });
            }
        }

        private void GetMonthlyExpenseReports(SqlConnection connection)
        {
            string query = @"
                SELECT TOP 6
                    YEAR(ExpenseDate) AS ExpenseYear,
                    MONTH(ExpenseDate) AS ExpenseMonth,
                    SUM(Amount) AS TotalAmount
                FROM Expenses
                GROUP BY YEAR(ExpenseDate), MONTH(ExpenseDate)
                ORDER BY ExpenseYear DESC, ExpenseMonth DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MonthlyExpenseReports.Add(new MonthlyExpenseReport
                {
                    Year = reader.GetInt32(0),
                    Month = reader.GetInt32(1),
                    TotalAmount = reader.GetDecimal(2)
                });
            }
        }

        private void GetTopExpenseReports(SqlConnection connection)
        {
            string query = @"
                SELECT TOP 5 ExpenseTitle, Amount, ExpenseDate
                FROM Expenses
                ORDER BY Amount DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TopExpenseReports.Add(new TopExpenseReport
                {
                    ExpenseTitle = reader.GetString(0),
                    Amount = reader.GetDecimal(1),
                    ExpenseDate = reader.GetDateTime(2)
                });
            }
        }
    }

    public class ProductPriceReport
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductStockReport
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }

    public class EmployeePositionReport
    {
        public string Position { get; set; }
        public int EmployeeCount { get; set; }
    }

    public class EmployeeSalaryReport
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class MonthlyExpenseReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class TopExpenseReport
    {
        public string ExpenseTitle { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}