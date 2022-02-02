using System;
using System.Threading.Tasks;
using Application.Core;
using Application.Core.Filtering;
using Application.Core.Paging;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IActivitiesService : IServiceBase<ActivityDto, Guid>
    {
        Task<Result<ActivityDto>> UpdateAttendanceAsync(Guid activityId);
        Task<Result<PagedList<ActivityDto>>> GetPagedListAsync(ActivityParams parameters);
    }
}