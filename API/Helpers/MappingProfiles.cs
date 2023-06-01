using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Signal, SignalToReturnDto>()
                .ForMember(s => s.SignalProtocol, o => o.MapFrom(s => s.SignalProtocol.Name));

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<SignalDto, Signal>()
                .ForMember(s => s.SignalProtocol, o => o.Ignore());
            // .ForMember(s => s.SignalProtocolId, o => o.Ignore());
        }
    }
}