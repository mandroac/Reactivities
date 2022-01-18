using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IActivityAttendeesRepository
    {
        Task<ActivityAttendee> GetAsync(Guid userId, Guid activityId);
        Task<IEnumerable<ActivityAttendee>> GetAllAsync();
    }
}