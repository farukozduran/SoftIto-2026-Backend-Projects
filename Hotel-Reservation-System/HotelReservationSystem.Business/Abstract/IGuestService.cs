using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Abstract
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest?> GetGuestByIdAsync(int id);
        Task CreateGuestAsync(Guest guest);
        Task UpdateGuestAsync(Guest guest);
        Task DeleteGuestAsync(Guest guest);
    }
}
