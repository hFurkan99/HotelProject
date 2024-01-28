using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Core.DTOs
{
    public abstract class BaseWithoutUpdateDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
