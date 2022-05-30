using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum ParaBirimAdEnum
    {
        //[Description("Azeri Manatı")]
        //AZN = 1
        [Description("Türk Lirası")]
        Tl = 1,
        [Description("Dolar")]
        Usd = 2,
        [Description("EURO")]
        Euro = 3
    }
}
