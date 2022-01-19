using System.Linq.Expressions;
using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponseDto<TDto>> AddAsync(TDto dto);
        Task<CustomResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<CustomResponseDto<TDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(TDto dto);
        Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<TDto> dtos);
        Task<CustomResponseDto<NoContentDto>> updateAsync(TDto dto);
        IQueryable<TDto> Where(Expression<Func<TEntity, bool>> expression);
    }
}
