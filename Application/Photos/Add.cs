using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Photos
{
    public class Add
    {
        public class Command : IRequest<Result<Photo>>
        {
            public IFormFile File { get; set; }

            public class Handler : IRequestHandler<Command, Result<Photo>>
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
                public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var user = await _usersRepository.GetByUsernameAsync(_userAccessor.GetUsername());

                    if (user == null) return null;

                    var photoUploadResult = await _photoAccessor.AddPhoto(request.File);
                    var photo = new Photo
                    {
                        Url = photoUploadResult.Url,
                        Id = photoUploadResult.PublicId
                    };

                    if (!user.Photos.Any(x => x.IsMain)) photo.IsMain = true;
                    user.Photos.Add(photo);

                    var result = await _unitOfWork.SaveAsync() > 0;

                    return result ? Result<Photo>.Success(photo) : Result<Photo>.Failure("Problem adding photo");
                }
            }
        }
    }
}