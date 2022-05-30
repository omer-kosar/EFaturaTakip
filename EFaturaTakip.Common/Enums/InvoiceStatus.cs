using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Enums
{
    public enum InvoiceStatus
    {
        [Description("Hazırlanmadı")]
        NotPrepared = -100,
        [Description("Gönderilmedi")]
        NotSend = -50,
        [Description("Taslak")]
        Draft = 0,
        [Description("İptal Edildi")]
        Canceled = 10,
        [Description("Kuyrukta")]
        Queued = 100,
        [Description("İşleniyor")]
        Processing = 200,
        [Description("GİB’e Gönderildi")]
        SentToGib = 300,
        [Description("Onaylandı")]
        Approved = 1000,
        [Description("Onay Bekliyor")]
        WaitingForApprovement = 1100,
        [Description("Reddedildi")]
        Declined = 1200,
        [Description("İade Edildi")]
        Return = 1300,
        [Description("E-Arşiv İptal")]
        eArchiveCanceled = 1400,
        [Description("Hata")]
        Error = 2000
    }
}
