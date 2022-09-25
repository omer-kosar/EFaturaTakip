using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IInvoiceManager
    {
        void Create(Invoice invoice);
        void Update(Invoice invocie);
        void Delete(Invoice invoice);
        Invoice GetById(Guid id);
        List<Invoice> GetAll();
        List<Invoice> GetAllWithFilter(Expression<Func<Invoice, bool>> expression);
    }
}
