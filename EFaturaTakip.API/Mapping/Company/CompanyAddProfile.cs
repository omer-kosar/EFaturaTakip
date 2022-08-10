using AutoMapper;
using EFaturaTakip.DTO.Company;

namespace EFaturaTakip.API.Mapping.Company
{
    public class CompanyAddProfile : Profile
    {
        public CompanyAddProfile()
        {
            CreateMap<CompanyAddDto, Entities.Company>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.TcknVkn, opt => opt.MapFrom(src => src.TcknVkn))
                .ForMember(dest => dest.TaxOffice, opt => opt.MapFrom(src => src.TaxOffice))
                .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FaxNumber))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
                .ForMember(dest => dest.FlatNumber, opt => opt.MapFrom(src => src.FlatNumber))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ReverseMap();
        }
    }
}
