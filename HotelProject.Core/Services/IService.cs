using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.DTOs;
using HotelProject.Core.Repositories;

namespace HotelProject.Core.Services
{
    public interface IService<T>
        where T : class
    {
        Task<CustomResponseDTO<T>> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
        Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
