using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController<Activity>
    {
        public ActivitiesController(IActivitiesService service) 
        : base(service)
        { 
        }
    }
}