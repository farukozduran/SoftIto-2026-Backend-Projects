using System.Linq.Expressions;

namespace HotelReservationSystem.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null, bool isTracking = false);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
            string? includeProperties = null, bool isTracking = true);

        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
