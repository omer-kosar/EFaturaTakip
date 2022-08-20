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
                .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.TcKimlikNo))
                .ForMember(dest => dest.VergiNo, opt => opt.MapFrom(src => src.VergiNo))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
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
                .ForMember(dest => dest.ServiceUserName, opt => opt.MapFrom(src => src.ServiceUserName))
                .ForMember(dest => dest.ServicePassword, opt => opt.MapFrom(src => src.ServicePassword))
                .ForMember(dest => dest.CommercialRegistrationNumber, opt => opt.MapFrom(src => src.CommercialRegistrationNumber))
                .ForMember(dest => dest.CentralRegistrationNumber, opt => opt.MapFrom(src => src.CentralRegistrationNumber))
                .ForMember(dest => dest.CompanySaveType, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
