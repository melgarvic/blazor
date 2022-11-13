using AutoMapper;
using Blazor.Starter.Server.Models;

namespace Blazor.Starter.Server.Profiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Person, PersonDto>()
                .ReverseMap()
                .ForMember(dest => dest.PersonId, src => src.MapFrom(person => person.PersonId));
        }
    }
}
