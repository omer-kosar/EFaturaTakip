using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class StockManager : IStockManager
    {
        private readonly IStockDao _stockDao;

        public StockManager(IStockDao stockDao)
        {
            _stockDao = stockDao;
        }

        public void Create(Stock stock)
        {
            stock.Id = Guid.NewGuid();
            _stockDao.Create(stock);
        }

        public void Delete(Stock entity)
        {
            _stockDao.Delete(entity);
        }

        public List<Stock> GetAll()
        {
            return _stockDao.FindAll().ToList();
        }

        public Stock GetById(Guid id)
        {
            return _stockDao.Get(i => i.Id.Equals(id));
        }

        public void Update(Stock entity)
        {
            _stockDao.Update(entity);
        }
    }
}
