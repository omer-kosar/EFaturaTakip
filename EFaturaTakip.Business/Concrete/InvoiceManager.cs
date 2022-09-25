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
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceDao _invoiceDao;

        public InvoiceManager(IInvoiceDao invoiceDao)
        {
            _invoiceDao = invoiceDao;
        }

        public void Create(Invoice invoice)
        {
            SetInvoiceItemIds(invoice);
            _invoiceDao.Create(invoice);
        }
        private void SetInvoiceItemIds(Invoice invoice)
        {
            if (invoice is null || !invoice.InvoiceItems.Any()) return;
            invoice.Id = Guid.NewGuid();
            foreach (var item in invoice.InvoiceItems)
            {
                item.Id = Guid.NewGuid();
            }
        }
        public void Delete(Invoice invoice)
        {
            _invoiceDao.Delete(invoice);
        }

        public List<Invoice> GetAll()
        {
            return _invoiceDao.FindAll().ToList();
        }

        public List<Invoice> GetAllWithFilter(Expression<Func<Invoice, bool>> expression)
        {
            return _invoiceDao.FindInvoicesByCondition(expression).ToList();
        }

        public Invoice GetById(Guid id)
        {
            return _invoiceDao.Get(i => i.Id == id);
        }

        public void Update(Invoice invocie)
        {
            _invoiceDao.Update(invocie);
        }
    }
}
