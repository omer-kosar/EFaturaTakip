using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
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
            EnumCompanyType companyType = (EnumCompanyType)company.Type;
            string tcknVkn = companyType == EnumCompanyType.Corporate ? company.VergiNo : company.TcKimlikNo;
            company.Id = Guid.NewGuid();
            if (IsExistCompany(tcknVkn, companyType, company.Id))
                throw new CompanyExistException("Belirtilen TCKN/VKN ile firma kaydı bulunmaktadır.Firma kaydedilemedi.");
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
            EnumCompanyType companyType = (EnumCompanyType)company.Type;
            string tcknVkn = companyType == EnumCompanyType.Corporate ? company.VergiNo : company.TcKimlikNo;
            var existCompany = IsExistCompany(tcknVkn, companyType, company.Id);
            if (existCompany)
                throw new CompanyExistException("Belirtilen TCKN/VKN ile firma kaydı bulunmaktadır.Firma güncellenemedi.");
            _companyDao.Update(company);
        }
        private bool IsExistCompany(string tcknVkn, EnumCompanyType companyType, Guid companyId)
        {
            if (companyType == EnumCompanyType.Corporate)
                return _companyDao.FindByCondition(i => i.VergiNo.Equals(tcknVkn) && i.Id != companyId).Any();
            return _companyDao.FindByCondition(i => i.TcKimlikNo.Equals(tcknVkn) && i.Id != companyId).Any();
        }
    }
}
