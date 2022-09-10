using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface ICompanyManager
    {
        void Create(Company company);
        void Update(Company company);
        void Delete(Company company);
        Company GetById(Guid id);
        List<Company> GetAll();
        List<Company> GetAllWithFilter(Expression<Func<Company, bool>> expression);
        List<Company> SearchCompany(string name, int take = 20);
        List<Company> SearchFinancialAdvisorCompany(Guid advisorId, string name, int take = 20);
        List<Company> GetAdvisorCompanies(Guid advisorId);
        void ChangeFinancialAdvisor(Guid advisorId, List<Guid> companies);
    }
}
