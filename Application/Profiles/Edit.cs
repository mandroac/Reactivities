using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Edit
    {
        public class Command : IRequest<Result<Profile>>
        {
            public string Username { get; set; }
            public string DisplayName { get; set; }
            public string Bio { get; set; }

            public class Handler : IRequestHandler<Command, Result<Profile>>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;

                public Handler(DataContext context, IMapper mapper)
                {
                    _mapper = mapper;
                    _context = context;
                }

                public async Task<Result<Profile>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var user = await _context.Users.Include(u => u.Photos)
                        .SingleOrDefaultAsync(u => u.UserName == request.Username);

                    if (user == null) return null;

                    if (request.DisplayName != null && request.DisplayName.Length > 0) user.DisplayName = request.DisplayName;
                    if (request.Bio != null) user.Bio = request.Bio;
                    
                    _context.Users.Update(user);
                    var result = await _context.SaveChangesAsync() > 0;

                    return result
                        ? Result<Profile>.Success(_mapper.Map<Profile>(user))
                        : Result<Profile>.Failure("An issue occured when updating profile info");
                }
            }
        }
    }
}