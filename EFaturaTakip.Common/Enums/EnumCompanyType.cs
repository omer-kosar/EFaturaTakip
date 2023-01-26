﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum EnumCompanyType
    {
        None = 0,
        [Description("Bireysel Kişi")]
        Person = 1,
        [Description("Şahıs Firması")]
        PrivateCompany = 2,
        [Description("Tüzel")]
        Corporate = 3
    }
}
