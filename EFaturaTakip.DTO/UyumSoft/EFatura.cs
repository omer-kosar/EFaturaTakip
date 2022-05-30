using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Providers;
using EFaturaTakip.Common.Utilities;
using Newtonsoft.Json;
using System;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class EFatura
    {
        public bool IsNew { get; set; }
        [JsonProperty("InvoiceId")]
        public string EFaturaNo { get; set; }
        [JsonProperty("DocumentId")]
        public string EFaturaId { get; set; }
        public string DocumentIdF => "EFaturaId: " + EFaturaId;
        public InvoiceTypes Type { get; set; }
        public int TypeCode { get; set; }
        public string TypeCodeF => EnumUtilities.GetDescription(Type);
        public string TypeCodeRenk => Type == InvoiceTypes.BaseInvoice ? "#90a4ae" :
           Type == InvoiceTypes.ComercialInvoice ? "Coral" : "#ff6666";
        public string TargetTcknVkn { get; set; }
        public string TargetTitle { get; set; }
        public string EnvelopeIdentifier { get; set; }
        public InvoiceStatus Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeF => EnumUtilities.GetDescription(Status);
        public string StatusCodeRenk => Status == InvoiceStatus.Approved ? "#66bb6a" :
            Status == InvoiceStatus.WaitingForApprovement ? "#2196f3" :
            Status == InvoiceStatus.Declined ? "#ff6666" :
            Status == InvoiceStatus.Return ? "Coral" : "#ff6666";
        public int IsWaitingForApprovement => Status == InvoiceStatus.WaitingForApprovement ? 25 : 0;

        public EnvelopeStatus EnvelopeStatus { get; set; }
        public int EnvelopeStatusCode { get; set; }
        public string EnvelopeStatusCodeF => EnumUtilities.GetDescription(EnvelopeStatus);
        public string Message { get; set; }
        public DateTime CreateDateUtc { get; set; }
        //utc den datetime çevirme
        public DateTime CreateDate => CreateDateUtc.AddHours(3);//tükrkiye Utc sıfır noktasına göre 3 saat ileride
        //public DateTime CreateDate => DateTime.SpecifyKind(CreateDateUtc, DateTimeKind.Utc);
        //public DateTime CreateDateF => CreateDate.ToLocalTime();
        public DateTime? ExecutionDate { get; set; }
        public decimal PayableAmount { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal TaxExclusiveAmount { get; set; }

        public string PayableAmountF => FormatProvider.CurrencyFormat(PayableAmount, ParaBirimId);
        //public int ParaBirimId { get; set; } = 1;
        public string TaxExclusiveAmountF => "VHT= " + FormatProvider.CurrencyFormat(TaxExclusiveAmount, ParaBirimId);
        public string DocumentCurrencyCode { get; set; }
        public int ParaBirimId => EnumUtilities.GetValueByName<ParaBirimKodEFaturaEnum>(DocumentCurrencyCode);
        public decimal ExchangeRate { get; set; }
        public decimal Vat1 { get; set; }
        public string Vat1F => FormatProvider.CurrencyFormat(Vat1, ParaBirimId);
        public decimal Vat8 { get; set; }
        public string Vat8F => FormatProvider.CurrencyFormat(Vat8, ParaBirimId);
        public decimal Vat18 { get; set; }
        public string Vat18F => FormatProvider.CurrencyFormat(Vat18, ParaBirimId);
        public string PartialTaxF => (Vat18 != 0 ? "%18=" + Vat18F : "") + (Vat8 != 0 ? "%8=" + Vat8F : "") + (Vat1 != 0 ? "%1=" + Vat1F : "");
        public string TotalTaxF => "Top. Kdv= " + FormatProvider.CurrencyFormat(TaxTotal, ParaBirimId);
        public decimal Vat0TaxableAmount { get; set; }
        public decimal Vat1TaxableAmount { get; set; }
        public decimal Vat8TaxableAmount { get; set; }
        public decimal Vat18TaxableAmount { get; set; }
        public string OrderDocumentId { get; set; }
        public bool IsArchived { get; set; }

        //Bu ikisi restte var ama soap ta yok. Bunu firmaya sor
        //portalde ger faturanın altında defaultgb yazıyor o nedr.
        //Onaylanırken yada reddeilirken Kabul ediliyor şeklinde bir duruma geçiyor portalde. Bizde ise onay bekliyor aşamasında hala
        //Senario alanı 
        //ınvoice type alnında Kamu var bu nedir. 6 nolu enum. 5 kim o zaman
        //utc ye 3 saat eklemek yeteli mi

        //sayfayı yenileme butonu ekle
        //Sadece ticari olanlarda kabül et ve reddet butonlarını aktfi et
        public InvoiceTipTypeEnum InvoiceTipType { get; set; }
        public int InvoiceTipTypeCode { get; set; }
        public string InvoiceTipTypeCodeF => EnumUtilities.GetDescription(InvoiceTipType);

    }
}
