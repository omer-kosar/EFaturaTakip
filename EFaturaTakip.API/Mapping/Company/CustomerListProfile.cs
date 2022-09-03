using AutoMapper;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
using EFaturaTakip.DTO.Company;

namespace EFaturaTakip.API.Mapping.Company
{
    public class CustomerListProfile : Profile
    {
        public CustomerListProfile()
        {
            CreateMap<Entities.Company, CustomerListDto>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.TcKimlikNo))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.TaxOffice, opt => opt.MapFrom(src => src.TaxOffice))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
            .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FaxNumber))
            .ForMember(dest => dest.EMailAdress, opt => opt.MapFrom(src => src.EMailAdress))
            .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
            .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FlatNumber))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.CentralRegistrationNumber, opt => opt.MapFrom(src => src.CentralRegistrationNumber))
            .ForMember(dest => dest.CommercialRegistrationNumber, opt => opt.MapFrom(src => src.CommercialRegistrationNumber))
            .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(src => EnumUtilities.GetDescription(typeof(EnumCompanyType), src.Type)))
            .ReverseMap();
        }
    }
}
