using EFaturaTakip.DTO.User;
using FluentValidation;

namespace EFaturaTakip.API.Validations.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakterden fazla olamaz.");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Kullanıcı soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı soyadı 50 karakterden fazla olamaz.");

            RuleFor(u => u.Phone).NotEmpty().WithMessage("Telefon boş olamaz.")
                .MaximumLength(14).WithMessage("Telefon numarası 14 karakterden fazla olamaz.");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş olamaz.")
                .MaximumLength(10).WithMessage("Şifre 10 karakterden fazla olamaz.");

            RuleFor(customer => customer.Email)
            .EmailAddress()
            .WithMessage("Geçerli bir Email adresi giriniz.").When(i => !string.IsNullOrEmpty(i.Email));
        }
    }
}
