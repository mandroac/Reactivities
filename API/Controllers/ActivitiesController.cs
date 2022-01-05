using Domain.Interfaces;
using Domain.Models;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController<Activity>
    {
        public ActivitiesController(IActivitiesRepository repository, IUnitOfWork unitOfWork) 
        : base(repository, unitOfWork)
        {
        }


    }
}