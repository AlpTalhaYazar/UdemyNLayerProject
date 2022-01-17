using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task updateAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
