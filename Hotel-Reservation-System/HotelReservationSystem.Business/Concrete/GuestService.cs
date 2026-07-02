using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _unitOfWork.Guest.GetAllAsync(isTracking: false);
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            return await _unitOfWork.Guest.GetByIdAsync(id);
        }

        public async Task CreateGuestAsync(Guest guest)
        {
            await _unitOfWork.Guest.AddAsync(guest);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateGuestAsync(Guest guest)
        {
            _unitOfWork.Guest.Update(guest);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteGuestAsync(Guest guest)
        {
            _unitOfWork.Guest.Delete(guest);
            await _unitOfWork.SaveAsync();
        }




    }
}
