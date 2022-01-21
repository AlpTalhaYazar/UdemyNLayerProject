using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        protected readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;

        public Service(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(model);

            await _unitOfWork.CommitAsync();

            var responseDto = _mapper.Map<TDto>(model);

            return responseDto;
        }

        public async Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<TEntity>>(dtos);

            await _repository.AddRangeAsync(model);

            await _unitOfWork.CommitAsync();

            return dtos;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var model = await _repository.GetAll().ToListAsync();

            var responseDto = _mapper.Map<IEnumerable<TDto>>(model);

            return responseDto;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);

            if (model == null)
                throw new NotFoundException($"{typeof(TEntity).Name} with {id} id not found.");

            var modelDto = _mapper.Map<TDto>(model);

            return modelDto;
        }

        public async Task<NoContentDto> RemoveAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            _repository.Remove(model);

            await _unitOfWork.CommitAsync();

            return new NoContentDto();
        }

        public async Task<NoContentDto> RemoveRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<TEntity>>(dtos);

            _repository.RemoveRange(model);

            await _unitOfWork.CommitAsync();

            return new NoContentDto();
        }

        public async Task<NoContentDto> updateAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            _repository.Update(model);

            await _unitOfWork.CommitAsync();

            return new NoContentDto();
        }

        public IQueryable<TDto> Where(Expression<Func<TEntity, bool>> expression)
        {
            var queryableModel = _repository.Where(expression);

            return _mapper.Map<IQueryable<TDto>>(queryableModel);
        }
    }
}
