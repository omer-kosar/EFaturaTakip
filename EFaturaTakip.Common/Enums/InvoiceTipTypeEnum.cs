using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum InvoiceTipTypeEnum
    {
        [Description("SATIS")]
        Sales = 0,
        [Description("Iade")]
        Return = 1,
        [Description("Tevkifat")]
        Tax = 2,
        [Description("İstisna")]
        Exception = 3,
        [Description("Özel Matrah")]
        TaxBase = 4,
        [Description("İhraç Kayıtlı")]
        ExportSaved = 6,
        [Description("Sgk")]
        Sgk = 7,
        [Description("Komisyoncu")]
        Broker = 8,
        [Description("Hal Satış")]
        HksSales = 9,
        [Description("Hal Komisyoncu")]
        HksBroker = 10,
        [Description("Tevkifat İade")]
        WithholdingReturn = 11
    }
}