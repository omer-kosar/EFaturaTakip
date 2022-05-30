using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum ParaBirimKodEFaturaEnum
    {
        [Description("TRY")]
        TRY = 1,
        //[Description("AZN")]
        //AZN = 1
        [Description("USD")]
        USD = 2,
        [Description("EUR")]
        EUR = 3
    }
}
