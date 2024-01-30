using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

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
            : base(repository, unitOfWork)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<RoomDTO>>> GetRoomList()
        {
            var rooms = await _roomRepository.GetAll().ToListAsync();
            var roomsDto = _mapper.Map<List<RoomDTO>>(rooms);
            return CustomResponseDTO<List<RoomDTO>>.Success(roomsDto, 200);
        }

        public async Task<CustomResponseDTO<int>> GetRoomCount()
        {
            var roomCount = await _roomRepository.RoomCountAsync();
            return CustomResponseDTO<int>.Success(roomCount, 200);
        }
    }
}
