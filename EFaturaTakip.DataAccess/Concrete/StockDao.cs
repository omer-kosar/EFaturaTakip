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
    public class StockDao : RepositoryBase<Stock>, IStockDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;

        public StockDao(EFaturaTakipContext efaturaTakipContext) : base(efaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }
    }
}
