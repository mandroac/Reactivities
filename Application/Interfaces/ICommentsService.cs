using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICommentsService : IServiceBase<CommentDto, int>
    {
         Task<Result<CommentDto>> CreateAsync(string body, Guid activityId);
         Task<Result<IEnumerable<CommentDto>>> GetAllCommentsOfActivity(Guid activityId);
    }
}