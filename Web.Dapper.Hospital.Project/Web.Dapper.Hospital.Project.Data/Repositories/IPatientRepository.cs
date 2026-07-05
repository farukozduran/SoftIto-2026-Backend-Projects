using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<int> InsertAsync(Patient patient);
        Task<int> UpdateAsync(Patient patient);
        Task<int> DeleteAsync(int id);
    }
}
