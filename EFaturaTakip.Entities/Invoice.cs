using System;
namespace EFaturaTakip.Entities
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
        public Guid EInvoiceId { get; set; }
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public string EInvoiceNumber { get; set; } = string.Empty;
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public virtual Company Company { get; set; }
        public virtual Company Customer { get; set; }
    }
}
