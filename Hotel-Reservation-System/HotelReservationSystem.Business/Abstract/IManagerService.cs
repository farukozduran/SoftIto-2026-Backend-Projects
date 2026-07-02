using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Abstract
{
    public interface IManagerService
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task<Manager?> GetManagerByIdAsync(int id);
        Task CreateManagerAsync(Manager manager);
        Task UpdateManagerAsync(Manager manager);
        Task DeleteManagerAsync(Manager manager);
    }
}
