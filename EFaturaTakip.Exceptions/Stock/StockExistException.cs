using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Exceptions.Stock
{
    public class StockExistException : BaseBusinessException
    {
        public StockExistException(string message) : base(message)
        {

        }
    }
}
