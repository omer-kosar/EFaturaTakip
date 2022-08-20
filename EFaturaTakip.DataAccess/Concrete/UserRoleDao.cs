using EFaturaTakip.Common.Repository.Concrete;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DataAccess.Concrete
{
    public class UserRoleDao : RepositoryBase<UserRole>, IUserRoleDao
    {
        private readonly EFaturaTakipContext _efaturaTakipContext;
        public UserRoleDao(EFaturaTakipContext eFaturaTakipContext, EFaturaTakipContext efaturaTakipContext) : base(eFaturaTakipContext)
        {
            _efaturaTakipContext = efaturaTakipContext;
        }

        public void UpdateRange(List<UserRole> roles)
        {
            _efaturaTakipContext.UpdateRange(roles);
        }
        public void RemoveRange(List<UserRole> roles)
        {
            _efaturaTakipContext.RemoveRange(roles);
        }

    }
}
