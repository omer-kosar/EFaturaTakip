using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.User;
using FluentValidation;

namespace EFaturaTakip.API.Validations.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakterden fazla olamaz.");

            RuleFor(user => user.LastName).NotEmpty().WithMessage("Soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Kullanıcı soyadı 50 karakterden fazla olamaz.");

            RuleFor(user => user.Phone).NotEmpty().WithMessage("Telefon boş olamaz.")
                .MaximumLength(17).WithMessage("Telefon numarası 17 karakterden fazla olamaz.");

            RuleFor(user => user.Password).NotEmpty().WithMessage("Şifre boş olamaz.")
                .MaximumLength(10).WithMessage("Şifre 10 karakterden fazla olamaz.");
            
            RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Geçerli bir Email adresi giriniz.").When(i => !string.IsNullOrEmpty(i.Email));

            RuleFor(user => user.Roles).Must(roles => roles.Any()).WithMessage("Rol seçiniz");

            RuleFor(user => user.UserType).Must(userType => Enum.IsDefined(typeof(EnumUserType), userType)).WithMessage("Kullanıcı tipi seçiniz");

            RuleFor(c => c.Province).MaximumLength(20).WithMessage("İl 20 karakterden fazla olamaz.");
            RuleFor(c => c.District).MaximumLength(20).WithMessage("İlçe 20 karakterden fazla olamaz.");
            RuleFor(c => c.ApartmentNumber).MaximumLength(20).WithMessage("Bina numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Country).MaximumLength(20).WithMessage("Ülke 20 karakterden fazla olamaz.");
        }
    }
}
