using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IStockManager
    {
        void Create(Stock user);
        void Update(Stock entity);
        void Delete(Stock entity);
        Stock GetById(Guid id);
        List<Stock> GetAll(Guid companyId);
        List<Stock> SearchStock(string name, int take = 20);
    }
}
