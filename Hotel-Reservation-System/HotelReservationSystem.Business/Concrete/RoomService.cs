using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _unitOfWork.Room.GetAllAsync(isTracking: false);
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _unitOfWork.Room.GetByIdAsync(id);
        }

        public async Task CreateRoomAsync(Room room)
        {
            await _unitOfWork.Room.AddAsync(room);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateRoomAsync(Room room)
        {
            _unitOfWork.Room.Update(room);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRoomAsync(Room room)
        {
            _unitOfWork.Room.Delete(room);
            await _unitOfWork.SaveAsync();
        }
    }
}
