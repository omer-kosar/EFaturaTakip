using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions.User
{
    public class UserExistException : BaseBusinessException
    {
        public UserExistException(string message) : base(message)
        {

        }
    }
}
