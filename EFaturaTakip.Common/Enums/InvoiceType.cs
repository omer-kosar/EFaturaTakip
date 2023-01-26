using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum InvoiceTypes
    {
        [Description("Temel")]
        BaseInvoice = 0,
        [Description("TICARIFATURA")]
        ComercialInvoice = 1,
        [Description("Yolcu")]
        InvoiceWithPassanger = 2,
        [Description("İhracat")]
        Export = 3,
        [Description("E-Arşiv")]
        eArchive = 4,
        [Description("Hal")]
        Hal = 5,
        [Description("Kamu")]
        Kamu = 6,
    }
}