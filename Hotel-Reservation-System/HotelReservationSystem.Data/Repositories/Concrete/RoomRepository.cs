using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
