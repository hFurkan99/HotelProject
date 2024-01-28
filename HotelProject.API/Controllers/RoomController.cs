using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;
using HotelProject.Core.Services;
using HotelProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public RoomController(IService<Room> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _service.GetAllAsync();
            var roomsDto = _mapper.Map<List<RoomDTO>>(rooms.ToList());
            if (roomsDto.Count > 0)
            {
                return Ok(CustomResponseDTO<List<RoomDTO>>.Success(roomsDto, 201));
            }
            return NotFound(CustomResponseDTO<List<RoomDTO>>.Fail(404, "mesaj"));
        }
    }
}
