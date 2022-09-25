using EFaturaTakip.Common.Repository.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Abstract
{
    public interface IInvoiceDao : IRepositoryBase<Invoice>
    {
        IEnumerable<Invoice> FindInvoicesByCondition(Expression<Func<Invoice, bool>> expression);
    }
}
