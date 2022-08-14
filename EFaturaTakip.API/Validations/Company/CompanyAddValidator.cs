﻿using FluentValidation;

namespace EFaturaTakip.API.Validations.Company
{
    public class CompanyAddValidator : AbstractValidator<DTO.Company.CompanyAddDto>
    {
        public CompanyAddValidator()
        {
            RuleFor(c => c.Title).NotNull().WithMessage("Adı Soyadı/Unvan boş olamaz.").NotEmpty().WithMessage("Adı Soyadı/Unvan boş olamaz.").MaximumLength(255).WithMessage("Adı Soyadı/Unvan boş olamaz. 255 karakterden fazla olamaz.");
            RuleFor(c => c.TcknVkn).NotNull().WithMessage("TCKN/VKN boş olamaz.").NotEmpty().WithMessage("TCKN/VKN boş olamaz.").MaximumLength(11).WithMessage("TCKN/VKN 255 karakterden fazla olamaz.");
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
        }
    }
}