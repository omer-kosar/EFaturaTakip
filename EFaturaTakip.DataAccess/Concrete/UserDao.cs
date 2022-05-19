using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class UserDao : RepositoryBase<User>, IUserDao
    {
        public UserDao(EFaturaTakipContext eFaturaTakipContext) : base(eFaturaTakipContext)
        {
        }
    }
}
