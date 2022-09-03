using FluentValidation;

namespace EFaturaTakip.API.Validations.User
{
    public class ChangePasswordDtoValidator : AbstractValidator<DTO.User.ChangePasswordDto>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(i => i.Password).NotEmpty().WithMessage("Mevcut şifreniz boş olamaz.");
            RuleFor(i => i.NewPassword).NotEmpty().WithMessage("Yeni şifreniz boş olamaz.");
            RuleFor(i => i.NewPasswordAgain).NotEmpty().WithMessage("Yeni şifrenizi tekrar giriniz.");
            RuleFor(i => i.NewPasswordAgain)
                .NotEmpty()
                .WithMessage("Yeni şifrenizi tekrar giriniz.")
                .Equal(i => i.NewPassword)
                .WithMessage("Yeni şifreniz ve tekar girdiğiniz yeni şifreniz uyuşmuyor.");

        }
    }
}
