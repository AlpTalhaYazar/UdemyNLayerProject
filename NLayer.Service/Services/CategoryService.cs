using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CategoryService<TDto> : Service<Category, TDto>, ICategoryService<TDto> where TDto : class
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository categoryRepository) : base(mapper, unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);

            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
