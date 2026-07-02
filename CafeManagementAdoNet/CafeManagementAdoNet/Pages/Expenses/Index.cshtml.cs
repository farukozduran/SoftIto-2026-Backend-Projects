using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly string _connectionString;

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Expense> Expenses { get; set; } = new List<Expense>();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            string searchValue = SearchTerm?.Trim() ?? "";
            string searchPattern = "%" + searchValue + "%";

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
                SELECT ExpenseId, ExpenseTitle, Amount, ExpenseDate, Description
                FROM Expenses
                WHERE 
                    @SearchValue = ''
                    OR ExpenseTitle LIKE @SearchPattern
                    OR Description LIKE @SearchPattern
                ORDER BY ExpenseId DESC";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SearchValue", searchValue);
            command.Parameters.AddWithValue("@SearchPattern", searchPattern);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Expenses.Add(new Expense
                {
                    ExpenseId = reader.GetInt32(0),
                    ExpenseTitle = reader.GetString(1),
                    Amount = reader.GetDecimal(2),
                    ExpenseDate = reader.GetDateTime(3),
                    Description = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }
        }
    }
}
