using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum DocumentResponseStatus
    {
        [Description("Reddedildi")]
        Declined,
        [Description("Kabul Edildi")]
        Approved,
    }
}
