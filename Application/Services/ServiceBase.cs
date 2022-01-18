using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Application.Core;
using Application.DTOs;

namespace Application.Services
{
    public class ServiceBase<TDto, TEntity> : IServiceBase<TDto> where TDto : BaseDto where TEntity : BaseEntity
    {
        protected readonly IRepositoryBase<TEntity> Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public ServiceBase(IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Mapper = mapper;
            Repository = repository;
            UnitOfWork = unitOfWork;
        }
        public virtual async Task<Result<TDto>> CreateAsync(TDto newEntityDto)
        {
            var entity = Mapper.Map<TEntity>(newEntityDto);
            await Repository.CreateAsync(entity);
            if (await UnitOfWork.SaveAsync() > 0)
            {
                var returnDto = Mapper.Map<TDto>(entity);
                return Result<TDto>.Success(returnDto);
            }
            else
            {
                return Result<TDto>.Failure("Failed to create the new entity in a database;");
            }
        }

        public virtual async Task<Result<string>> DeleteAsync(Guid id)
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
                    return Result<string>.Success($"Entity with {id} id was removed successfully");
                }
                else
                {
                    return Result<string>.Failure("Failed to remove the entity from a database;");
                }
            }
        }

        public virtual async Task<Result<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await Repository.GetAllAsync();
            var dtos = Mapper.Map<IEnumerable<TDto>>(entities);
            return Result<IEnumerable<TDto>>.Success(dtos);
        }

        public async Task<Result<TDto>> GetAsync(Guid id)
        {
            var entity = await Repository.GetAsync(id);
            var dto = Mapper.Map<TDto>(entity);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return Result<TDto>.Success(dto);
            }
        }

        public virtual async Task<Result<TDto>> UpdateAsync(Guid id, TDto updatedEntityDto)
        {
            var entity = await Repository.GetAsync(id);
            if (entity == null)
            {
                return null;
            }
            else
            {
                Mapper.Map(updatedEntityDto, entity);
                Repository.Update(entity);
                if (await UnitOfWork.SaveAsync() > 0)
                {
                    var resultDto = Mapper.Map<TDto>(entity);
                    return Result<TDto>.Success(resultDto);
                }
                else
                {
                    return Result<TDto>.Failure("Failed to update the entity in a database;");
                }
            }
        }
    }
}