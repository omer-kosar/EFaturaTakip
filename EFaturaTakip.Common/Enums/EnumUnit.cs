using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum EnumUnit
    {
        [Description("Adet")]
        Piece = 0,
        [Description("Kilogram")]
        Kilogram = 1,
        [Description("Metre")]
        Metre = 2
    }
}
