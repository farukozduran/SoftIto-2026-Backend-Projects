using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly string _connectionString;

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }
        public void OnGet()
        {

            string searchValue = SearchTerm?.Trim() ?? "";
            string searchPattern = "%" + searchValue + "%";

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT ProductId, ProductName, Category, Price, Stock
                FROM Products
                WHERE 
                    @SearchValue = ''
                    OR ProductName LIKE @SearchPattern
                    OR Category LIKE @SearchPattern
                ORDER BY ProductId DESC";

            using SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@SearchValue", searchValue);
            command.Parameters.AddWithValue("@SearchPattern", searchPattern);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Products.Add(new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Category = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    Stock = reader.GetInt32(4)
                });
            }
        }
    }
}
