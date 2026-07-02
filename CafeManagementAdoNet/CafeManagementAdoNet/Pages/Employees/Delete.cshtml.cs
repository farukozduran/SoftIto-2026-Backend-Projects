using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly string _connectionString;

        public DeleteModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public IActionResult OnGet(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT EmployeeId, FullName, Position, Salary, StartDate FROM Employees WHERE EmployeeId = @EmployeeId";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Employee = new Employee
                {
                    EmployeeId = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Position = reader.GetString(2),
                    Salary = reader.GetDecimal(3),
                    StartDate = reader.GetDateTime(4)
                };

                return Page();
            }

            return NotFound();
        }

        public IActionResult OnPost()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", Employee.EmployeeId);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");
        }
    }
}
