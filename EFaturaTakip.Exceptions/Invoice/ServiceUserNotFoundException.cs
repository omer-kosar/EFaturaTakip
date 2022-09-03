using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions.Invoice
{
    public class ServiceUserNotFoundException : BaseBusinessException
    {
        public ServiceUserNotFoundException(string message) : base(message)
        {
        }
    }
}
