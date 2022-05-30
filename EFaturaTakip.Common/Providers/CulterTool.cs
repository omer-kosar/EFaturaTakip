using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Providers
{
    public static class CultureTool
    {
        private static CultureInfo _currentCulture;

        public static CultureInfo CurrentCulture
        {
            get
            {
                if (_currentCulture == null)
                {
                    _currentCulture = new CultureInfo("tr-TR");
                }
                return _currentCulture;
            }
            set { _currentCulture = value; }
        }
        //Programda bazı yerler de-DE yapılmış. tr-Tr ile  de-DE farkını bilmediğim için ihtyaten şimdilik de-DE olanları de-DE ypıyorum. 
        public static CultureInfo CurrentCultureTmp
        {
            get
            {
                if (_currentCulture == null)
                {
                    string CulterName = "";
                    try
                    {
                        //todo app setting ten çek
                        CulterName = "tr-TR";
                    }
                    catch (System.Exception)
                    {
                    }
                    if (string.IsNullOrEmpty(CulterName))
                    {
                        CulterName = "en-EN";
                    }

                    try
                    {
                        _currentCulture = new CultureInfo(CulterName);
                    }
                    catch (System.Exception)
                    {
                    }

                    if (_currentCulture == null)
                    {
                        _currentCulture = new CultureInfo("en-EN");
                    }

                }
                return _currentCulture;
            }
            set { _currentCulture = value; }
        }

        public static string DecimalAyiraci { get; set; } = CurrentCultureTmp.NumberFormat.CurrencyDecimalSeparator;
        public static string BinlikAyiraci { get; set; } = CurrentCultureTmp.NumberFormat.CurrencyGroupSeparator;
        public static string DefaultParaIconu { get; set; } = CurrentCultureTmp.Parent.NumberFormat.CurrencySymbol;
        public static bool IsRightToLeft { get; set; } = CurrentCultureTmp.TextInfo.IsRightToLeft;
        public static string LongDatePattern { get; set; } = CurrentCultureTmp.DateTimeFormat.LongDatePattern;
        public static string ShortDatePattern { get; set; } = CurrentCultureTmp.DateTimeFormat.ShortDatePattern;
        public static string ShortTimePattern { get; set; } = CurrentCultureTmp.DateTimeFormat.ShortTimePattern;
        public static string LongTimePattern { get; set; } = CurrentCultureTmp.DateTimeFormat.LongTimePattern;
    }
}
