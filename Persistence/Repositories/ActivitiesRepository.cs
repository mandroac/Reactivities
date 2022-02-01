using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ActivitiesRepository : RepositoryBase<Activity, Guid>, IActivitiesRepository
    {
        public ActivitiesRepository(DataContext repositoryContext) : base(repositoryContext)
        {
        }

        public override async Task<IEnumerable<Activity>> GetAllAsync() => 
            await DbSet.AsNoTracking()
                .Include(a => a.Attendees)
                    .ThenInclude(u => u.User.Photos)
                .Include(a => a.Attendees)
                    .ThenInclude(u => u.User.Followings)
                    .ThenInclude(t => t.Target)
                .Include(a => a.Attendees)
                    .ThenInclude(u => u.User.Followers)
                    .ThenInclude(o => o.Observer)
                .ToListAsync();
        
        public override async Task<Activity> GetAsync(Guid id) =>
            await DbSet.Include(a => a.Attendees)
                .ThenInclude(u => u.User)
                .ThenInclude(p => p.Photos)
                .SingleOrDefaultAsync(a => a.Id == id);
    }
}