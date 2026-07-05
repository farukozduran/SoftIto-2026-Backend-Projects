using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            using var connection = CreateConnection();
            // Stored Procedure kullanımı örneği
            return await connection.QueryAsync<Patient>("sp_GetAllPatients", commandType: CommandType.StoredProcedure);
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await connection.QuerySingleOrDefaultAsync<Patient>("sp_GetPatientById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> InsertAsync(Patient patient)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdentityNumber", patient.IdentityNumber);
            parameters.Add("@FirstName", patient.FirstName);
            parameters.Add("@LastName", patient.LastName);
            parameters.Add("@Phone", patient.Phone);
            parameters.Add("@BirthDate", patient.BirthDate);
            
            return await connection.ExecuteScalarAsync<int>("sp_InsertPatient", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Patient patient)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", patient.Id);
            parameters.Add("@IdentityNumber", patient.IdentityNumber);
            parameters.Add("@FirstName", patient.FirstName);
            parameters.Add("@LastName", patient.LastName);
            parameters.Add("@Phone", patient.Phone);
            parameters.Add("@BirthDate", patient.BirthDate);
            
            return await connection.ExecuteAsync("sp_UpdatePatient", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await connection.ExecuteAsync("sp_DeletePatient", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
