using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using API.Extentions;
using Application.Core;
using Application.Core.Paging;
using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseCrudApiController<TDto, TKey> : ControllerBase where TDto : BaseDto<TKey>
    {
        protected readonly IServiceBase<TDto, TKey> Service;
        protected BaseCrudApiController(IServiceBase<TDto, TKey> service)
        {
            Service = service;
        }

        #region CRUD operations

        [HttpGet("all")]
        public virtual async Task<IActionResult> GetAsync()
        {
            return HandleResult(await Service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(TKey id)
        {
            return HandleResult(await Service.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(TDto dto)
        {
            return HandleResult(await Service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(TKey id, TDto updatedDto)
        {
            return HandleResult(await Service.UpdateAsync(id, updatedDto));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            return HandleResult(await Service.DeleteAsync(id));
        }
        #endregion

        #region Help Methods
        protected virtual IActionResult HandleResult<TResult>([AllowNull]Result<TResult> result)
        {
            if(result == null) return NotFound();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        protected virtual IActionResult HandlePagedResult<TResult>([AllowNull]Result<PagedList<TResult>> result)
        {
            if(result == null) return NotFound();
            if (result.IsSuccess)
            {
                Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize, 
                    result.Value.TotalCount, result.Value.TotalPages);
                    
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
        #endregion
    }

}