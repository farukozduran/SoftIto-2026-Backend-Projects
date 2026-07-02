namespace HotelReservationSystem.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHotelRepository Hotel { get; }
        IGuestRepository Guest { get; }
        IRoomRepository Room { get; }
        IReservationRepository Reservation { get; }
        IRoomTypeRepository RoomType { get; }
        IManagerRepository Manager { get; }

        void Save();
        Task SaveAsync();
        void Dispose();
    }
}
