using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;

namespace HotelProject.Core.Repositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<int> RoomCountAsync();
    }
}
