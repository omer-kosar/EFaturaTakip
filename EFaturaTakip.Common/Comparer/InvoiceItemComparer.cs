using EFaturaTakip.Entities;
using System.Diagnostics.CodeAnalysis;

namespace EFaturaTakip.Common.Comparer
{
    public class InvoiceItemComparer : IEqualityComparer<InvoiceItem>
    {
        public bool Equals(InvoiceItem? x, InvoiceItem? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            //return x.Id == y.Id &&
            //       x.StockId == y.StockId &&
            //       x.Quantity == y.Quantity &&
            //       x.Price == y.Price &&
            //       x.PriceWithTax == y.PriceWithTax &&
            //       x.Tax == y.Tax &&
            //       x.TotalPrice == y.TotalPrice &&
            //       x.TotalPriceWithTax == y.TotalPriceWithTax;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] InvoiceItem obj)
        {
            if (obj == null)
            {
                return 0;
            }
            int IDHashCode = obj.Id.GetHashCode();
            return IDHashCode;
        }
    }
}
