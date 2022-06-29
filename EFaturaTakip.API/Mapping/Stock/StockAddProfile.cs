using AutoMapper;
using EFaturaTakip.DTO.Stock;

namespace EFaturaTakip.API.Mapping.Stock
{
    public class StockAddProfile : Profile
    {
        public StockAddProfile()
        {
            CreateMap<StockAddDto, EFaturaTakip.Entities.Stock>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.ValueAddedTax, opt => opt.MapFrom(src => src.ValueAddedTax))
                .ReverseMap()
                ;
        }
    }
}
