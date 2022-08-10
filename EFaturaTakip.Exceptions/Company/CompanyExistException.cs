using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions.Company
{
    public class CompanyExistException : BaseBusinessException
    {
        public CompanyExistException(string message) : base(message)
        {
        }
    }
}
