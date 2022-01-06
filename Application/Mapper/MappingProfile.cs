using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>().ForMember(act => act.Id, opt => opt.Ignore());
        }
    }
}