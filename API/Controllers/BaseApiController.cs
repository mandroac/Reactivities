using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseApiController<TDto> : ControllerBase where TDto : BaseDto
    {
        protected readonly IServiceBase<TDto> Service;
        protected BaseApiController(IServiceBase<TDto> service)
        {
            Service = service;
        }

        #region CRUD operations

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            return HandleResult(await Service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(Guid id)
        {
            return HandleResult(await Service.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(TDto dto)
        {
            return HandleResult(await Service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(Guid id, TDto updatedDto)
        {
            return HandleResult(await Service.UpdateAsync(id, updatedDto));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
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
        #endregion
    }

}