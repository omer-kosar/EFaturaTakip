using EFaturaTakip.Common.Repository.Concrete;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class CompanyDao : RepositoryBase<Company>, ICompanyDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;

        public CompanyDao(EFaturaTakipContext efaturaTakipContext) : base(efaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }
    }
}
