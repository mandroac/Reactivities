using System.Linq;
using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>().ForMember(act => act.Id, opt => opt.Ignore());

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.User.DisplayName))
                .ForMember(d => d.Bio, opt => opt.MapFrom(s => s.User.Bio))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.User.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Activity, ActivityDto>()
                .ForMember(d => d.HostUsername, opt => opt.MapFrom(s => s.Attendees
                .FirstOrDefault(x => x.IsHost).User.UserName))
                .ReverseMap()
                .ForMember(act => act.Id, opt => opt.Ignore())
                .ForMember(act => act.Attendees, opt => opt.Ignore());

            CreateMap<User, Profiles.Profile>()
                .ForMember(p => p.Image, o => o.MapFrom(u => u.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}