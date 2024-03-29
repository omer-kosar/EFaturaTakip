﻿using EFaturaTakip.Common.Repository.Concrete;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class RoleDao : RepositoryBase<Role>, IRoleDao
    {
        public RoleDao(EFaturaTakipContext eFaturaTakipContext) : base(eFaturaTakipContext)
        {
        }
    }
}
