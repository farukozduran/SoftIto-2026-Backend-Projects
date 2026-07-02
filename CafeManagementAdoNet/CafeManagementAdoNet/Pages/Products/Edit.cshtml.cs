using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly string _connectionString;

        public EditModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [BindProperty]
        public Product Product { get; set; } = new Product();

        public IActionResult OnGet(int id)
        {

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ProductId", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Product = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Category = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    Stock = reader.GetInt32(4)
                };

                return Page();
            }

            return NotFound();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"UPDATE Products
                            SET ProductName = @ProductName,
                                Category = @Category,
                                Price = @Price,
                                Stock = @Stock
                            WHERE ProductId = @ProductId";

            using SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ProductId", Product.ProductId);
            command.Parameters.AddWithValue("@ProductName", Product.ProductName);
            command.Parameters.AddWithValue("@Category", Product.Category);
            command.Parameters.AddWithValue("@Price", Product.Price);
            command.Parameters.AddWithValue("@Stock", Product.Stock);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");

        }
    }
}
