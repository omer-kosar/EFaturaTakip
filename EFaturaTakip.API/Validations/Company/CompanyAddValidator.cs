using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Company;
using FluentValidation;

namespace EFaturaTakip.API.Validations.Company
{
    public class CompanyAddValidator : AbstractValidator<DTO.Company.CompanyAddDto>
    {
        public CompanyAddValidator()
        {
            RuleFor(c => c.Title).MaximumLength(255).WithMessage("Unvan 255 karakterden fazla olamaz.");
            RuleFor(c => c.TcKimlikNo).MaximumLength(11).WithMessage("T.C. kimlik numarası 11 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("İl 20 karakterden fazla olamaz.");
            RuleFor(c => c.District).MaximumLength(20).WithMessage("İlçe 20 karakterden fazla olamaz.");
            RuleFor(c => c.ApartmentNumber).MaximumLength(20).WithMessage("Bina numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.FlatNumber).MaximumLength(20).WithMessage("Daire numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Country).MaximumLength(20).WithMessage("Ülke 20 karakterden fazla olamaz.");
            RuleFor(c => c.Adress).NotEmpty().WithMessage("Açık adres boş olamaz.");
            RuleFor(user => user.ServiceUserName).NotEmpty().WithMessage("Servis kullanıcı adı boş olamaz.")
            .MaximumLength(50).WithMessage("Servis kullanıcı adı 50 karakterden fazla olamaz.");
            RuleFor(user => user.ServicePassword).NotEmpty().WithMessage("Servis parolası adı boş olamaz.")
            .MaximumLength(50).WithMessage("Servis kullanıcı parolası 50 karakterden fazla olamaz.");
            RuleFor(c => c.CommercialRegistrationNumber).NotEmpty().WithMessage("Ticari sicil numarası alanı boş olamaz.")
         .MaximumLength(50).WithMessage("Ticari sicil numarası 50 karakterden fazla olamaz.");
            RuleFor(c => c.CentralRegistrationNumber).NotEmpty().WithMessage("MERSİS numarası alanı boş olamaz.")
            .MaximumLength(50).WithMessage("MERSİS numarası 50 karakterden fazla olamaz.");
            RuleFor(c => c.VergiNo).NotEmpty().WithMessage("Vergi no boş olamaz.");
            RuleFor(c => c).Must(ValidateFirstName).WithMessage("Ad boş olamaz.");
            RuleFor(c => c).Must(ValidateLastName).WithMessage("Soyad boş olamaz.");
            RuleFor(c => c).Must(ValidateTCKimlikNo).WithMessage("T.C. kimlik no boş olamaz.");
            RuleFor(c => c).Must(ValidateTitle).WithMessage("Unvan boş olamaz.");
        }

        private bool ValidateFirstName(CompanyAddDto model)
        {
            if ((EnumCompanyType)model.Type != EnumCompanyType.Corporate)
                return !string.IsNullOrWhiteSpace(model.FirstName);
            return true;
        }
        private bool ValidateLastName(CompanyAddDto model)
        {
            if ((EnumCompanyType)model.Type != EnumCompanyType.Corporate)
                return !string.IsNullOrWhiteSpace(model.LastName);
            return true;
        }
        private bool ValidateTCKimlikNo(CompanyAddDto model)
        {
            if ((EnumCompanyType)model.Type != EnumCompanyType.Corporate)
                return !string.IsNullOrWhiteSpace(model.TcKimlikNo);
            return true;
        }
        private bool ValidateTitle(CompanyAddDto model)
        {
            if ((EnumCompanyType)model.Type == EnumCompanyType.Corporate)
                return !string.IsNullOrWhiteSpace(model.Title);
            return true;
        }

    }
}
