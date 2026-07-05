using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<int> InsertAsync(Doctor doctor);
        Task<int> UpdateAsync(Doctor doctor);
        Task<int> DeleteAsync(int id);
    }
}
