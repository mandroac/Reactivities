using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Profiles
{
    public class UserActivities
    {
        public class Query : IRequest<Result<IEnumerable<PartialActivityDto>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }

            public class Handler : IRequestHandler<Query, Result<IEnumerable<PartialActivityDto>>>
            {
                private readonly IActivitiesRepository _activitiesRepository;
                private readonly IMapper _mapper;
                public Handler(IActivitiesRepository activitiesRepository, IMapper mapper)
                {
                    _mapper = mapper;
                    _activitiesRepository = activitiesRepository;

                }
                public async Task<Result<IEnumerable<PartialActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var query = _activitiesRepository.GetAllAsQueryable()
                        .Where(a => a.Attendees.Any(aa => aa.User.UserName == request.Username))
                        .OrderBy(a => a.Date)
                        .ProjectTo<PartialActivityDto>(_mapper.ConfigurationProvider);

                    switch (request.Predicate)
                    {
                        case "future":
                            query = query.Where(a => a.Date > DateTime.Now);
                            break;
                        case "past":
                            query = query.Where(a => a.Date < DateTime.Now);
                            break;
                        case "hosting":
                            query = query.Where(a => a.HostUsername == request.Username);
                            break;
                    }

                    return Result<IEnumerable<PartialActivityDto>>.Success(await query.ToListAsync());
                }
            }
        }
    }
}