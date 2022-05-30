using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions.Invoice
{
    public class InvoiceListEmptyException : BaseBusinessException
    {
        public InvoiceListEmptyException(string message) : base(message)
        {
        }
    }
}
