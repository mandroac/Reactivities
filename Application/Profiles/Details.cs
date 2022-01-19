using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<Profile>>
        {
            public string Username { get; set; }

            public class Handler : IRequestHandler<Query, Result<Profile>>
            {
                private readonly IUnitOfWork _unitOfWork;
                private readonly IMapper _mapper;
                private readonly DataContext _context;
                public Handler(DataContext context, IMapper mapper, IUnitOfWork unitOfWork)
                {
                    _context = context;
                    _mapper = mapper;
                    _unitOfWork = unitOfWork;

                }
                public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var user = await _context.Users.ProjectTo<Profile>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync(x => x.Username == request.Username);
                    
                    if(user == null) return null;
                    return Result<Profile>.Success(user);
                }
            }
        }
    }
}