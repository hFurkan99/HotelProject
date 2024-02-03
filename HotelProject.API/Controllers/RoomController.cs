using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;
using HotelProject.Core.Services;
using HotelProject.Core.UnitOfWorks;
using HotelProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace HotelProject.API.Controllers
{
    public class RoomController : CustomBaseController
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IRoomService service, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _service = service;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            return CreateActionResult(await _service.GetRoomList());
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomCount()
        {
            return CreateActionResult(await _service.GetRoomCount());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDTO roomDto)
        {
            return CreateActionResult(await _service.CreateRoom(roomDto));
        }

        [HttpGet]
        [ServiceFilter(typeof(NotFoundFilter<Room>))]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }
    }
}
