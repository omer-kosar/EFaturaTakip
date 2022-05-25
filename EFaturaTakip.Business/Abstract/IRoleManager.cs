using EFaturaTakip.DTO.Role;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IRoleManager
    {
        List<Role> GetAll();
    }
}
