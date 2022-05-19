using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions
{
    public abstract class BaseBusinessException : Exception
    {
        public BaseBusinessException(string message) : base(message)
        {

        }
    }
}
