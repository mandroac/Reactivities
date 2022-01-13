using AutoMapper;
using Domain.Models;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>().ForMember(act => act.Id, opt => opt.Ignore());
        }
    }
}