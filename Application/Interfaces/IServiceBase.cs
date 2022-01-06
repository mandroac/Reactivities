using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task<T> CreateAsync(T newEntity);

        Task<T> UpdateAsync(Guid id, T updatedEntity);

        Task DeleteAsync(Guid id);
    }
}