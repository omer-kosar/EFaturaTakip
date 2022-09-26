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
    public interface IInvoiceItemDao : IRepositoryBase<InvoiceItem>
    {
        IEnumerable<InvoiceItem> FindInvoiceItemsByCondition(Expression<Func<InvoiceItem, bool>> expression);
    }
}
