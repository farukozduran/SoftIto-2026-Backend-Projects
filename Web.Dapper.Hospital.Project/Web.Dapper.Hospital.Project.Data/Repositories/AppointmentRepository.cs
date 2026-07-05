using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AppointmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Appointment>("sp_GetAllAppointments", commandType: CommandType.StoredProcedure);
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await connection.QuerySingleOrDefaultAsync<Appointment>("sp_GetAppointmentById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> InsertAsync(Appointment appointment)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentDate", appointment.AppointmentDate);
            parameters.Add("@DoctorFullName", appointment.DoctorFullName);
            parameters.Add("@PatientFullName", appointment.PatientFullName);
            parameters.Add("@HospitalName", appointment.HospitalName);
            parameters.Add("@Status", appointment.Status);
            
            return await connection.ExecuteScalarAsync<int>("sp_InsertAppointment", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Appointment appointment)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", appointment.Id);
            parameters.Add("@AppointmentDate", appointment.AppointmentDate);
            parameters.Add("@DoctorFullName", appointment.DoctorFullName);
            parameters.Add("@PatientFullName", appointment.PatientFullName);
            parameters.Add("@HospitalName", appointment.HospitalName);
            parameters.Add("@Status", appointment.Status);
            
            return await connection.ExecuteAsync("sp_UpdateAppointment", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await connection.ExecuteAsync("sp_DeleteAppointment", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
