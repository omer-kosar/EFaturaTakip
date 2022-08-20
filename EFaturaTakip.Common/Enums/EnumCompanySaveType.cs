using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum EnumCompanySaveType
    {
        None = 0,
        [Description("Programı Kullanan Firma")]
        CompanyUsingProgram = 1,
        [Description("Müşteri")]
        Customer = 2,
    }
}
