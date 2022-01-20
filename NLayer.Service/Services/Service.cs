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

        public async Task<CustomResponseDto<TDto>> AddAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(model);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<TDto>.Success(201, dto);
        }

        public async Task<CustomResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<TEntity>>(dtos);

            await _repository.AddRangeAsync(model);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<IEnumerable<TDto>>.Success(201, dtos);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var objectsFromDb = await _repository.GetAll().ToListAsync();

            var customobjectDto = _mapper.Map<IEnumerable<TDto>>(objectsFromDb);

            return CustomResponseDto<IEnumerable<TDto>>.Success(200, customobjectDto);
        }

        public async Task<CustomResponseDto<TDto>> GetByIdAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);

            if (model == null)
                throw new NotFoundException($"{typeof(TEntity).Name} with {id} id not found.");

            var modelDto = _mapper.Map<TDto>(model);

            return CustomResponseDto<TDto>.Success(200, modelDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            _repository.Remove(model);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<TDto> dtos)
        {
            var model = _mapper.Map<IEnumerable<TEntity>>(dtos);

            _repository.RemoveRange(model);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentDto>> updateAsync(TDto dto)
        {
            var model = _mapper.Map<TEntity>(dto);

            _repository.Update(model);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public IQueryable<TDto> Where(Expression<Func<TEntity, bool>> expression)
        {
            var queryableModel = _repository.Where(expression);

            return _mapper.Map<IQueryable<TDto>>(queryableModel);
        }
    }
}
