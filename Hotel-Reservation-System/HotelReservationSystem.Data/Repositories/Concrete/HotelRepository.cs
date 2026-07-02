using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
