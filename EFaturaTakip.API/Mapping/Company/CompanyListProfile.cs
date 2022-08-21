using AutoMapper;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
using EFaturaTakip.DTO.Company;

namespace EFaturaTakip.API.Mapping.Company
{
    public class CompanyListProfile : Profile
    {
        public CompanyListProfile()
        {
            CreateMap<Entities.Company, CompanyListDto>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.TcKimlikNo))
            .ForMember(dest => dest.TaxOffice, opt => opt.MapFrom(src => src.TaxOffice))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
            .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FaxNumber))
            .ForMember(dest => dest.EMailAdress, opt => opt.MapFrom(src => src.EMailAdress))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.ApartmentNumber))
            .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FlatNumber))
            .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(src => EnumUtilities.GetDescription(typeof(EnumCompanyType), src.Type)))
            .ReverseMap();

            CreateMap<Entities.Company, CompanySearchDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type == (int)EnumCompanyType.Corporate ? src.Title : $"{src.FirstName} {src.LastName}"));
        }
    }
}
