using Domain.Interfaces;
using Domain.Models;

namespace Persistence.Repositories
{
    public class PhotosRepository : RepositoryBase<Photo, string>, IPhotosRepository
    {
        public PhotosRepository(DataContext repositoryContext) : base(repositoryContext)
        { 
        }
    }
}