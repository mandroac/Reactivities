using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase where T : BaseEntity
    {
        protected readonly IServiceBase<T> Service;
        public BaseApiController(IServiceBase<T> service)
        {
            Service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAsync()
        {
            return Ok(await Service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetAsync(Guid id)
        {
            return Ok(await Service.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<ActionResult> CreateAsync(T entity)
        {
            return Ok(await Service.CreateAsync(entity));
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> UpdateAsync(Guid id, T updatedEntity)
        {
            return Ok(await Service.UpdateAsync(id, updatedEntity));
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> DeleteAsync(Guid id)
        {
            await Service.DeleteAsync(id);
            return NoContent();
        }
    }
}