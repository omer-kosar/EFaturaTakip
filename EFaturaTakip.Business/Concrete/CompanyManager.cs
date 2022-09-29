using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.Company;
using EFaturaTakip.Exceptions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyDao _companyDao;
        private readonly IUserDao _userDao;

        public CompanyManager(ICompanyDao companyDao, IUserDao userDao)
        {
            _companyDao = companyDao;
            _userDao = userDao;
        }

        public void Create(Company company)
        {
            EnumCompanyType companyType = (EnumCompanyType)company.Type;
            string tcknVkn = companyType == EnumCompanyType.Corporate ? company.VergiNo : company.TcKimlikNo;
            company.Id = Guid.NewGuid();
            if (IsExistCompany(tcknVkn, companyType, company.Id))
                throw new CompanyExistException("Belirtilen TCKN/VKN ile firma kaydı bulunmaktadır.Firma kaydedilemedi.");
            _companyDao.Create(company);
            Save();
        }

        public void Delete(Company company)
        {
            _companyDao.Delete(company);
            Save();
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
            Save();
        }
        public List<Company> SearchCompany(string name, int take = 20)
        {
            if (string.IsNullOrWhiteSpace(name))
                return _companyDao.FindByCondition(i => i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram).Take(take).ToList();
            return _companyDao.FindByCondition(i =>
            i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram &&
            (i.Title.Contains(name) ||
            i.FirstName.Contains(name) ||
            i.LastName.Contains(name)))
                .Take(take).ToList();
        }
        public List<Company> SearchFinancialAdvisorCompany(Guid advisorId, string name, int take = 20)
        {
            if (string.IsNullOrWhiteSpace(name))
                return _companyDao.FindByCondition(i => i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram &&
                                                        i.MusavirId == advisorId).Take(take).ToList();
            return _companyDao.FindByCondition(i =>
            i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram &&
            i.MusavirId == advisorId &&
            (i.Title.Contains(name) ||
            i.FirstName.Contains(name) ||
            i.LastName.Contains(name)))
                .Take(take).ToList();
        }

        public List<Company> SearchCustomer(Guid companyId, string name, int take)
        {
            if (string.IsNullOrWhiteSpace(name))
                return _companyDao.FindByCondition(i => i.CompanyId == companyId && i.CompanySaveType == (int)EnumCompanySaveType.Customer).Take(20).ToList();
            return _companyDao.FindByCondition(i => i.CompanyId == companyId &&
                                                    i.CompanySaveType == (int)EnumCompanySaveType.Customer &&
                                                    (i.Title.Contains(name) || i.FirstName.Contains(name) ||
                                                    i.LastName.Contains(name))).Take(take).ToList();
        }
        public List<Company> GetAdvisorCompanies(Guid advisorId)
        {
            return _companyDao.FindByCondition(i => i.MusavirId == advisorId && i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram).ToList();
        }
        private bool IsExistCompany(string tcknVkn, EnumCompanyType companyType, Guid companyId)
        {
            if (companyType == EnumCompanyType.Corporate)
                return _companyDao.FindByCondition(i => i.VergiNo.Equals(tcknVkn) && i.Id != companyId).Any();
            return _companyDao.FindByCondition(i => i.TcKimlikNo.Equals(tcknVkn) && i.Id != companyId).Any();
        }

        public void ChangeFinancialAdvisor(Guid advisorId, List<Guid> companies)
        {
            var advisor = _userDao.Get(i => i.Id == advisorId);
            if (advisor is null)
            {
                throw new UserExistException("Mali müşavir bulunamadı.");
            }
            var companyList = _companyDao.FindByCondition(i => i.MusavirId == advisorId && i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram);
            var addedCompanyIdList = companies.Where(i => companyList.All(c => c.Id != i));
            var removedCompanies = companyList.Where(i => !companies.Contains(i.Id)).ToList();
            foreach (var item in removedCompanies)
            {
                item.MusavirId = null;
            }
            var addedCompanies = _companyDao.FindByCondition(i => addedCompanyIdList.Contains(i.Id)).ToList();
            foreach (var item in addedCompanies)
            {
                item.MusavirId = advisorId;
            }
            _companyDao.Update(addedCompanies);
            _companyDao.Update(removedCompanies);
            Save();
        }
        public List<Company> GetAllWithFilter(Expression<Func<Company, bool>> expression)
        {
            return _companyDao.FindByCondition(expression).ToList();
        }
        private void Save()
        {
            _companyDao.Save();
        }
    }
}
