using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IUserManager
    {
        void Create(User user);
        void Update(User entity);
        void Delete(User entity);
        User GetUser(Expression<Func<User, bool>> filter);
        List<User> GetAll();
        void UpdateWithRoles(User entity, List<Guid> roles);
        List<User> SearchFinancialAdvisor(string name, int take = 20);
        void ChangeAdvisor(Guid advisorId, Guid companyId);
    }
}
