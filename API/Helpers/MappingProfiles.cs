using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Signal, SignalToReturnDto>()
                .ForMember(s => s.SignalProtocol, o => o.MapFrom(s => s.SignalProtocol.Name));
        }
    }
}