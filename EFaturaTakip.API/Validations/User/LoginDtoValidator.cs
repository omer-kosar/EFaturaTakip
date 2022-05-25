using FluentValidation;

namespace EFaturaTakip.API.Validations.User
{
    public class LoginDtoValidator : AbstractValidator<DTO.User.LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(i => i.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
            RuleFor(i => i.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
        }
    }
}
