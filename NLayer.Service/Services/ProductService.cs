using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService<TDto> : Service<Product, TDto>, IProductService<TDto> where TDto : class
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IProductRepository productRepository) : base(mapper, unitOfWork, repository)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
        {
            var model = await _productRepository.GetProductsWithCategoryAsync();

            var responseDto = _mapper.Map<List<ProductWithCategoryDto>>(model);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, responseDto);
        }
    }
}
