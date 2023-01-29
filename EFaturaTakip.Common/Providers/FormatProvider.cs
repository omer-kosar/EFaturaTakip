using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Providers
{
    public class FormatProvider
    {
        private static readonly CultureInfo Culture = CultureTool.CurrentCultureTmp;
        //private static readonly CultureInfo Culture = new CultureInfo("de-DE");

        public static string CurrencyFormat(decimal value, int paraBirimId)
        {
            var dc = $"{value:#,##0.00;}";
            string aa= Convert.ToDecimal(dc) != value
                ? string.Format(Culture, "{0:#,####0.0000;} {1}", value, EnumUtilities.GetDescription(typeof(ParaBirimEnum), paraBirimId))
                : string.Format(Culture, "{0:#,##0.00;} {1}", value, EnumUtilities.GetDescription(typeof(ParaBirimEnum), paraBirimId));
            return aa;
            //var dc = $"{value:#,##0.00;}";
            //return Convert.ToDecimal(dc) != value
            //    ? string.Format(Culture, "{0:#,####0.0000;} {1}", value, EnumUtilities.GetDescription(typeof(ParaBirimEnum), paraBirimId))
            //    : string.Format(Culture, "{0:#,##0.00;} {1}", value, EnumUtilities.GetDescription(typeof(ParaBirimEnum), paraBirimId));

        }

        public static string DecimalFormat(decimal value)
        {
            return
                //virgülden sonra hane yoksa
                Convert.ToDecimal($"{value:#,##0;}") == value
                ? string.Format(Culture, "{0:#,##0;}", value)
                //virgülden sonra 1 hane
                : Convert.ToDecimal($"{value:#,##0.0;}") == value ?
                 string.Format(Culture, "{0:#,##0.0;}", value)

                //virgülden sonra 2 hane
                : Convert.ToDecimal($"{value:#,##0.00;}") == value ?
                 string.Format(Culture, "{0:#,##0.00;}", value) :
                  //virgülden sonra 3 hane
                  Convert.ToDecimal($"{value:#,##0.000;}") == value ?
                 string.Format(Culture, "{0:#,##0.000;}", value) :
                 //hiç biri değilse 4 hane
                 string.Format(Culture, "{0:#,####0.0000;}", value);
        }

        //public static string DateFormat(DateTime value)
        //    => string.Format(CultureTool.CurrentCulture, "{0:dd MMM yyyy, ddd}", value);
        public static string DateFormat(DateTime? value)
        {
            if (value == null)
            {
                return "";
            }
            return string.Format(CultureTool.CurrentCulture, "{0:dd MMM yyyy, ddd}", value);
        }

        public static string DateFormatWithClock(DateTime? value)
        {
            if (value == null)
            {
                return "";
            }
            var formatTime = $"{{0:{CultureTool.ShortTimePattern}}}";
            var time = string.Format(CultureTool.CurrentCulture, formatTime, value);

            var date = string.Format(CultureTool.CurrentCulture, "{0:dd MMM yyyy, ddd}", value);
            return date + " " + time;
        }

        public static string TimeFormat(DateTime? value)
        {
            if (value == null)
            {
                return "";
            }
            var format1 = $"{{0:{CultureTool.ShortTimePattern}}}";
            var time = string.Format(CultureTool.CurrentCulture, format1, value);
            return time;
        }
    }
}
