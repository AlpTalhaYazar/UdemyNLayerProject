using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Caching
{
    public class ProductServiceWithCaching<TDto> : IProductService<TDto> where TDto : class
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetAll().ToList());
            }
        }

        public async Task CacheAllProductsAsync() =>
            _memoryCache.Set(CacheProductKey, await _productRepository.GetAll().ToListAsync());

        public async Task<TDto> AddAsync(TDto dto)
        {
            var model = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(model);

            await _unitOfWork.CommitAsync();

            await CacheAllProductsAsync();

            var responseDto = _mapper.Map<TDto>(model);

            return dto;
        }

        public async Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<Product>>(dtos);

            await _productRepository.AddRangeAsync(model);

            await _unitOfWork.CommitAsync();

            await CacheAllProductsAsync();

            var responseDto = _mapper.Map<IEnumerable<TDto>>(model);

            return responseDto;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDto>> GetAllAsync()
        {
            var model = _memoryCache.Get<List<Product>>(CacheProductKey);

            var responseDto = _mapper.Map<IEnumerable<TDto>>(model);

            return Task.FromResult(responseDto);
        }

        public Task<TDto> GetByIdAsync(int id)
        {
            var model = Task.FromResult(
                _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id));

            if (model == null)
                throw new NotFoundException($"Product with {id} id not found.");

            var modelDto = _mapper.Map<TDto>(model);

            return Task.FromResult(modelDto);
        }

        public async Task<NoContentDto> RemoveAsync(TDto dto)
        {
            var model = _mapper.Map<Product>(dto);

            _productRepository.Remove(model);

            await _unitOfWork.CommitAsync();

            await CacheAllProductsAsync();

            return new NoContentDto();
        }

        public async Task<NoContentDto> RemoveRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<Product>>(dtos);

            _productRepository.RemoveRange(model);

            await _unitOfWork.CommitAsync();

            await CacheAllProductsAsync();

            return new NoContentDto();
        }

        public async Task<NoContentDto> updateAsync(TDto dto)
        {
            var model = _mapper.Map<Product>(dto);

            _productRepository.Update(model);

            await _unitOfWork.CommitAsync();

            await CacheAllProductsAsync();

            return new NoContentDto();
        }

        public IQueryable<TDto> Where(Expression<Func<Product, bool>> expression)
        {
            var queryableModel = _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();

            return _mapper.Map<IQueryable<TDto>>(queryableModel);
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var model = await _productRepository.GetProductsWithCategoryAsync();

            var responseDto = _mapper.Map<List<ProductWithCategoryDto>>(model);

            return responseDto;
        }
    }
}
