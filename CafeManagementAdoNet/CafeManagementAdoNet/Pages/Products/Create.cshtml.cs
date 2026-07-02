using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CafeManagementAdoNet.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly string _connectionString;

        public CreateModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        [BindProperty]
        public Product Product { get; set; } = new Product();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO Products 
                            (ProductName, Category, Price, Stock)
                            VALUES
                            (@ProductName, @Category, @Price, @Stock)";

            using SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ProductName", Product.ProductName);
            command.Parameters.AddWithValue("@Category", Product.Category);
            command.Parameters.AddWithValue("@Price", Product.Price);
            command.Parameters.AddWithValue("@Stock", Product.Stock);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");

        }
    }
}
