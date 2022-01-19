using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Photos
{
    public class SetMain
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }

            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly IPhotoAccessor _photoAccessor;
                private readonly IUserAccessor _userAccessor;
                private readonly IUsersRepository _usersRepository;
                private readonly IUnitOfWork _unitOfWork;
                public Handler(IUsersRepository usersRepository, IUnitOfWork unitOfWork,
                    IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
                {
                    _unitOfWork = unitOfWork;
                    _usersRepository = usersRepository;
                    _userAccessor = userAccessor;
                    _photoAccessor = photoAccessor;
                }
                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var user = await _usersRepository.GetByUsernameAsync(_userAccessor.GetUsername());
                    if(user == null) return null;

                    var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);
                    if(photo == null) return null;

                    var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
                    if(currentMain != null) currentMain.IsMain = false;
                    photo.IsMain = true;

                    var success = await _unitOfWork.SaveAsync() > 0;
                    return success ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem setting new main photo");
                }
            }
        }
    }
}