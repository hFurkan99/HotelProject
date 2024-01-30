using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;

namespace HotelProject.Core.Services
{
    public interface IRoomService : IService<Room>
    {
        Task<CustomResponseDTO<int>> GetRoomCount();
        Task<CustomResponseDTO<List<RoomDTO>>> GetRoomList();
    }
}
