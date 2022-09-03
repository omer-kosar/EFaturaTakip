using EFaturaTakip.Common.Repository.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Abstract
{
    public interface IUserDao : IRepositoryBase<User>
    {
        User GetUser(Expression<Func<User, bool>> filter);

        List<User> GetAllUserWithRoles();

        List<UserRole> GetUserRoles(Guid userId);
        IEnumerable<User> FindByConditionFinincialAdvisor(Expression<Func<User, bool>> expression);
    }
}
