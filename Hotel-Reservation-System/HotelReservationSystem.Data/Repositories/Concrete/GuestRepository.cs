using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
