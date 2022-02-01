using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ActivitiesService : ServiceBase<ActivityDto, Activity, Guid>, IActivitiesService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<User> _userManager;

        public ActivitiesService(IActivitiesRepository repository, IUnitOfWork unitOfWork,
        IMapper mapper, IUserAccessor userAccessor, UserManager<User> userManager)
        : base(repository, unitOfWork, mapper)
        {
            _userAccessor = userAccessor;
            _userManager = userManager;
        }

        public async override Task<Result<ActivityDto>> CreateAsync(ActivityDto newEntityDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x =>
                x.UserName == _userAccessor.GetUsername());

            var activity = Mapper.Map<Activity>(newEntityDto);

            var attendee = new ActivityAttendee
            {
                User = user,
                Activity = activity,
                IsHost = true
            };
            activity.Attendees.Add(attendee);

            await Repository.CreateAsync(activity);
            var result = await UnitOfWork.SaveAsync() > 0;

            return result ?
                Result<ActivityDto>.Success(Mapper.Map<ActivityDto>(activity)) :
                Result<ActivityDto>.Failure("Failed to create the new entity in a database");
        }

        public async Task<Result<ActivityDto>> UpdateAttendanceAsync(Guid activityId)
        {
            var activity = await Repository.GetAsync(activityId);

            if (activity == null) return null;

            var user = _userManager.Users.FirstOrDefault(u => u.UserName == _userAccessor.GetUsername());
            if (user == null) return null;

            var hostUsername = activity.Attendees.FirstOrDefault(x => x.IsHost)?.User?.UserName;
            var attendance = activity.Attendees.FirstOrDefault(x => x.User.UserName == user.UserName);

            if (attendance != null && hostUsername == user.UserName) activity.IsCancelled = !activity.IsCancelled;
            if (attendance != null && hostUsername != user.UserName) activity.Attendees.Remove(attendance);
            if (attendance == null)
            {
                attendance = new ActivityAttendee
                {
                    User = user,
                    Activity = activity,
                    IsHost = false
                };
                activity.Attendees.Add(attendance);
            }
            var result = await UnitOfWork.SaveAsync() > 0;

            return result ?
                Result<ActivityDto>.Success(Mapper.Map<ActivityDto>(activity)) :
                Result<ActivityDto>.Failure("An issue occured when updating the attendance");
        }

        public override async Task<Result<IEnumerable<ActivityDto>>> GetAllAsync()
        {
            var dtos = Repository.GetAllAsQueryable().ProjectTo<ActivityDto>(Mapper.ConfigurationProvider, 
                new{currentUsername = _userAccessor.GetUsername()});

            return await Task.FromResult(Result<IEnumerable<ActivityDto>>.Success(dtos));
        }

        public override async Task<Result<ActivityDto>> GetAsync(Guid id)
        {
            var dto = await Repository.GetAllAsQueryable().ProjectTo<ActivityDto>(Mapper.ConfigurationProvider, 
                new{currentUsername = _userAccessor.GetUsername()})
                .SingleOrDefaultAsync(a => a.Id == id);
                
            return await Task.FromResult(Result<ActivityDto>.Success(dto));
        }
    }
}