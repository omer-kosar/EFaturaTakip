using EFaturaTakip.Common.Repository.Concrete;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class InvoiceItemDao : RepositoryBase<InvoiceItem>, IInvoiceItemDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;

        public InvoiceItemDao(EFaturaTakipContext eFaturaTakipContext) : base(eFaturaTakipContext)
        {
            _efaturaTakipContext = eFaturaTakipContext;
        }

        public IEnumerable<InvoiceItem> FindInvoiceItemsByCondition(Expression<Func<InvoiceItem, bool>> expression)
        {
            return _efaturaTakipContext.InvoiceItem.Include(i => i.Stock).Where(expression).ToList();
        }
    }
}
