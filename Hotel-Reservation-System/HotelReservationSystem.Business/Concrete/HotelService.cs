using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _unitOfWork.Hotel.GetAllAsync(isTracking: false);
        }
        public async Task<Hotel?> GetHotelByIdAsync(int id)
        {
            return await _unitOfWork.Hotel.GetByIdAsync(id);
        }

        public async Task CreateHotelAsync(Hotel hotel)
        {
            await _unitOfWork.Hotel.AddAsync(hotel);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateHotelAsync(Hotel hotel)
        {
            _unitOfWork.Hotel.Update(hotel);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteHotelAsync(Hotel hotel)
        {
            _unitOfWork.Hotel.Delete(hotel);
            await _unitOfWork.SaveAsync();
        }
    }
}
