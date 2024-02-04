using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.DTOs;
using HotelProject.Core.DTOs.DataDTOs;
using HotelProject.Core.Repositories;

namespace HotelProject.Core.Services
{
    public interface IService<T>
        where T : class
    {
        Task<CustomResponseDTO<TDto>> GetByIdAsync<TDto>(int id);
        Task<CustomResponseDTO<int>> GetCount();
        Task<CustomResponseDTO<IEnumerable<TDto>>> GetAllAsync<TDto>();
        Task<CustomResponseDTO<TDto>> AddAsync<TDto>(TDto itemDto);
        Task<CustomResponseDTO<TDto>> RemoveAsync<TDto>(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<CustomResponseDTO<int>> AddRangeAsync<TDto>(IEnumerable<TDto> itemsDto);
        Task<CustomResponseDTO<TDto>> UpdateAsync<TDto>(TDto itemDto);

        //Task<CustomResponseDTO<int>> RemoveRangeAsync(IEnumerable<int> ids);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
