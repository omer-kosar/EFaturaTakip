using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Comparer;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.DTO.Invoice;
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
        //private readonly IInvoiceItemDao _invoiceItemDao;
        public InvoiceManager(IInvoiceDao invoiceDao)
        {
            _invoiceDao = invoiceDao;
        }

        public void Create(Invoice invoice)
        {
            //SetInvoiceItemIds(invoice);
            _invoiceDao.Create(invoice);
            Save();
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
            Save();
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
        public Invoice UpdateInvoiceWithItems(InvoiceDto invoiceModel, Guid invoiceId, Guid companyId)
        {
            var invoice = _invoiceDao.FindInvoicesByCondition(i => i.Id == invoiceId && i.CompanyId == companyId).First();
            RemoveInvoiceItems(invoice, invoiceModel);
            UpdateInvoiceItems(invoice, invoiceModel);
            AddNewInvoiceItems(invoice, invoiceModel);
            UpdateInvoice(invoice, invoiceModel);
            _invoiceDao.Update(invoice);
            Save();
            return invoice;
        }
        private void RemoveInvoiceItems(Invoice invoice, InvoiceDto invoiceModel)
        {
            List<InvoiceItem> removedItems = new List<InvoiceItem>();
            foreach (var item in invoice.InvoiceItems)
            {
                if (!invoiceModel.InvoiceItems.Any(i => i.Id == item.Id))
                    removedItems.Add(item);
            }
            foreach (var item in removedItems)
            {
                invoice.InvoiceItems.Remove(item);
            }
        }
        private void UpdateInvoiceItems(Invoice invoice, InvoiceDto invoiceModel)
        {
            foreach (var item in invoice.InvoiceItems)
            {
                var updatedInvoiceItem = invoiceModel.InvoiceItems.First(i => i.Id == item.Id);
                item.StockId = (Guid)updatedInvoiceItem.StockId;
                item.Quantity = updatedInvoiceItem.Quantity;
                item.Price = updatedInvoiceItem.Price;
                item.PriceWithTax = updatedInvoiceItem.PriceWithTax;
                item.Tax = updatedInvoiceItem.Tax;
                item.TotalPrice = updatedInvoiceItem.TotalPrice;
                item.TotalPriceWithTax = updatedInvoiceItem.TotalPriceWithTax;
                item.Comment = updatedInvoiceItem.Comment;
            }
        }
        private void AddNewInvoiceItems(Invoice invoice, InvoiceDto invoiceModel)
        {
            foreach (var item in invoiceModel.InvoiceItems.Where(i => i.Id == Guid.Empty))
            {
                invoice.InvoiceItems.Add(new InvoiceItem
                {
                    StockId = item.StockId.Value,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    PriceWithTax = item.PriceWithTax,
                    TotalPrice = item.TotalPrice,
                    TotalPriceWithTax = item.TotalPriceWithTax,
                    Comment = item.Comment
                });

            }
        }
        private void UpdateInvoice(Invoice invoice, InvoiceDto invoiceModel)
        {
            invoice.CustomerId = invoiceModel.CustomerId;
            invoice.Date = invoiceModel.Date.Value;
            invoice.Comment = invoiceModel.Comment;
        }

        private void Save()
        {
            _invoiceDao.Save();
        }
    }
}
