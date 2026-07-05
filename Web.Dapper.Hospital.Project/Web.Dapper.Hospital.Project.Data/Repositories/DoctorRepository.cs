using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DoctorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Doctor";
            return await connection.QueryAsync<Doctor>(sql);
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Doctor WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<Doctor>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Doctor doctor)
        {
            using var connection = CreateConnection();
            var sql = @"INSERT INTO Doctor (FirstName, LastName, Branch, HospitalName, IsActive) 
                        VALUES (@FirstName, @LastName, @Branch, @HospitalName, @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            return await connection.ExecuteScalarAsync<int>(sql, doctor);
        }

        public async Task<int> UpdateAsync(Doctor doctor)
        {
            using var connection = CreateConnection();
            var sql = @"UPDATE Doctor 
                        SET FirstName = @FirstName, LastName = @LastName, Branch = @Branch, 
                            HospitalName = @HospitalName, IsActive = @IsActive 
                        WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, doctor);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "DELETE FROM Doctor WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
