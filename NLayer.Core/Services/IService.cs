using NLayer.Core.DTOs;
using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    public interface IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<TDto> AddAsync(TDto dto);
        Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> dtos);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task RemoveAsync(TDto dto);
        Task RemoveRangeAsync(IEnumerable<TDto> dtos);
        Task updateAsync(TDto dto);
        IQueryable<TDto> Where(Expression<Func<TEntity, bool>> expression);
    }
}
