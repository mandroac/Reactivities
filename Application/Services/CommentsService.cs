using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CommentsService : ServiceBase<CommentDto, Comment, int>, ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IUserAccessor _userAccessor;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly UserManager<User> _userManager;

        public CommentsService(ICommentsRepository repository, IUnitOfWork unitOfWork, IMapper mapper,
        IUserAccessor userAccessor, UserManager<User> userManager, IActivitiesRepository activitiesRepository)
        : base(repository, unitOfWork, mapper)
        {
            _userManager = userManager;
            _activitiesRepository = activitiesRepository;
            _repository = repository;
            _userAccessor = userAccessor;
        }

        public async Task<Result<CommentDto>> CreateAsync(string body, Guid activityId)
        {
            var activity = await _activitiesRepository.GetAsync(activityId);
            if (activity == null) return null;

            var user = await _userManager.Users.Include(u => u.Photos)
                .SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
            if (user == null) return null;

            var comment = new Comment
            {
                Author = user,
                Activity = activity,
                Body = body
            };
            await Repository.CreateAsync(comment);
            activity.Comments.Add(comment);

            var result = await UnitOfWork.SaveAsync() > 0;

            return result
                ? Result<CommentDto>.Success(Mapper.Map<CommentDto>(comment))
                : Result<CommentDto>.Failure("Failed to add comment");
        }

        public async override Task<Result<CommentDto>> CreateAsync(CommentDto commentDto)
        {
            var user = await _userManager.FindByNameAsync(commentDto.Username);
            if (user == null) return null;

            var activity = await _activitiesRepository.GetAsync(commentDto.ActivityId);
            if (activity == null) return null;

            var comment = new Comment
            {
                Author = user,
                Activity = activity,
                Body = commentDto.Body
            };
            await Repository.CreateAsync(comment);
            activity.Comments.Add(comment);

            var result = await UnitOfWork.SaveAsync() > 0;

            return result
                ? Result<CommentDto>.Success(Mapper.Map<CommentDto>(comment))
                : Result<CommentDto>.Failure("Failed to add comment");
        }

        public async Task<Result<IEnumerable<CommentDto>>> GetAllCommentsOfActivity(Guid activityId)
        {
            var activity = await _activitiesRepository.GetAsync(activityId);
            if(activity == null) return null;

            var comments = await _repository.GetAllCommentsOfActivityAsync(activityId);
            var commentDtos = Mapper.Map<IEnumerable<CommentDto>>(comments);

            return Result<IEnumerable<CommentDto>>.Success(commentDtos);
        }
    }
}