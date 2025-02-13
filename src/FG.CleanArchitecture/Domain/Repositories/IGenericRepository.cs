using Domain.Common;

namespace Domain.Repositories;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> ListAllAsync();
    Task<List<T>> ListAllAsyncNoTracking();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
