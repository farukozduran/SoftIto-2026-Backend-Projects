using CafeManagementAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CafeManagementAdoNet.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly string _connectionString;

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> Employees { get; set; } =new List<Employee>();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }
        public void OnGet()
        {
            string searchValue = SearchTerm?.Trim() ?? "";
            string searchPattern = "%" + searchValue + "%";

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT EmployeeId, FullName, Position, Salary, StartDate
                FROM Employees
                WHERE 
                    @SearchValue = ''
                    OR FullName LIKE @SearchPattern
                    OR Position LIKE @SearchPattern
                ORDER BY EmployeeId DESC";

            using SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@SearchValue", searchValue);
            command.Parameters.AddWithValue("@SearchPattern", searchPattern);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employees.Add(new Employee()
                {
                    EmployeeId = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Position = reader.GetString(2),
                    Salary = reader.GetDecimal(3),
                    StartDate = reader.GetDateTime(4)
                });
            }
        }
    }
}
