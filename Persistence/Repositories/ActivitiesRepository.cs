using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ActivitiesRepository : RepositoryBase<Activity>, IActivitiesRepository
    {
        public ActivitiesRepository(DataContext repositoryContext) : base(repositoryContext)
        { 
        }

        public override async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().Include(a => a.Attendees).ThenInclude(u => u.User).ToListAsync();
        }

        public override async Task<Activity> GetAsync(Guid id)
        {
            return await DbSet.Include(a => a.Attendees).ThenInclude(u => u.User).SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}