using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.Data.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task<int> InsertAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
        Task<int> DeleteAsync(int id);
    }
}
