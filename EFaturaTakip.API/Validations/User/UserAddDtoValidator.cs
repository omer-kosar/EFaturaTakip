using EFaturaTakip.Common.Enums;
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

            RuleFor(c => c.CommercialRegistrationNumber).NotEmpty().WithMessage("Ticari sicil numarası alanı boş olamaz.")
            .MaximumLength(255).WithMessage("Ticari sicil numarası 255 karakterden fazla olamaz.");
            RuleFor(c => c.CentralRegistrationNumber).NotEmpty().WithMessage("MERSİS numarası alanı boş olamaz.")
            .MaximumLength(255).WithMessage("MERSİS numarası 255 karakterden fazla olamaz.");
            RuleFor(c => c.Province).NotEmpty().WithMessage("İl 20 karakterden fazla olamaz.");
            RuleFor(c => c.District).NotEmpty().WithMessage("İlçe 20 karakterden fazla olamaz.");
            RuleFor(c => c.ApartmentNumber).NotEmpty().WithMessage("Bina numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Country).NotEmpty().WithMessage("Ülke 20 karakterden fazla olamaz.");
        }
    }
}
