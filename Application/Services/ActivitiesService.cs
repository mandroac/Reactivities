using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ActivitiesService : ServiceBase<Activity> , IActivitiesService
    {
        public ActivitiesService(IActivitiesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        :base(repository, unitOfWork, mapper)
        {
        }
    }
}