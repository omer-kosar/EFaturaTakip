using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum ParaBirimKodEnum
    {
        [Description("TRY")]
        Tl = 1,
        //[Description("AZN")]
        //AZN = 1
        [Description("USD")]
        Usd = 2,
        [Description("EUR")]
        Euro = 3
    }
}
