using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        protected DbSet<TEntity> DbSet { get; set; }

        public RepositoryBase(DataContext repositoryContext) =>
            DbSet = repositoryContext.Set<TEntity>();

        public virtual async Task<TEntity> GetAsync(TKey id) =>
            await DbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await DbSet.AsNoTracking().ToListAsync();

        public virtual IQueryable<TEntity> GetAllAsQueryable() =>
            DbSet;

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression) => 
            await DbSet.Where(expression).ToListAsync();

        public virtual async Task CreateAsync(TEntity entity) =>
            await DbSet.AddAsync(entity);

        public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities) =>
            await DbSet.AddRangeAsync(entities);

        public virtual void Delete(TEntity entity) =>
            DbSet.Remove(entity);

        public virtual void Update(TEntity entity) =>
            DbSet.Update(entity);
    }
}