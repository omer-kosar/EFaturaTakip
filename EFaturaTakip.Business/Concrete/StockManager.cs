﻿using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.Stock;
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
            bool isStockUser = IsStockExist(stock.Name, stock.Id);
            if (isStockUser)
                throw new StockExistException($"{stock.Name} kayıtlıdır. Aynı isimle birden fazla stok kaydedemezsiniz.");
            _stockDao.Create(stock);
            Save();
        }

        public void Delete(Stock entity)
        {
            _stockDao.Delete(entity);
            Save();
        }

        public List<Stock> GetAll(Guid companyId)
        {
            return _stockDao.FindByCondition(i => i.CompanyId == companyId).ToList();
        }

        public Stock GetById(Guid id)
        {
            return _stockDao.Get(i => i.Id.Equals(id));
        }

        public void Update(Stock entity)
        {
            bool isStockUser = IsStockExist(entity.Name, entity.Id);
            if (isStockUser)
                throw new StockExistException($"{entity.Name} kayıtlıdır. Aynı isimle birden fazla stok kaydedemezsiniz.");
            _stockDao.Update(entity);
            Save();
        }
        public List<Stock> SearchStock(string name, int take = 20)
        {
            if (string.IsNullOrWhiteSpace(name))
                return _stockDao.FindAll().Take(take).ToList();
            return _stockDao.FindByCondition(i => i.Name.Contains(name))
                            .Take(take).ToList();
        }
        private bool IsStockExist(string name, Guid id)
        {
            return _stockDao.FindByCondition(i => i.Id != id && i.Name.ToLower().Equals(name.ToLower())).Any();
        }
        private void Save()
        {
            _stockDao.Save();
        }
    }
}
