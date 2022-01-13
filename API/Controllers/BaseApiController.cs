using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase where T : BaseEntity
    {
        protected readonly IServiceBase<T> Service;
        protected BaseApiController(IServiceBase<T> service)
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
        public virtual async Task<IActionResult> CreateAsync(T entity)
        {
            return HandleResult(await Service.CreateAsync(entity));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(Guid id, T updatedEntity)
        {
            return HandleResult(await Service.UpdateAsync(id, updatedEntity));
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