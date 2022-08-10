using FluentValidation;

namespace EFaturaTakip.API.Validations.Company
{
    public class CompanyUpdateValidator : AbstractValidator<DTO.Company.CompanyUpdateDto>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(c => c.Title).NotNull().WithMessage("Adı Soyadı/Unvan boş olamaz.").NotEmpty().WithMessage("Adı Soyadı/Unvan boş olamaz.").MaximumLength(255).WithMessage("Adı Soyadı/Unvan boş olamaz. 255 karakterden fazla olamaz.");
            RuleFor(c => c.TcknVkn).NotNull().WithMessage("TCKN/VKN boş olamaz.").NotEmpty().WithMessage("TCKN/VKN boş olamaz.").MaximumLength(11).WithMessage("TCKN/VKN 255 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("İl 20 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("İlçe 20 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("Bina numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("Daire numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("Ülke 20 karakterden fazla olamaz.");
        }
    }
}
