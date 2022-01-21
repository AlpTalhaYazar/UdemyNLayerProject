using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductService<TDto> : IService<Product, TDto> where TDto : class
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
