using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Abstract
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
        Task<RoomType?> GetRoomTypeByIdAsync(int id);
        Task CreateRoomTypeAsync(RoomType roomType);
        Task UpdateRoomTypeAsync(RoomType roomType);
        Task DeleteRoomTypeAsync(RoomType roomType);
    }
}
