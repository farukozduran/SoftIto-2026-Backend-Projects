using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly string _connectionString;

        public CreateModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        [BindProperty]
        public Employee Employee { get; set; } = new Employee();
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

            string query = @"INSERT INTO Employees
                            (FullName, Position, Salary, StartDate)
                            VALUES
                            (@FullName, @Position, @Salary, @StartDate)";

            using SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@FullName", Employee.FullName);
            command.Parameters.AddWithValue("@Position", Employee.Position);
            command.Parameters.AddWithValue("@Salary", Employee.Salary);
            command.Parameters.AddWithValue("@StartDate", Employee.StartDate);

            command.ExecuteNonQuery();

            return RedirectToPage("Index");
        }
    }
}
