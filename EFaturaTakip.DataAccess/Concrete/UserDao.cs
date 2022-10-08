using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFaturaTakip.Common.Repository.Concrete;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class UserDao : RepositoryBase<User>, IUserDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;
        public UserDao(EFaturaTakipContext eFaturaTakipContext, EFaturaTakipContext efaturaTakipContext) : base(eFaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }

        public List<User> GetAllUserWithRoles()
        {
            return _efaturaTakipContext.User.Include(user => user.Roles).ThenInclude(i => i.Role).ToList();
        }
        public List<User> GetAllUserWithCompany(Expression<Func<User, bool>> filter)
        {
            if (filter == null)
                return _efaturaTakipContext.User.Include(user => user.Company).ToList();
            return _efaturaTakipContext.User.Include(user => user.Company).Where(filter).ToList();
        }
        public User GetUser(Expression<Func<User, bool>> filter)
        {
            return _efaturaTakipContext.User
                .Include(user => user.Roles)
                .ThenInclude(userRole => userRole.Role).SingleOrDefault(filter);
        }

        public List<UserRole> GetUserRoles(Guid userId)
        {
            return _efaturaTakipContext.UserRole.Where(i => i.UserId == userId).ToList();
        }
        public IEnumerable<User> FindByConditionFinincialAdvisor(Expression<Func<User, bool>> expression)
        {
            return _efaturaTakipContext.User.Where(expression).Include(t => t.Companies);
        }
    }
}
