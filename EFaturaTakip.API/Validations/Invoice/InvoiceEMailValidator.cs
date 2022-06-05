using FluentValidation;

namespace EFaturaTakip.API.Validations.Invoice
{
    public class InvoiceEMailValidator : AbstractValidator<DTO.Invoice.InvioceEmailDto>
    {
        public InvoiceEMailValidator()
        {
            RuleFor(i => i.EMailAdress).NotEmpty().WithMessage("EMail adresi boş olamaz.");
            RuleFor(i => i.EMailAdress).EmailAddress().WithMessage("Mail adresi geçersiz.");
            RuleFor(i => i.UserId).NotEmpty().WithMessage("Fatura şu an mail olarak gönderilemiyor.");
        }
    }
}
