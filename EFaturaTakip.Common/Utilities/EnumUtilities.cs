using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Utilities
{
    public class EnumUtilities
    {
        private readonly IConfiguration _configuration;

        public EnumUtilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetDescription(Enum value)
        {
            try
            {
                //return "Description";
                return !(value.GetType()
                   .GetField(value.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .SingleOrDefault() is DescriptionAttribute attribute) ? value.ToString() : attribute?.Description ?? String.Empty;
            }
            catch
            {

                return "";
            }
        }
        public static string GetDescription(Type enumType, int value)
        {
            var name = Enum.GetName(enumType, value);
            if (name == null) return string.Empty;
            var description = GetDescription((Enum)Enum.Parse(enumType, name));
            return description;
        }

        public static string GetName(Type enumType, int value)
        {
            var name = Enum.GetName(enumType, value);
            return name;
        }

        public static int GetValue(Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0)
                return Convert.ToInt16(en);

            var attrs = memInfo[0].GetCustomAttributes(typeof(EnumItem), false);
            return attrs.Length > 0
                ? Convert.ToInt16(((EnumItem)attrs[0]).Value)
                : Convert.ToInt16(en);
        }
        public static T GetValueByDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
        }
        public static int GetValueByName<T>(string name)
        {
            try
            {
                var type = typeof(T);
                int value = (int)Enum.Parse(type, name);
                return value;
            }
            catch (Exception)
            {
                return -1;
            }

        }
        public static IList<EnumItem> GetEnumList(Type enumType)
        {
            var list = new List<EnumItem>();
            var enumValues = Enum.GetValues(enumType);

            foreach (var value in enumValues)
            {
                var attribute = (EnumTextAttribute)enumType.GetMember(value.ToString())[0].GetCustomAttributes(typeof(EnumTextAttribute), false).FirstOrDefault();
                var text = attribute != null ? attribute.Text : value.ToString();

                list.Add(new EnumItem
                {
                    Text = text,
                    Value = value.GetHashCode()
                });
            }

            return list;
        }
        public static IList<EnumItem> GetDescriptionEnumList(Type enumType, bool select = false, string selectText = "")
        {
            IList<EnumItem> list = new List<EnumItem>();
            var values = Enum.GetValues(enumType);

            if (select) list.Add(new EnumItem((selectText ?? "Seçiniz.."), 0));

            foreach (
                var item in
                    from int value in values
                    select new EnumItem(GetDescription((Enum)Enum.Parse(enumType, value.ToString())), value))
            {
                list.Add(item);
            }
            return list;
        }

        public static IList<EnumItem> GetValueEnumList(Type enumType, bool select = false, string selectText = "")
        {
            IList<EnumItem> list = new List<EnumItem>();
            var values = Enum.GetValues(enumType);

            if (select) list.Add(new EnumItem((selectText ?? "Seçiniz.."), 0));

            foreach (
                var item in
                    from int value in values
                    select new EnumItem(GetDescription((Enum)Enum.Parse(enumType, value.ToString())), value))
            {
                item.Text = item.Text.Replace("KDV", "");
                list.Add(item);
            }
            return list;
        }


        public class LocalizedDescriptionAttribute : DescriptionAttribute
        {
            private readonly string _key;
            private readonly string _sagTarafaGelecekMetin;
            public LocalizedDescriptionAttribute(string Key, string sagTarafaGelecekMetin = "")
            {
                _key = Key;
                _sagTarafaGelecekMetin = sagTarafaGelecekMetin;
            }

            public override string Description
            {
                get
                {
                    try
                    {
                        var value = "";
                        //var value = ConfigurationManager.AppSettings[_key];
                        return (value + " " + _sagTarafaGelecekMetin).Trim();
                    }
                    catch (Exception)
                    {
                        return "Alternatif";
                    }

                }
            }
        }
    }
}

//{
//    "isNew": false,
//    "eFaturaNo": "GLY2022000001555",
//    "eFaturaId": "d11f1b04-be50-4298-8369-cd5f780ac6c3",
//    "documentIdF": "EFaturaId: d11f1b04-be50-4298-8369-cd5f780ac6c3",
//    "type": 0,
//    "typeCode": 0,
//    "typeCodeF": "Temel",
//    "typeCodeRenk": "#90a4ae",
//    "targetTcknVkn": "9000068418",
//    "targetTitle": "UYUMSOFT BİLGİ SİSTEMLERİ VE TEKNOLOJİLERİ TİCARET ANONİM ŞİRKETİ",
//    "envelopeIdentifier": "83d4a078-5a88-41d5-b9a5-bd372614631a",
//    "status": 1000,
//    "statusCode": 1000,
//    "statusCodeF": "Onaylandı",
//    "statusCodeRenk": "#66bb6a",
//    "isWaitingForApprovement": 0,
//    "envelopeStatus": 1300,
//    "envelopeStatusCode": 1300,
//    "envelopeStatusCodeF": "",
//    "message": null,
//    "createDateUtc": "2022-05-14T12:45:08.86",
//    "createDate": "2022-05-14T15:45:08.86",
//    "executionDate": "2022-05-14T15:36:00",
//    "payableAmount": 10.9,
//    "taxTotal": 1.8,
//    "taxExclusiveAmount": 10,
//    "payableAmountF": "10,90 ¤",
//    "taxExclusiveAmountF": "VHT= 10,00 ¤",
//    "documentCurrencyCode": "TRY",
//    "paraBirimId": 1,
//    "exchangeRate": 0,
//    "vat1": 0,
//    "vat1F": "0,00 ¤",
//    "vat8": 0,
//    "vat8F": "0,00 ¤",
//    "vat18": 1.8,
//    "vat18F": "1,80 ¤",
//    "partialTaxF": "%18=1,80 ¤",
//    "totalTaxF": "Top. Kdv= 1,80 ¤",
//    "vat0TaxableAmount": 0,
//    "vat1TaxableAmount": 0,
//    "vat8TaxableAmount": 0,
//    "vat18TaxableAmount": 10,
//    "orderDocumentId": null,
//    "isArchived": false,
//    "invoiceTipType": 2,
//    "invoiceTipTypeCode": 2,
//    "invoiceTipTypeCodeF": "Tevkifat"
//}
