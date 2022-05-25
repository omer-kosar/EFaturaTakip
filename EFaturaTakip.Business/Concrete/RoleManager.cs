using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.DTO.Role;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class RoleManager : IRoleManager
    {
        readonly IRoleDao _roleDao;

        public RoleManager(IRoleDao roleDao)
        {
            _roleDao = roleDao;
        }

        public List<Role> GetAll()
        {
            return _roleDao.FindAll().ToList();
        }
    }
}
