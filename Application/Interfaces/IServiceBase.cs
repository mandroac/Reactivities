using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Interfaces
{
    public interface IServiceBase<TDto, TKey>
    {
        Task<Result<IEnumerable<TDto>>> GetAllAsync();
        Task<Result<TDto>> GetAsync(TKey id);
        Task<Result<TDto>> CreateAsync(TDto newEntityDto);
        Task<Result<TDto>> UpdateAsync(TKey id, TDto updatedEntityDto);
        Task<Result<string>> DeleteAsync(TKey id);
    }
}