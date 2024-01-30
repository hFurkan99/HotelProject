using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.Models;
using HotelProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context)
            : base(context) { }

        public async Task<int> RoomCountAsync()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }
    }
}
