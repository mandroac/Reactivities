using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICommentsRepository : IRepositoryBase<Comment, int>
    {
        Task<IEnumerable<Comment>> GetAllCommentsOfActivityAsync(Guid activityId);
    }
}