using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        private readonly HotelDbContext _context;

        public ManagerRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
