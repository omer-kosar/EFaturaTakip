using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class InvoiceItemManager : IInvoiceItemManager
    {
        private readonly IInvoiceItemDao _invoiceItemDao;

        public InvoiceItemManager(IInvoiceItemDao invoiceItemDao)
        {
            _invoiceItemDao = invoiceItemDao;
        }

        public List<InvoiceItem> GetAllWithFilter(Expression<Func<InvoiceItem, bool>> expression)
        {
            return _invoiceItemDao.FindInvoiceItemsByCondition(expression).ToList();
        }
    }
}
