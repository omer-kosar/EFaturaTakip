using AutoMapper;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;

namespace EFaturaTakip.API.Mapping
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<User, UserInfoDto>()
                .ForMember(userInfo => userInfo.FirstName, user => user.MapFrom(src => src.FirstName))
                .ForMember(userInfo => userInfo.LastName, user => user.MapFrom(src => src.LastName))
                .ForMember(userInfo => userInfo.Email, user => user.MapFrom(src => src.Email))
                .ForMember(userInfo => userInfo.Phone, user => user.MapFrom(src => src.Phone))
                .ForMember(userInfo => userInfo.Roles, user => user.MapFrom(src => src.Roles.Select(i => i.Role.Name)))
                .ForMember(userInfo => userInfo.Id, user => user.MapFrom(src => src.Id));
        }
    }
}
