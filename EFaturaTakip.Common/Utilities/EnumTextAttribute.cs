using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Utilities
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumTextAttribute : Attribute
    {
        public string Text { get; set; }
    }
}
