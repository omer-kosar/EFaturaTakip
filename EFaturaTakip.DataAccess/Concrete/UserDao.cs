using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class UserDao : RepositoryBase<User>, IUserDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;
        public UserDao(EFaturaTakipContext eFaturaTakipContext, EFaturaTakipContext efaturaTakipContext) : base(eFaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }

        public User GetUser(Expression<Func<User, bool>> filter)
        {
            return _efaturaTakipContext.User.Include(user => user.Roles).ThenInclude(userRole => userRole.Role).SingleOrDefault(filter);
        }
    }
}
