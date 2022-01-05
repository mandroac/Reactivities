using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbSet<T> DbSet { get; set; }

        public RepositoryBase(DataContext repositoryContext) => 
            DbSet = repositoryContext.Set<T>();

        public virtual async Task<T> GetAsync(Guid id) => 
            await DbSet.FindAsync(id);
        
        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await DbSet.AsNoTracking().ToListAsync();
        
        public virtual async Task CreateAsync(T entity) =>
            await DbSet.AddAsync(entity);

        public virtual async Task CreateRangeAsync(IEnumerable<T> entities) =>
            await DbSet.AddRangeAsync(entities);
        
        public virtual void Delete(T entity) =>
            DbSet.Remove(entity);
        
        public virtual void Update(T entity) =>
            DbSet.Update(entity);
    }
}