using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
