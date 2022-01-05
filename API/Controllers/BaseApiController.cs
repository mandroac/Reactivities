using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase where T: class
    {
        protected readonly IRepositoryBase<T> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseApiController(IRepositoryBase<T> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> GetAsync()
        {
            var entities = await Repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            return Ok(entity);
        } 
    }
}