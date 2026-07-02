using HotelReservationSystem.Data.Contexts;
using HotelReservationSystem.Data.Repositories.Interfaces;

namespace HotelReservationSystem.Data.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext _context;
        private IHotelRepository _hotelRepository;
        private IGuestRepository _guestRepository;
        private IRoomRepository _roomRepository;
        private IReservationRepository _reservationRepository;
        private IRoomTypeRepository _roomTypeRepository;
        private IManagerRepository _managerRepository;

        public UnitOfWork(HotelDbContext context)
        {
            _context = context;
        }

        public IHotelRepository Hotel => _hotelRepository ?? new HotelRepository(_context);
        public IGuestRepository Guest => _guestRepository ?? new GuestRepository(_context);
        public IRoomRepository Room => _roomRepository ?? new RoomRepository(_context);
        public IReservationRepository Reservation => _reservationRepository ?? new ReservationRepository(_context);
        public IRoomTypeRepository RoomType => _roomTypeRepository ?? new RoomTypeRepository(_context);
        public IManagerRepository Manager => _managerRepository ?? new ManagerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
