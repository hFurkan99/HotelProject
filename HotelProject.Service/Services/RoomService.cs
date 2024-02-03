using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.DTOs.DataDTOs;
using HotelProject.Core.Models;
using HotelProject.Core.Repositories;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using HotelProject.Service.Exceptions;
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

            if (rooms.Count <= 0)
            {
                throw new NotFoundException("There are no rooms in the room list!");
            }
            var roomsDto = _mapper.Map<List<RoomDTO>>(rooms);
            return CustomResponseDTO<List<RoomDTO>>.Success(roomsDto, 200);
        }

        public async Task<CustomResponseDTO<RoomDTO>> CreateRoom(RoomDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _roomRepository.AddAsync(room);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<RoomDTO>.Success(roomDto, 200);
        }

        public async Task<CustomResponseDTO<MultipleTypeDto>> GetRoomCount()
        {
            var roomCount = await _roomRepository.RoomCountAsync();

            if (roomCount <= 0)
            {
                return CustomResponseDTO<MultipleTypeDto>.Success(
                    new MultipleTypeDto { IntData = roomCount, StringData = "Boş" },
                    200
                );
            }

            return CustomResponseDTO<MultipleTypeDto>.Success(
                new MultipleTypeDto { IntData = roomCount, StringData = "Mevcut" },
                200
            );
        }
    }
}
