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
        Task<CustomResponseDTO<MultipleTypeDto>> GetCount();
        Task<CustomResponseDTO<IEnumerable<TDto>>> GetAllAsync<TDto>();
        Task<CustomResponseDTO<TDto>> AddAsync<TDto>(TDto entityDto);
        Task<CustomResponseDTO<TDto>> RemoveAsync<TDto>(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
