﻿using AutoMapper;
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

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            return CreateActionResult(await _service.GetAllAsync<RoomDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomCount()
        {
            return CreateActionResult(await _service.GetCount());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDTO roomDto)
        {
            return CreateActionResult(await _service.AddAsync(roomDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRooms(IEnumerable<RoomDTO> roomDto)
        {
            return CreateActionResult(await _service.AddRangeAsync(roomDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Room>))]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync<RoomDTO>(id));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Room>))]
        public async Task<IActionResult> RemoveRoom(int id)
        {
            return CreateActionResult(await _service.RemoveAsync<RoomDTO>(id));
        }

        //[HttpDelete]
        //[ServiceFilter(typeof(NotFoundFilter<Room>))]
        //public async Task<IActionResult> RemoveRooms(IEnumerable<int> id)
        //{
        //    return CreateActionResult(await _service.RemoveRangeAsync(id));
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(RoomDTO roomDTO)
        {
            return CreateActionResult(await _service.UpdateAsync(roomDTO));
        }
    }
}
