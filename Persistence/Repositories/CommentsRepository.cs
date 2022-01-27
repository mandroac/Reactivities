using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CommentsRepository : RepositoryBase<Comment, int>, ICommentsRepository
    {
        public CommentsRepository(DataContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsOfActivityAsync(Guid activityId) =>
            await DbSet.Include(c => c.Activity)
                .Include(c => c.Author).ThenInclude(a => a.Photos)
                .Where(c => c.Activity.Id == activityId).OrderBy(c => c.CreatedAt).ToListAsync();
        
    }
}