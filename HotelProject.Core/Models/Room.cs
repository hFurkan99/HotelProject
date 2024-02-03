using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.DTOs;

namespace HotelProject.Core.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public bool Wifi { get; set; }
        public string Description { get; set; }
    }
}
