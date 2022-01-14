using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await this._productService.GetAllAsync();
            return Ok(this._mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await this._productService.GetByIdAsync(id);
            return Ok(this._mapper.Map<ProductDto>(product));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await this._productService.GetWithCategoryyByIdAsync(id);
            return Ok(this._mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await this._productService.AddAsync(this._mapper.Map<Product>(productDto));
            return Created(string.Empty, this._mapper.Map<ProductDto>(newProduct));
        }

        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var product = this._productService.Update(this._mapper.Map<Product>(updateProductDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = this._productService.GetByIdAsync(id).Result;
            this._productService.Remove(product);
            return NoContent();
        }


         
    }
}
