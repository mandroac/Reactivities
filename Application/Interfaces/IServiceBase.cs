using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result<T>> GetAsync(Guid id);
        Task<Result<T>> CreateAsync(T newEntity);
        Task<Result<T>> UpdateAsync(Guid id, T updatedEntity);
        Task<Result<string>> DeleteAsync(Guid id);
    }
}