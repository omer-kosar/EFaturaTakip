using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum ParaBirimEnum
    {
        //[Description("₼")]
        //Tl = 1,
        [Description("₺")]
        Tl = 1,
        [Description("$")]
        Usd = 2,
        [Description("€")]
        Euro = 3
    }
}
