using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IUserManager
    {
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
