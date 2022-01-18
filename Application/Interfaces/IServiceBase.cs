using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Interfaces
{
    public interface IServiceBase<TDto>
    {
        Task<Result<IEnumerable<TDto>>> GetAllAsync();
        Task<Result<TDto>> GetAsync(Guid id);
        Task<Result<TDto>> CreateAsync(TDto newEntityDto);
        Task<Result<TDto>> UpdateAsync(Guid id, TDto updatedEntityDto);
        Task<Result<string>> DeleteAsync(Guid id);
    }
}