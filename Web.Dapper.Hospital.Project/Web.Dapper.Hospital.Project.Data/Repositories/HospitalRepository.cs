using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Web.Dapper.Hospital.Project.Entity.Models;
using HospitalEntity = Web.Dapper.Hospital.Project.Entity.Models.Hospital;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HospitalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<HospitalEntity>> GetAllAsync()
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Hospital";
            return await connection.QueryAsync<HospitalEntity>(sql);
        }

        public async Task<HospitalEntity> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Hospital WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<HospitalEntity>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(HospitalEntity hospital)
        {
            using var connection = CreateConnection();
            var sql = @"INSERT INTO Hospital (Name, City, Address, Phone) 
                        VALUES (@Name, @City, @Address, @Phone);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            return await connection.ExecuteScalarAsync<int>(sql, hospital);
        }

        public async Task<int> UpdateAsync(HospitalEntity hospital)
        {
            using var connection = CreateConnection();
            var sql = @"UPDATE Hospital 
                        SET Name = @Name, City = @City, Address = @Address, Phone = @Phone 
                        WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, hospital);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "DELETE FROM Hospital WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
