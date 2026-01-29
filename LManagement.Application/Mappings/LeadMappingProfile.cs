using AutoMapper;
using LManagement.Application.DTOs.LeadDtos;
using LManagement.Domain.Entities;

namespace LManagement.Application.Mappings
{
    public class LeadMappingProfile: Profile
    {
        public LeadMappingProfile()
        {
            CreateMap<LeadCreateDto, Lead>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<LeadUpdateDto, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Source, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
