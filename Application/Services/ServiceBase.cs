using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepositoryBase<T> Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        public ServiceBase(IRepositoryBase<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Mapper = mapper;
            Repository = repository;
            UnitOfWork = unitOfWork;
        }
        public async Task<T> CreateAsync(T newEntity)
        {
            await Repository.CreateAsync(newEntity);
            await UnitOfWork.SaveAsync();
            return newEntity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            Repository.Delete(entity);
            await UnitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<T> UpdateAsync(Guid id, T updatedEntity)
        {
            var originalEntity = await Repository.GetAsync(id);
            originalEntity =  Mapper.Map(updatedEntity, originalEntity);
            Repository.Update(originalEntity);
            await UnitOfWork.SaveAsync();

            return originalEntity;
        }
    }
}