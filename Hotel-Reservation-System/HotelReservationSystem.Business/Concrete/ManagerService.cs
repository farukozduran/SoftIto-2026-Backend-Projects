using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync()
        {
            return await _unitOfWork.Manager.GetAllAsync(isTracking: false);
        }

        public async Task<Manager?> GetManagerByIdAsync(int id)
        {
            return await _unitOfWork.Manager.GetByIdAsync(id);
        }

        public async Task CreateManagerAsync(Manager manager)
        {
            await _unitOfWork.Manager.AddAsync(manager);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateManagerAsync(Manager manager)
        {
            _unitOfWork.Manager.Update(manager);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteManagerAsync(Manager manager)
        {
            _unitOfWork.Manager.Delete(manager);
            await _unitOfWork.SaveAsync();
        }
    }
}
