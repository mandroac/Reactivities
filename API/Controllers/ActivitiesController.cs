using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [AllowAnonymous]
    public class ActivitiesController : BaseApiController<Activity>
    {
        public ActivitiesController(IActivitiesService service) 
        : base(service)
        { 
        }
    }
}