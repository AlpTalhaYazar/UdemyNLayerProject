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
            var products = await _productRepository.GetProductsWithCategoryAsync();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }


    }
}
