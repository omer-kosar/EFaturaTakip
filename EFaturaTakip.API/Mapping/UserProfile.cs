using AutoMapper;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;

namespace EFaturaTakip.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(r => r.Roles.Select(i => new UserRole { RoleId = i })))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.UserType));
        }
    }
}
