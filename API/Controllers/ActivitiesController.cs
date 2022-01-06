using Application.Interfaces;
using Domain.Models;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController<Activity>
    {
        public ActivitiesController(IActivitiesService service) 
        : base(service)
        { }
    }
}