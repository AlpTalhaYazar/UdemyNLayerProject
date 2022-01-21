using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICategoryService<TDto> : IService<Category, TDto> where TDto : class
    {
        Task<CategoryWithProductsDto> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
