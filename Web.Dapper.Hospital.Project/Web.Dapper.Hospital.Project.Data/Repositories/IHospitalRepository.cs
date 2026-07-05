using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Dapper.Hospital.Project.Entity.Models;
using HospitalEntity = Web.Dapper.Hospital.Project.Entity.Models.Hospital;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<HospitalEntity>> GetAllAsync();
        Task<HospitalEntity> GetByIdAsync(int id);
        Task<int> InsertAsync(HospitalEntity hospital);
        Task<int> UpdateAsync(HospitalEntity hospital);
        Task<int> DeleteAsync(int id);
    }
}
