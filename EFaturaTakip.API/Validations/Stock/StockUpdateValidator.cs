using EFaturaTakip.DTO.Stock;
using FluentValidation;

namespace EFaturaTakip.API.Validations.Stock
{
    public class StockUpdateValidator : AbstractValidator<StockUpdateDto>
    {
        public StockUpdateValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Stok adı boş olamaz.").MaximumLength(255).WithMessage("Stok adı 255 karakterden fazla olamaz.");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Fiyat alanı boş olamaz."); //todo  check whether it will be seen when price is empty
            RuleFor(c => c.Unit).NotEmpty().WithMessage("Birim alanı boş olamaz.");
            RuleFor(c => c.ValueAddedTax).NotEmpty().WithMessage("Birim alanı boş olamaz.");
        }
    }
}
