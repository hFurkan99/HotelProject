using System.Linq.Expressions;
using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.DTOs.DataDTOs;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using HotelProject.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Service.Services
{
    public class Service<T> : IService<T>
        where T : class
    {
        private readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<TDto>> AddAsync<TDto>(TDto entityDto)
        {
            var item = _mapper.Map<T>(entityDto);
            await _repository.AddAsync(item);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<TDto>.Success(entityDto, 200, "Entity added successfully.");
        }

        public async Task<CustomResponseDTO<int>> GetCount()
        {
            var roomCount = await _repository.CountAsync();
            if (roomCount <= 0)
                return CustomResponseDTO<int>.Success(
                    roomCount,
                    204,
                    $"There is no {typeof(T).Name}"
                );
            return CustomResponseDTO<int>.Success(roomCount, 200, "Entities available.");
        }

        public async Task<CustomResponseDTO<IEnumerable<TDto>>> GetAllAsync<TDto>()
        {
            var items = await _repository.GetAll().ToListAsync();

            if (items.Count <= 0)
            {
                throw new NotFoundException($"There is no {typeof(T).Name}");
            }

            var itemsDto = _mapper.Map<List<TDto>>(items);

            return CustomResponseDTO<IEnumerable<TDto>>.Success(
                itemsDto,
                200,
                "All entites listed."
            );
        }

        public async Task<CustomResponseDTO<TDto>> GetByIdAsync<TDto>(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            var itemDto = _mapper.Map<TDto>(item);
            return CustomResponseDTO<TDto>.Success(itemDto, 200, "Entity fetched successfully.");
        }

        public async Task<CustomResponseDTO<TDto>> RemoveAsync<TDto>(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            _repository.Remove(item);
            await _unitOfWork.CommitAsync();

            var itemDto = _mapper.Map<TDto>(item);
            return CustomResponseDTO<TDto>.Success(itemDto, 200, "Entity deleted successfully.");
        }

        public async Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }
    }
}
