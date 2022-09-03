using AutoMapper;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;

namespace EFaturaTakip.API.Mapping.Users
{
    public class FinancialAdvisorSearchProfile : Profile
    {
        public FinancialAdvisorSearchProfile()
        {
            CreateMap<User, FinancialAdvisorSearchDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.Companies.Select(i => i.Id).ToList()));
        }
    }
}
