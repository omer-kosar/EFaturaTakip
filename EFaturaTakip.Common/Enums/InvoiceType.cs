using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum InvoiceTypes
    {
        [Description("Temel")]
        TEMELFATURA = 0,
        [Description("Ticari")]
        TICARIFATURA = 1,
        [Description("Yolcu")]
        YOLCUBERABERFATURA = 2,
        [Description("İhracat")]
        IHRACAT = 3,
        [Description("E-Arşiv")]
        EARSIV = 4,
        [Description("Hal")]
        HAL = 5,
        [Description("Kamu")]
        KAMU = 6
    }
}