using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ActivityAttendeesRepository : IActivityAttendeesRepository
    {
        protected DbSet<ActivityAttendee> DbSet { get; set; }

       public ActivityAttendeesRepository(DataContext context) =>
            DbSet = context.Set<ActivityAttendee>();

        public async Task<IEnumerable<ActivityAttendee>> GetAllAsync() =>
            await DbSet.AsNoTracking().ToListAsync();
            
        public async Task<ActivityAttendee> GetAsync(Guid userId, Guid activityId) =>
            await DbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ActivityId == activityId && x.UserId == userId);
    }
}