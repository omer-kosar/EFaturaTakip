﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Company
{
    public class CompanyAddDto : BaseCompanyDto
    {
        public string? ServiceUserName { get; set; }
        public string? ServicePassword { get; set; }
    }
}
