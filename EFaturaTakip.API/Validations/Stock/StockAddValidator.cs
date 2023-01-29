using FluentValidation;

namespace EFaturaTakip.API.Validations.Stock
{
    public class StockAddValidator : AbstractValidator<DTO.Stock.StockAddDto>
    {
        public StockAddValidator()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Stok adı boş olamaz.").NotEmpty().WithMessage("Stok adı boş olamaz.").MaximumLength(255).WithMessage("Stok adı 255 karakterden fazla olamaz.");
            RuleFor(c => c.Price).NotNull().WithMessage("Fiyat boş olamaz").NotEmpty().WithMessage("Fiyat alanı boş olamaz."); 
            RuleFor(c => c.Unit).NotNull().WithMessage("Birim alanı boş olamaz.");
            RuleFor(c => c.ValueAddedTax).NotNull().WithMessage("Kdv alanı boş olamaz.");
        }
    }
}
