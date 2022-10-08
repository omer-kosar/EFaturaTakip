using AutoMapper;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
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
               .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLoginDate))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Type == (int)EnumCompanyType.Corporate ? src.Company.Title : $"{src.Company.FirstName} {src.Company.LastName}"))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(src => EnumUtilities.GetDescription(typeof(EnumUserType), src.Type)))
               ;
        }
    }
}
