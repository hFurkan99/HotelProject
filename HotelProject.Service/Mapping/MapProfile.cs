using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.Core.DTOs;
using HotelProject.Core.Models;

namespace HotelProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Amenities, AmentitiesDTO>().ReverseMap();
            CreateMap<Critization, CritizationDTO>().ReverseMap();
            CreateMap<Staff, StaffDTO>().ReverseMap();
            CreateMap<Subscribe, SubscribeDTO>().ReverseMap();
        }
    }
}
