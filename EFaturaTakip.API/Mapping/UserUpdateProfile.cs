using AutoMapper;
using EFaturaTakip.DTO.Role;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;

namespace EFaturaTakip.API.Mapping
{
    public class UserUpdateProfile : Profile
    {
        public UserUpdateProfile()
        {
            CreateMap<User, UserUpdateDto>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
           .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.Type));

            CreateMap<UserUpdateDto, User>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
           .ForMember(dest => dest.Roles, opt => opt.Ignore())
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.UserType));
        }
    }
}
