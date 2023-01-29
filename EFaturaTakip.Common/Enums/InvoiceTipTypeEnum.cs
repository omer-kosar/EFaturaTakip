using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum InvoiceTipTypeEnum
    {
        [Description("Satış")]
        SATIS = 0,
        [Description("Iade")]
        IADE = 1,
        [Description("Tevkifat")]
        TEVKIFAT = 2,
        [Description("İstisna")]
        ISTISNA = 3,
        [Description("Özel Matrah")]
        OZELMATRAH = 4,
        [Description("İhraç Kayıtlı")]
        IHRACKAYITLI = 6,
        [Description("Sgk")]
        SGK = 7,
        [Description("Komisyoncu")]
        KOMISYONCU = 8,
        [Description("Tevkifat İade")]
        TEVKIFATIADE = 11
    }
}