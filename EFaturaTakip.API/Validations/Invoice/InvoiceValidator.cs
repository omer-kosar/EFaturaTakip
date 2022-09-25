using EFaturaTakip.DTO.Invoice;
using FluentValidation;

namespace EFaturaTakip.API.Validations.Invoice
{
    public class InvoiceValidator : AbstractValidator<InvoiceDto>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.CustomerId).NotEmpty().WithMessage("Firma seçiniz!");
            RuleFor(i => i.Date).NotEmpty().WithMessage("Tarih seçiniz!");
            RuleForEach(i => i.InvoiceItems).ChildRules(r =>
            {
                r.RuleFor(i => i.StockId).NotEmpty().WithMessage("{CollectionIndex} Satırı İçin Stok seçiniz!");
            });
        }
    }
}
