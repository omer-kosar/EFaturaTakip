using AutoMapper;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
using EFaturaTakip.DTO.Stock;

namespace EFaturaTakip.API.Mapping.Stock
{
    public class StockListProfile : Profile
    {
        public StockListProfile()
        {
            CreateMap<Entities.Stock, StockListDto>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.ValueAddedTax, opt => opt.MapFrom(src => src.ValueAddedTax))
                .ForMember(dest => dest.UnitDescription, opt => opt.MapFrom(src => EnumUtilities.GetDescription(typeof(EnumUnit), src.Unit)))
                .ReverseMap();
            CreateMap<Entities.Stock, StockSearchDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.ValueAddedTax))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
