using System.Linq.Expressions;
using AutoMapper;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HotelProject.Caching
{
    public class RoomServiceWithCaching : IRoomService
    {
        private const string CacheRoomKey = "RoomsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IRoomRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomServiceWithCaching(
            IUnitOfWork unitOfWork,
            IRoomRepository repository,
            IMemoryCache memoryCache,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheRoomKey, out _))
            {
                _memoryCache.Set(CacheRoomKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Room> AddAsync(Room entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllRoomsAsync();
            return entity;
        }

        public async Task<IEnumerable<Room>> AddRangeAsync(IEnumerable<Room> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllRoomsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Room, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            var Rooms = _memoryCache.Get<IEnumerable<Room>>(CacheRoomKey);
            return Task.FromResult(Rooms);
        }

        public Task<Room> GetByIdAsync(int id)
        {
            var Room = _memoryCache.Get<List<Room>>(CacheRoomKey).FirstOrDefault(x => x.Id == id);

            if (Room == null)
            {
                throw new NotFoundExcepiton($"{typeof(Room).Name}({id}) not found");
            }

            return Task.FromResult(Room);
        }

        public Task<CustomResponseDto<List<RoomWithCategoryDto>>> GetRoomsWithCategory()
        {
            var Rooms = _memoryCache.Get<IEnumerable<Room>>(CacheRoomKey);
            var RoomsWithCategoryDto = _mapper.Map<List<RoomWithCategoryDto>>(Rooms);

            return Task.FromResult(
                CustomResponseDto<List<RoomWithCategoryDto>>.Success(200, RoomsWithCategoryDto)
            );
        }

        public async Task RemoveAsync(Room entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllRoomsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Room> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllRoomsAsync();
        }

        public async Task UpdateAsync(Room entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllRoomsAsync();
        }

        public IQueryable<Room> Where(Expression<Func<Room, bool>> expression)
        {
            return _memoryCache
                .Get<List<Room>>(CacheRoomKey)
                .Where(expression.Compile())
                .AsQueryable();
        }

        public async Task CacheAllRoomsAsync()
        {
            _memoryCache.Set(CacheRoomKey, await _repository.GetAll().ToListAsync());
        }
    }
}
