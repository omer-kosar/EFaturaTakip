using AutoMapper;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Invoice;

namespace EFaturaTakip.API.Mapping.Invoice
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceDto, Entities.Invoice>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap()
                ;
            CreateMap<InvoiceItemDto, Entities.InvoiceItem>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId))
                .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(src => src.InvoiceId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PriceWithTax, opt => opt.MapFrom(src => src.PriceWithTax))
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.TotalPriceWithTax, opt => opt.MapFrom(src => src.TotalPriceWithTax))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap()
                ;
            CreateMap<Entities.Invoice, InvoiceListDto>()
                .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.EInvoiceId, opt => opt.MapFrom(src => src.EInvoiceId))
                .ForMember(dest => dest.EInvoiceNumber, opt => opt.MapFrom(src => src.EInvoiceNumber))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.InvoiceItems.Sum(i => i.TotalPriceWithTax)))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Type == (int)EnumCompanyType.Corporate ? src.Customer.Title : $"{src.Customer.FirstName} {src.Customer.LastName}"))
                ;
            CreateMap<Entities.InvoiceItem, InvoiceItemListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PriceWithTax, opt => opt.MapFrom(src => src.PriceWithTax))
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPriceWithTax))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                ;
        }
    }
}
