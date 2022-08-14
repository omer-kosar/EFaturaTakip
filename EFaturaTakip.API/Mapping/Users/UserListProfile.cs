using AutoMapper;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;

namespace EFaturaTakip.API.Mapping.Users
{
    public class UserListProfile : Profile
    {
        public UserListProfile()
        {
            CreateMap<User, UserListDto>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLoginDate))
               .ForMember(dest => dest.Roles,
                opt => opt.MapFrom(r => !r.Roles.Any() ?
                new List<string> { "Rol bulunamadı." } :
                r.Roles.Select(i => i.Role.Name).ToList()))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               ;
        }
    }
}
