using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await _unitOfWork.RoomType.GetAllAsync(isTracking: false);
        }

        public async Task<RoomType?> GetRoomTypeByIdAsync(int id)
        {
            return await _unitOfWork.RoomType.GetByIdAsync(id);
        }

        public async Task CreateRoomTypeAsync(RoomType roomType)
        {
            await _unitOfWork.RoomType.AddAsync(roomType);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateRoomTypeAsync(RoomType roomType)
        {
            _unitOfWork.RoomType.Update(roomType);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRoomTypeAsync(RoomType roomType)
        {
            _unitOfWork.RoomType.Delete(roomType);
            await _unitOfWork.SaveAsync();
        }
    }
}
