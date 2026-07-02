using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly HotelDbContext _context;
        public ReservationRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
