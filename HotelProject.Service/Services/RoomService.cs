using AutoMapper;
using HotelProject.Core.Models;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;

namespace HotelProject.Service.Services
{
    public class RoomService : Service<Room>, IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(
            IGenericRepository<Room> repository,
            IUnitOfWork unitOfWork,
            IRoomRepository roomRepository,
            IMapper mapper
        )
            : base(repository, unitOfWork, mapper)
        {
            _roomRepository = roomRepository;
        }
    }
}
