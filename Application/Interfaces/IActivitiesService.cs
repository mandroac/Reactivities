using System;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IActivitiesService : IServiceBase<ActivityDto>
    {
        Task<Result<ActivityDto>> UpdateAttendanceAsync(Guid activityId);
    }
}