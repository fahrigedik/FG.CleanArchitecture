using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Repositories;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAllAsync();
    Task<List<T>> ListAllAsyncNoTracking();
    Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
