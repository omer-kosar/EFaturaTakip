using EFaturaTakip.API.Enums;
using EFaturaTakip.DTO.User;
using FluentValidation;

namespace EFaturaTakip.API.Validations.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakterden fazla olamaz.");

            RuleFor(user => user.LastName).NotEmpty().WithMessage("Kullanıcı soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı soyadı 50 karakterden fazla olamaz.");

            RuleFor(user => user.Phone).NotEmpty().WithMessage("Telefon boş olamaz.")
                .MaximumLength(14).WithMessage("Telefon numarası 14 karakterden fazla olamaz.");

            RuleFor(user => user.Password).NotEmpty().WithMessage("Şifre boş olamaz.")
                .MaximumLength(10).WithMessage("Şifre 10 karakterden fazla olamaz.");

            RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Geçerli bir Email adresi giriniz.").When(i => !string.IsNullOrEmpty(i.Email));

            RuleFor(user => user.Roles).Must(roles => roles.Any()).WithMessage("Rol seçiniz");

            RuleFor(user => user.UserType).Must(userType => !Enum.IsDefined(typeof(EnumUserType), userType)).WithMessage("Kullanıcı tipi seçiniz");
        }
    }
}
