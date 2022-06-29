using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum KdvEnum
    {
        [Description("%18")]
        OnSekiz = 18,
        [Description("%8")]
        Sekiz = 8,
        [Description("%1")]
        Bir = 1,
        [Description("%0")]
        Sifir = 0
    }
}
