using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly string _connectionString;

        public CreateModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [BindProperty]
        public Expense Expense { get; set; } = new Expense();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"INSERT INTO Expenses 
                             (ExpenseTitle, Amount, ExpenseDate, Description)
                             VALUES 
                             (@ExpenseTitle, @Amount, @ExpenseDate, @Description)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExpenseTitle", Expense.ExpenseTitle);
            command.Parameters.AddWithValue("@Amount", Expense.Amount);
            command.Parameters.AddWithValue("@ExpenseDate", Expense.ExpenseDate);
            command.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(Expense.Description) ? DBNull.Value : Expense.Description);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");
        }
    }
}
