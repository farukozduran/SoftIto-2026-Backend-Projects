using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Expenses
{
    public class EditModel : PageModel
    {
        private readonly string _connectionString;

        public EditModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [BindProperty]
        public Expense Expense { get; set; } = new Expense();

        public IActionResult OnGet(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT ExpenseId, ExpenseTitle, Amount, ExpenseDate, Description FROM Expenses WHERE ExpenseId = @ExpenseId";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ExpenseId", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Expense = new Expense
                {
                    ExpenseId = reader.GetInt32(0),
                    ExpenseTitle = reader.GetString(1),
                    Amount = reader.GetDecimal(2),
                    ExpenseDate = reader.GetDateTime(3),
                    Description = reader.IsDBNull(4) ? null : reader.GetString(4)
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

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE Expenses 
                             SET ExpenseTitle = @ExpenseTitle,
                                 Amount = @Amount,
                                 ExpenseDate = @ExpenseDate,
                                 Description = @Description
                             WHERE ExpenseId = @ExpenseId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExpenseId", Expense.ExpenseId);
            command.Parameters.AddWithValue("@ExpenseTitle", Expense.ExpenseTitle);
            command.Parameters.AddWithValue("@Amount", Expense.Amount);
            command.Parameters.AddWithValue("@ExpenseDate", Expense.ExpenseDate);
            command.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(Expense.Description) ? DBNull.Value : Expense.Description);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");
        }
    }
}