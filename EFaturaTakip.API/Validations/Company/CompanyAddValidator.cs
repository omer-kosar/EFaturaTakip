using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Company;
using FluentValidation;

namespace EFaturaTakip.API.Validations.Company
{
    public class CompanyAddValidator : AbstractValidator<DTO.Company.CompanyAddDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompanyAddValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            RuleFor(c => c).Must(ValidateVergiNo)
                .When(c => (EnumCompanyType)c.Type != EnumCompanyType.Person)
                .WithMessage("Vergi no boş olamaz.");
            RuleFor(c => c.VergiNo).MaximumLength(10).WithMessage("Vergi no 10 karakterden fazla olamaz.");

            RuleFor(c => c).Must(ValidateTaxOffice)
                .When(c => (EnumCompanyType)c.Type != EnumCompanyType.Person)
                .WithMessage("Vergi dairesi boş olamaz.");

            RuleFor(c => c).Must(ValidateFirstName)
                .When(c => (EnumCompanyType)c.Type != EnumCompanyType.Corporate)
                .WithMessage("Ad boş olamaz.");

            RuleFor(c => c).Must(ValidateLastName)
                .When(c => (EnumCompanyType)c.Type != EnumCompanyType.Corporate)
                .WithMessage("Soyad boş olamaz.");
            RuleFor(c => c).Must(ValidateTCKimlikNo).When(c => (EnumCompanyType)c.Type != EnumCompanyType.Corporate).WithMessage("T.C. kimlik no boş olamaz.");

            RuleFor(c => c).Must(ValidateTitle)
                .When(c => (EnumCompanyType)c.Type == EnumCompanyType.Corporate)
                .WithMessage("Unvan boş olamaz.");

            RuleFor(c => c.Title).MaximumLength(255).WithMessage("Unvan 255 karakterden fazla olamaz.");

            RuleFor(user => user.ServiceUserName)
                .Must(ValidateServiceUserName).When(c => UserIsAdmin()).WithMessage("Servis kullanıcı adı boş olamaz.")
                .MaximumLength(50).WithMessage("Servis kullanıcı adı 50 karakterden fazla olamaz.");
            RuleFor(user => user.ServicePassword)
                .Must(ValidateServicePassword).When(c => UserIsAdmin()).WithMessage("Servis parolası boş olamaz.")
                .MaximumLength(50).WithMessage("Servis kullanıcı parolası 50 karakterden fazla olamaz.");

            RuleFor(c => c.Title).MaximumLength(255).WithMessage("Unvan 255 karakterden fazla olamaz.");
            RuleFor(c => c.TcKimlikNo).MaximumLength(11).WithMessage("T.C. kimlik numarası 11 karakterden fazla olamaz.");
            RuleFor(c => c.Province).MaximumLength(20).WithMessage("İl 20 karakterden fazla olamaz.");
            RuleFor(c => c.District).MaximumLength(20).WithMessage("İlçe 20 karakterden fazla olamaz.");
            RuleFor(c => c.ApartmentNumber).MaximumLength(20).WithMessage("Bina numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.FlatNumber).MaximumLength(20).WithMessage("Daire numarası 20 karakterden fazla olamaz.");
            RuleFor(c => c.Country).MaximumLength(20).WithMessage("Ülke 20 karakterden fazla olamaz.");
            RuleFor(c => c.Adress).NotEmpty().WithMessage("Açık adres boş olamaz.");

            RuleFor(c => c.CommercialRegistrationNumber).NotEmpty().WithMessage("Ticari sicil numarası alanı boş olamaz.")
            .MaximumLength(50).WithMessage("Ticari sicil numarası 50 karakterden fazla olamaz.");
            RuleFor(c => c.CentralRegistrationNumber).NotEmpty().WithMessage("MERSİS numarası alanı boş olamaz.")
            .MaximumLength(50).WithMessage("MERSİS numarası 50 karakterden fazla olamaz.");

            RuleFor(c => c.FirstName).MaximumLength(50).WithMessage("Adı 50 karakterden fazla olamaz.");
            RuleFor(c => c.LastName).MaximumLength(50).WithMessage("Soyadı 50 karakterden fazla olamaz.");

        }

        private bool ValidateFirstName(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.FirstName);
        }
        private bool ValidateLastName(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.LastName);
        }
        private bool ValidateTCKimlikNo(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.TcKimlikNo);
        }
        private bool ValidateTitle(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.Title);
        }
        private bool ValidateServiceUserName(string userName)
        {
            return !string.IsNullOrWhiteSpace(userName);
        }
        private bool ValidateServicePassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }
        private bool ValidateVergiNo(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.VergiNo);
        }
        private bool ValidateTaxOffice(CompanyAddDto model)
        {
            return !string.IsNullOrWhiteSpace(model.TaxOffice);
        }
        private bool UserIsAdmin()
        {
            int userType = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type.Equals("UserType")).Value);
            return userType == (int)EnumUserType.Admin;
        }
    }
}
