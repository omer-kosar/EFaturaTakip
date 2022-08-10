using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyDao _companyDao;

        public CompanyManager(ICompanyDao companyDao)
        {
            _companyDao = companyDao;
        }

        public void Create(Company company)
        {
            if (IsExistCompany(company.TcknVkn))
                throw new CompanyExistException("Belirtilen TCKN/VKN ile firma kaydı bulunmaktadır.Firma kaydedilemedi.");
            company.Id = Guid.NewGuid();
            _companyDao.Create(company);
        }

        public void Delete(Company company)
        {
            _companyDao.Delete(company);
        }

        public List<Company> GetAll()
        {
            return _companyDao.FindAll().ToList();
        }

        public Company GetById(Guid id)
        {
            return _companyDao.Get(i => i.Id == id);
        }

        public void Update(Company company)
        {
            var existCompany = _companyDao.FindByCondition(i => i.TcknVkn.Equals(company.TcknVkn) && i.Id != company.Id).Any();
            if (existCompany)
                throw new CompanyExistException("Belirtilen TCKN/VKN ile firma kaydı bulunmaktadır.Firma güncellenemedi.");
            _companyDao.Update(company);
        }
        private bool IsExistCompany(string tcknVkn)
        {
            return _companyDao.FindByCondition(i => i.TcknVkn.Equals(tcknVkn)).Any();
        }
    }
}
