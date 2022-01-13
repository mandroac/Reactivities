using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Application.Core;

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
        public async Task<Result<T>> CreateAsync(T newEntity)
        {
            await Repository.CreateAsync(newEntity);
            if (await UnitOfWork.SaveAsync() > 0)
            {
                return Result<T>.Success(newEntity);
            }
            else
            {
                return Result<T>.Failure("Failed to create the new entity in a database;");
            }
        }

        public async Task<Result<string>> DeleteAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                Repository.Delete(entity);
                if (await UnitOfWork.SaveAsync() > 0)
                {
                    return Result<string>.Success($"Entity with {id} was removed successfully");
                }
                else
                {
                    return Result<string>.Failure("Failed to remove the entity from a database;");
                }
            }
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            return Result<IEnumerable<T>>.Success(await Repository.GetAllAsync());
        }

        public async Task<Result<T>> GetAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return Result<T>.Success(entity);
            }
        }

        public async Task<Result<T>> UpdateAsync(Guid id, T updatedEntity)
        {
            var originalEntity = await Repository.GetAsync(id);
            if (originalEntity == null)
            {
                return null;
            }
            else
            {
                originalEntity = Mapper.Map(updatedEntity, originalEntity);
                Repository.Update(originalEntity);
                if (await UnitOfWork.SaveAsync() > 0)
                {
                    return Result<T>.Success(originalEntity);
                }
                else
                {
                    return Result<T>.Failure("Failed to update the entity in a database;");
                }
            }
        }
    }
}