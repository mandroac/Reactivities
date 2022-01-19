using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Photos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }

            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly IUserAccessor _userAccessor;
                private readonly IPhotoAccessor _photoAccessor;
                private readonly IUsersRepository _usersRepository;
                private readonly IPhotosRepository _photosRepository;
                private readonly IUnitOfWork _unitOfWork;
                public Handler(IUsersRepository usersRepository, IPhotosRepository photosRepository,
                IPhotoAccessor photoAccessor, IUserAccessor userAccessor, IUnitOfWork unitOfWork)
                {
                    _unitOfWork = unitOfWork;
                    _photosRepository = photosRepository;
                    _usersRepository = usersRepository;
                    _photoAccessor = photoAccessor;
                    _userAccessor = userAccessor;

                }
                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var user = await _usersRepository.GetByUsernameAsync(_userAccessor.GetUsername());
                    if (user == null) return null;

                    var photo = await _photosRepository.GetAsync(request.Id);
                    if (photo == null) return null;

                    if (photo.IsMain) return Result<Unit>.Failure("You cannot delete your main photo");

                    var result = await _photoAccessor.DeletePhoto(photo.Id);
                    if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");

                    user.Photos.Remove(photo);
                    var success = await _unitOfWork.SaveAsync() > 0;

                    return success ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem deleting photo from API");
                }
            }
        }
    }
}