using EFaturaTakip.Common.Repository.Concrete;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFaturaTakip.Common.Repository.Concrete;
namespace EFaturaTakip.DataAccess.Concrete
{
    public class InvoiceDao : RepositoryBase<Invoice>, IInvoiceDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;

        public InvoiceDao(EFaturaTakipContext efaturaTakipContext) : base(efaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }

        public IEnumerable<Invoice> FindInvoicesByCondition(Expression<Func<Invoice, bool>> expression)
        {
            if (expression == null)
                return _efaturaTakipContext.Invoice.Include(i => i.Customer).Include(i => i.Customer);
            return _efaturaTakipContext.Invoice.Include(i => i.InvoiceItems).Include(i => i.Customer).Where(expression);
        }

        public Invoice GetById(Guid id)
        {
            return _efaturaTakipContext.Invoice.Include(i => i.InvoiceItems).ThenInclude(i => i.Stock).Include(i => i.Customer).First(i => i.Id == id);
        }
    }
}
