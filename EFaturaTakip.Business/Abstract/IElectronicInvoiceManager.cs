using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.UyumSoft.Model;
using EFaturaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Abstract
{
    public interface IElectronicInvoiceManager
    {
        GidenInvoiceInfo ConvertFromInvoiceToElectronicInvoice(Company currentCompany, Invoice invoice, InvoiceTypes invoiceScenarioType, InvoiceTipTypeEnum invoiceType);
    }
}
