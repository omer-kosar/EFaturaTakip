using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum EnumUserType
    {
        None = 0,
        [Description("Admin")]
        Admin = 1,
        [Description("Mükellef")]
        TaxPayer = 2,
        [Description("Muhasebeci")]
        Accountant = 3
    }
}
