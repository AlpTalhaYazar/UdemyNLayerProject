using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService<ProductDto> _productService;
        private readonly IProductService<ProductUpdateDto> _productUpdateService;

        public ProductsController(IMapper mapper, IProductService<ProductDto> productService, IProductService<ProductUpdateDto> productUpdateService)
        {
            _mapper = mapper;
            _productService = productService;
            _productUpdateService = productUpdateService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _productService.GetByIdAsync(id));
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategoryAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            return CreateActionResult(await _productService.AddAsync(productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            return CreateActionResult(await _productUpdateService.updateAsync(productUpdateDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return CreateActionResult(await _productService.RemoveAsync(product.Data));
        }

    }
}
