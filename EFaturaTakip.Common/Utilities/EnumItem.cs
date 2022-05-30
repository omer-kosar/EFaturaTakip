using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Utilities
{
    public class EnumItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public EnumItem(string text)
        {
            Text = text;
        }
        public EnumItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public EnumItem()
        {

        }
    }
}
