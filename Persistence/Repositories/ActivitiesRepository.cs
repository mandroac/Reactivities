using Domain.Interfaces;
using Domain.Models;

namespace Persistence.Repositories
{
    public class ActivitiesRepository : RepositoryBase<Activity>, IActivitiesRepository
    {
        public ActivitiesRepository(DataContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}