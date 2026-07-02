using HotelReservationSystem.Business.Abstract;
using HotelReservationSystem.Data.Repositories.Interfaces;
using HotelReservationSystem.Entity.Entities;

namespace HotelReservationSystem.Business.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _unitOfWork.Reservation.GetAllAsync(isTracking: false);
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            return await _unitOfWork.Reservation.GetByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _unitOfWork.Reservation.AddAsync(reservation);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _unitOfWork.Reservation.Update(reservation);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _unitOfWork.Reservation.Delete(reservation);
            await _unitOfWork.SaveAsync();
        }
    }
}
