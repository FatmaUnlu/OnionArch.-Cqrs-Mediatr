using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Domain.Common;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T Entity);
    }
}
