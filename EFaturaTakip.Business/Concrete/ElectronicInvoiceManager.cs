using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.Common.Utilities;
using EFaturaTakip.DTO.UyumSoft.Model;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.ElectronicInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Business.Concrete
{
    public class ElectronicInvoiceManager : IElectronicInvoiceManager
    {
        public GidenInvoiceInfo ConvertFromInvoiceToElectronicInvoice(Company currentCompany, Invoice invoice, InvoiceTypes invoiceScenarioType, InvoiceTipTypeEnum invoiceType)
        {
            if (currentCompany == null)
                throw new ElectronicInvoiceConvertException("Firma bulunamadı.");
            if (invoice == null)
                throw new ElectronicInvoiceConvertException("Fatura bulunamadı.");
            if (invoice.Company == null)
                throw new ElectronicInvoiceConvertException("Cari bilgileri bulunamadı.");
            CheckCompany(currentCompany);
            CheckCari(invoice.Customer);
            CheckInvoiceItems(invoice);
            return CreateElectronicInvoice(invoice, currentCompany, invoiceScenarioType, invoiceType);
        }

        private void CheckCompany(Company currentCompany)
        {
            CheckCompanyTaxOffice(currentCompany);
            if ((EnumCompanyType)currentCompany.Type == EnumCompanyType.Corporate)
            {
                CheckCompanyVergiNo(currentCompany);
                CheckCompanyName(currentCompany);
            }
            if ((EnumCompanyType)currentCompany.Type == EnumCompanyType.PrivateCompany)
            {
                CheckPrivateCompanyTCKN(currentCompany);
                CheckPrivateCompanyName(currentCompany);
            }
        }
        private void CheckCari(Company cari)
        {
            if ((EnumCompanyType)cari.Type == EnumCompanyType.Corporate || (EnumCompanyType)cari.Type == EnumCompanyType.PrivateCompany)
            {
                CheckCariTaxOffice(cari);
            }
            if ((EnumCompanyType)cari.Type == EnumCompanyType.Corporate)
            {
                CheckCariVergiNo(cari);
                CheckCariName(cari);
            }
            if ((EnumCompanyType)cari.Type == EnumCompanyType.PrivateCompany || (EnumCompanyType)cari.Type == EnumCompanyType.Person)
            {
                CheckCariTCKN(cari);
                CheckCariFullName(cari);
            }
        }
        private void CheckCompanyTaxOffice(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.TaxOffice))
                throw new ElectronicInvoiceConvertException("Firmanızın vergi dairesi boş olamaz.");
        }
        private void CheckCariTaxOffice(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.TaxOffice))
                throw new ElectronicInvoiceConvertException("Fatura carisi vergi dairesi boş olamaz.");
        }

        private void CheckCompanyVergiNo(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.VergiNo))
                throw new ElectronicInvoiceConvertException("Firmanızın vergi dairesi boş olamaz.");
            if (company.VergiNo.Length != 10)
                throw new ElectronicInvoiceConvertException("Firmanızın vergi numarası 10 haneli olamlı.");
        }
        private void CheckCariVergiNo(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.VergiNo))
                throw new ElectronicInvoiceConvertException("Fatura carisi vergi numarası boş olamaz.");
            if (company.VergiNo.Length != 10)
                throw new ElectronicInvoiceConvertException("Fatura carisi vergi numarası 10 haneli olamlı.");
        }
        private void CheckCompanyName(Company company)
        {
            if (string.IsNullOrEmpty(company.Title))
                throw new ElectronicInvoiceConvertException("Firmanızın resmi adı boş olamaz.");
        }
        private void CheckCariName(Company company)
        {
            if (string.IsNullOrEmpty(company.Title))
                throw new ElectronicInvoiceConvertException("Fatura carisi resmi adı boş olamaz.");
        }
        private void CheckPrivateCompanyTCKN(Company company)
        {
            if (string.IsNullOrEmpty(company.TcKimlikNo))
                throw new ElectronicInvoiceConvertException("Firmanızın TC numarası boş olamaz.");
            if (company.TcKimlikNo.Length != 11)
                throw new ElectronicInvoiceConvertException("Firmanızın TC numarası 11 haneli olmalı.");
        }
        private void CheckCariTCKN(Company company)
        {
            if (string.IsNullOrEmpty(company.TcKimlikNo))
                throw new ElectronicInvoiceConvertException("Fatura carisi TC numarası boş olamaz.");
            if (company.TcKimlikNo.Length != 11)
                throw new ElectronicInvoiceConvertException("Fatura carisi TC numarası 11 haneli olmalı.");
        }

        private void CheckPrivateCompanyName(Company company)
        {
            if (string.IsNullOrEmpty(company.FirstName))
                throw new ElectronicInvoiceConvertException("Şahıs firmanızın adı boş olamaz.");

            if (string.IsNullOrEmpty(company.LastName))
                throw new ElectronicInvoiceConvertException("Şahıs firmanızın soyadı boş olamaz.");
        }
        private void CheckCariFullName(Company company)
        {
            if (string.IsNullOrEmpty(company.FirstName))
                throw new ElectronicInvoiceConvertException("Fatura carisi adı boş olamaz.");

            if (string.IsNullOrEmpty(company.LastName))
                throw new ElectronicInvoiceConvertException("Fatura carisi soyadı boş olamaz.");
        }

        private void CheckInvoiceItems(Invoice invoice)
        {
            if (invoice.InvoiceItems.Any(i => i.Tax == 0))
                throw new ElectronicInvoiceConvertException("Fatura kalemlerinde kdv seçilmemiş satırlar var. Lütfen tüm ürünlerin kdv'sini seçin.");
        }
        private GidenInvoiceInfo CreateElectronicInvoice(Invoice invoice, Company currentCompany, InvoiceTypes invoiceScnearioType, InvoiceTipTypeEnum invoiceType)
        {
            var electronicInvoice = new GidenInvoiceType();
            var invoiceInfo = CreateInvoiceInformations(electronicInvoice, currentCompany, invoice, invoiceScnearioType, invoiceType);
            return invoiceInfo;
        }
        private GidenInvoiceInfo CreateInvoiceInformations(GidenInvoiceType electronicInvoice, Company company, Invoice invoice, InvoiceTypes invoiceScenarioType, InvoiceTipTypeEnum invoiceType)
        {
            electronicInvoice.ProfileID = new IdentificationId { Value = EnumUtilities.GetName(typeof(InvoiceTypes), (int)invoiceScenarioType) };
            electronicInvoice.CopyIndicator = new IndicatorType { Value = false };
            electronicInvoice.IssueDate = new DateType { Value = invoice.Date.ToString("yyyy.MM.dd") };//format bu şekilde olmalı. Diğer türlü olursa hata veriyor.
            electronicInvoice.IssueTime = new TimeType { Value = invoice.Date.ToShortTimeString() };
            electronicInvoice.InvoiceTypeCode = new Code { Value = EnumUtilities.GetName(typeof(InvoiceTipTypeEnum), (int)invoiceType) };
            electronicInvoice.Notlar = new List<Namee> { new Namee { Value = invoice.Comment ?? string.Empty } };
            electronicInvoice.DocumentCurrencyCode = new Code { Value = "TRY" };//USD EUR
            electronicInvoice.PricingCurrencyCode = new Code { Value = "TRY" };
            CreateElectronicInvoiceItems(electronicInvoice, invoice);
            electronicInvoice.LineCountNumeric = new NumericType { Value = electronicInvoice.FaturaSatirlari.Count };
            //SGK lar eksik
            electronicInvoice.UblVersionId = new NumericType { Value = Convert.ToDecimal(2.1) };
            electronicInvoice.CustomizationId = new IdentificationId { Value = "TR1.2" };

            CreateGondericiBilgileri(electronicInvoice, company);
            CreateAliciBilgileri(electronicInvoice, invoice.Customer);
            electronicInvoice.WithholdingTaxTotal = new List<TaxTotal> { };
            CreateMonetaryTotal(electronicInvoice, invoice);
            var invoiceInfo = new GidenInvoiceInfo();
            invoiceInfo.EFatura = electronicInvoice;
            invoiceInfo.EFaturaMiEArsivMi = InvoiceScenarioType.Automated;
            CreateEArchiveFaturaBilgileri(invoiceInfo);
            CreateFaturaGenelKDV(electronicInvoice, invoice);
            return invoiceInfo;
        }
        private void CreateElectronicInvoiceItems(GidenInvoiceType electronicInvoice, Invoice invoice)
        {
            var electronicInviceItems = new List<FaturaSatir>();
            int sira = 1;
            foreach (var invoiceItem in invoice.InvoiceItems)
            {
                var electronicInvoiceItem = new FaturaSatir();
                electronicInvoiceItem.Id = new IdentificationId { Value = sira.ToString() };
                electronicInvoiceItem.Item = new Item
                {
                    Name = new Namee { Value = invoiceItem.Stock.Name },
                    Description = new Namee { Value = "" },
                    ModelName = new Namee { Value = "" },
                };
                CreateSatirIndirim(electronicInvoiceItem);
                electronicInvoiceItem.Price = new Price { PriceAmount = new AmountType { Value = invoiceItem.Price, CurrencyID = "TRY" } };
                electronicInvoiceItem.Miktar = new InvoiceQuantity { UnitCode = "NIU", Value = Math.Round(invoiceItem.Quantity, 2) }; //NIU =Adet
                electronicInvoiceItem.SatirKdvSizToplam = new AmountType { Value = Math.Round(invoiceItem.Price * invoiceItem.Quantity, 2), CurrencyID = "TRY" };
                electronicInvoiceItem.Notlar = new List<Namee> { new Namee { Value = invoiceItem.Comment ?? string.Empty } };
                CreateItemTax(electronicInvoiceItem, invoiceItem);
                electronicInviceItems.Add(electronicInvoiceItem);
            }
            electronicInvoice.FaturaSatirlari = electronicInviceItems;
        }
        //public List<WebServices.UyumSoft.FaturaSatir> FaturaSatirlariAl()
        //{
        //    var efaturaSatirlari = new List<WebServices.UyumSoft.FaturaSatir>();
        //    int sira = 1;
        //    foreach (var faturaDetaySatir in _model.FaturaSatirlar)
        //    {
        //        var faturaSatir = new WebServices.UyumSoft.FaturaSatir();
        //        faturaSatir.Id = new IdentificationId { Value = sira + "" };
        //        faturaSatir.Item = new Item
        //        {
        //            Name = new Namee { Value = faturaDetaySatir.StokAd },
        //            Description = new Namee { Value = "" },
        //            ModelName = new Namee { Value = "" },
        //        };
        //        var satirIndirimi = new SatirIndirimi();
        //        satirIndirimi.amount = new AmountType { Value = faturaDetaySatir.IndirimToplamR, CurrencyID = "TRY" };
        //        //false ise indirim. true ise artırım olur.
        //        satirIndirimi.chargeIndicator = new IndicatorType { Value = false };
        //        //??? ne anlama geliyor.
        //        //
        //        //satirIndirimi.perUnitAmount = new AmountType { CurrencyID = "TRY", Value = faturaDetaySatir.BirimIndirimTutarR};
        //        //??? satıra iskonto yüzdesi nasıl eklenir.
        //        satirIndirimi.multiplierFactorNumeric = new NumericType { Value = faturaDetaySatir.IndirimOran };
        //        faturaSatir.SatirIndirimleri = new List<SatirIndirimi>();
        //        faturaSatir.SatirIndirimleri.Add(satirIndirimi);

        //        faturaSatir.Price = new Price { PriceAmount = new AmountType { Value = faturaDetaySatir.BirimFiyat, CurrencyID = "TRY" } };
        //        faturaSatir.Miktar = new InvoiceQuantity { UnitCode = "NIU", Value = Math.Round(faturaDetaySatir.Miktar, 2) }; //NIU =Adet
        //        faturaSatir.SatirKdvSizToplam = new AmountType { Value = Math.Round(faturaDetaySatir.AraToplam, 2), CurrencyID = "TRY" };
        //        faturaSatir.Notlar = new List<Namee> { new Namee { Value = faturaDetaySatir.Aciklama } };
        //        faturaSatir.TaxTotal = new TaxTotal();
        //        var taxSubTotal = new TaxSubTotal();
        //        taxSubTotal.Percent = new NumericType { Value = Convert.ToDecimal(faturaDetaySatir.Kdv) }; //Percent =   //new PercentType{ Value=Math.Round(Convert.ToDecimal(txtKdvOrani1.Text),2)},
        //        taxSubTotal.TaxCategory = new TaxCategory();
        //        taxSubTotal.TaxCategory.TaxScheme = new TaxScheme { TaxTypeCode = new Code { Value = "0015" }, TaxName = new Namee { Value = "KDV" } };
        //        taxSubTotal.TaxCategory.TaxExemptionReason = new Code { Value = faturaDetaySatir.VergiIstisnaAciklamasi };
        //        taxSubTotal.TaxCategory.TaxExemptionReasonCode = new Code { Value = faturaDetaySatir.VergiIstisnaKodu };
        //        taxSubTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(faturaDetaySatir.KdvToplam), 2), CurrencyID = "TRY" };
        //        faturaSatir.TaxTotal.TaxSubtotal = new List<TaxSubTotal>();
        //        faturaSatir.TaxTotal.TaxSubtotal.Add(taxSubTotal);

        //        faturaSatir.TaxTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(faturaDetaySatir.KdvToplam), 2), CurrencyID = "TRY" };
        //        efaturaSatirlari.Add(faturaSatir);
        //        sira++;
        //    }

        //    return efaturaSatirlari;
        //}
        private void CreateSatirIndirim(FaturaSatir electronickInvoiceItem)
        {
            var satirIndirimi = new SatirIndirimi();//todo: indirimler olacak mı sor
            satirIndirimi.amount = new AmountType { Value = 0, CurrencyID = "TRY" }; //indirim eklenecek mi
            satirIndirimi.chargeIndicator = new IndicatorType { Value = false };
            satirIndirimi.perUnitAmount = new AmountType { CurrencyID = "TRY", Value = 0 };
            satirIndirimi.multiplierFactorNumeric = new NumericType { Value = 0 };
            electronickInvoiceItem.SatirIndirimleri = new List<SatirIndirimi>();
            electronickInvoiceItem.SatirIndirimleri.Add(satirIndirimi);
        }
        private void CreateItemTax(FaturaSatir elecktronicInvoiceItem, InvoiceItem invoiceItem)
        {
            var toplamKdv = Math.Round(Convert.ToDecimal(invoiceItem.Price * invoiceItem.Quantity * invoiceItem.Tax / 100), 2);
            var taxSubTotal = new TaxSubTotal();
            taxSubTotal.Percent = new NumericType { Value = Convert.ToDecimal(invoiceItem.Tax) };
            taxSubTotal.TaxCategory = new TaxCategory();
            taxSubTotal.TaxCategory.TaxScheme = new TaxScheme { TaxTypeCode = new Code { Value = "0015" }, TaxName = new Namee { Value = "KDV" } };
            taxSubTotal.TaxAmount = new AmountType { Value = toplamKdv, CurrencyID = "TRY" };
            elecktronicInvoiceItem.TaxTotal.TaxSubtotal = new List<TaxSubTotal>();
            elecktronicInvoiceItem.TaxTotal.TaxSubtotal.Add(taxSubTotal);

            elecktronicInvoiceItem.TaxTotal.TaxAmount = new AmountType { Value = toplamKdv, CurrencyID = "TRY" };
        }

        private void CreateGondericiBilgileri(GidenInvoiceType electronicInvoice, Company currentCompany)
        {
            var gonderici = new AccountingSupplierParty();
            gonderici.Bilgiler = new PartyType();
            gonderici.Bilgiler.ResmiBilgileri = new List<PartyIdentification>();
            if (currentCompany.Type == (byte)EnumCompanyType.Corporate)
            {
                gonderici.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = currentCompany.Title } };
            }
            else if (currentCompany.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                gonderici.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = $"{currentCompany.FirstName} {currentCompany.LastName}" } };
            }
            CreateVergiNo(currentCompany, gonderici);
            if (currentCompany.Type == (byte)EnumCompanyType.Corporate)
                CreateFirmaTicariBilgileri(currentCompany, gonderici);
            if (currentCompany.Type == (byte)EnumCompanyType.Corporate || currentCompany.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                gonderici.Bilgiler.PartyTaxScheme = new PartyTaxScheme { TaxScheme = new TaxScheme { TaxName = new Namee { Value = currentCompany.TaxOffice } } };
            }
            CreateAddressBilgileri(currentCompany, gonderici);
            if (currentCompany.Type == (byte)EnumCompanyType.Person || currentCompany.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                gonderici.Bilgiler.person = new PersonType { firstName = new Namee { Value = currentCompany.FirstName }, familyName = new Namee { Value = currentCompany.LastName } };
            }
            electronicInvoice.Gonderici = gonderici;
        }
        private void CreateVergiNo(Company company, AccountingSupplierParty accountingSupplier)
        {
            var partyIdentificationVergi = new PartyIdentification();

            partyIdentificationVergi.id = new IdentificationId();
            if (company.Type == (byte)EnumCompanyType.Corporate)
            {
                partyIdentificationVergi.id.Value = company.VergiNo;
                partyIdentificationVergi.id.SchemeID = "VKN";
            }
            else if (company.Type == (byte)EnumCompanyType.Person || company.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                partyIdentificationVergi.id.Value = company.TcKimlikNo;
                partyIdentificationVergi.id.SchemeID = "TCKN";
            }
            accountingSupplier.Bilgiler.ResmiBilgileri.Add(partyIdentificationVergi);
        }
        private void CreateFirmaTicariBilgileri(Company company, AccountingSupplierParty accountingSupplier)
        {
            var partyIdentificationMersis = new PartyIdentification();
            var partyIdentificationTcaretSiciliNo = new PartyIdentification();
            if (!string.IsNullOrEmpty(company.CentralRegistrationNumber))
            {
                partyIdentificationMersis.id = new IdentificationId();
                partyIdentificationMersis.id.Value = company.CentralRegistrationNumber;
                partyIdentificationMersis.id.SchemeID = "MERSISNO";
                accountingSupplier.Bilgiler.ResmiBilgileri.Add(partyIdentificationMersis);
            }
            if (!string.IsNullOrEmpty(company.CommercialRegistrationNumber))
            {
                partyIdentificationTcaretSiciliNo.id = new IdentificationId();
                partyIdentificationTcaretSiciliNo.id.Value = company.CommercialRegistrationNumber;
                partyIdentificationTcaretSiciliNo.id.SchemeID = "TICARETSICILNO";
                accountingSupplier.Bilgiler.ResmiBilgileri.Add(partyIdentificationTcaretSiciliNo);
            }
        }
        private void CreateAddressBilgileri(Company company, AccountingSupplierParty accountingSupplier)
        {
            accountingSupplier.Bilgiler.Adres = new AddressType();
            accountingSupplier.Bilgiler.Adres.IlAdi = new Namee { Value = company.Province };
            accountingSupplier.Bilgiler.Adres.IlceAdi = new Namee { Value = company.District };
            accountingSupplier.Bilgiler.Adres.streetName = new Namee { Value = company.Adress };
            accountingSupplier.Bilgiler.Adres.country = new Country { name = new Namee { Value = company.Country } };
            accountingSupplier.Bilgiler.Adres.room = new Namee { Value = company.FlatNumber };
            accountingSupplier.Bilgiler.Adres.buildingNumber = new Namee { Value = company.ApartmentNumber };
            //gonderici.Bilgiler.Adres.PostaKodu = new Namee { Value = company.PostaKodu };//todo posta kodu ekle
        }
        private void CreateAliciBilgileri(GidenInvoiceType electronicInvoice, Company cari)
        {
            AccountingSupplierParty customer = new AccountingSupplierParty();
            customer.Bilgiler = new PartyType();
            customer.Bilgiler.ResmiBilgileri = new List<PartyIdentification>();

            if (cari.Type == (byte)EnumCompanyType.Corporate)
            {
                customer.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = cari.Title } };
            }
            else if (cari.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                customer.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = $"{cari.FirstName} {cari.LastName}" } };
            }
            CreateVergiNo(cari, customer);
            if (cari.Type == (byte)EnumCompanyType.Corporate)
                CreateFirmaTicariBilgileri(cari, customer);
            CreateCariIletisimBilgileri(cari, customer);
            CreateCariVergiDairesiBilgileri(cari, customer);
            CreateAddressBilgileri(cari, customer);
            if (cari.Type == (byte)EnumCompanyType.Person || cari.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                customer.Bilgiler.person = new PersonType { firstName = new Namee { Value = cari.FirstName }, familyName = new Namee { Value = cari.LastName } };
            }
            electronicInvoice.Alici = customer;
        }
        private void CreateCariIletisimBilgileri(Company cari, AccountingSupplierParty customer)
        {
            customer.Bilgiler.IletisimBilgileri = new Contact();
            customer.Bilgiler.IletisimBilgileri.Fax = new Namee();
            customer.Bilgiler.IletisimBilgileri.Fax.Value = cari.FaxNumber;
            customer.Bilgiler.IletisimBilgileri.Mail = new Namee();
            customer.Bilgiler.IletisimBilgileri.Mail.Value = cari.EMailAdress;
            customer.Bilgiler.IletisimBilgileri.Telefon = new Namee();
            customer.Bilgiler.IletisimBilgileri.Telefon.Value = cari.MobilePhone;
        }
        private void CreateCariVergiDairesiBilgileri(Company cari, AccountingSupplierParty customer)
        {
            customer.Bilgiler.PartyTaxScheme = new PartyTaxScheme();
            customer.Bilgiler.PartyTaxScheme.TaxScheme = new TaxScheme();
            if (cari.Type == (byte)EnumCompanyType.Corporate || cari.Type == (byte)EnumCompanyType.PrivateCompany)
            {
                customer.Bilgiler.PartyTaxScheme.TaxScheme.TaxName = new Namee { Value = cari.TaxOffice };
            }
            else if (cari.Type == (byte)EnumCompanyType.Person)
            {
                customer.Bilgiler.PartyTaxScheme.TaxScheme.TaxName = new Namee { Value = "" };
            }
        }

        private void CreateEArchiveFaturaBilgileri(GidenInvoiceInfo gidenInvoiceInfo)
        {
            EArchiveInvoiceInfo earchiveinfo = new EArchiveInvoiceInfo
            {
                deliveryType = true ? InvoiceDeliveryType.Electronic : InvoiceDeliveryType.Paper, //kağıt ortamda olduğunda Paper değeri set edilmelidir.
                                                                                                  //Eğer ilgili fatura bir internet satışına ait ise InternetSalesInfo nesnesinde gerekli değerler dolu olmalıdır. 
                                                                                                  //internetSalesInfo = new InternetSalesInformation
                                                                                                  //{
                                                                                                  //    paymentDate = DateTime.Now, //Ödeme Tarihi
                                                                                                  //    paymentMidierName = "Ödeme Aracısı", //Ödeme Şekli
                                                                                                  //    paymentType = "KREDIKARTI/BANKAKARTI", //Ödeme Şekli 

                //    //Gönderi Bilgileri
                //    shipmentInfo = new ShipmentInformation
                //    {
                //        //Taşıyıcı Firma Bilgileri
                //        carier = new ShipmentCarier
                //        {
                //            senderName = "Aras", //Taşıyıcı(Kargo) Şirketi Adı
                //            senderTcknVkn = "1234567890" //Taşıyıcı(Kargo) Şirketi VKN
                //        },
                //        sendDate = DateTime.Now,//dtpEArchiveSendDate.Value == new DateTime(2500, 1, 1) ? DateTime.MinValue : dtpEArchiveSendDate.Value, //Gönderim-Kargo Tarihi
                //    },
                //    webAddress = "www.asdf.com", //Satışın yapıldığı internet sitesi adresi 
                //},
            };
            gidenInvoiceInfo.EArchiveInvoiceInfo = earchiveinfo;
        }
        //public Dictionary<int, decimal> KdvMatraklarForEFatura => KdvMatrakHesaplaForEFatura();

        //private Dictionary<int, decimal> KdvMatrakHesaplaForEFatura(List<InvoiceItem> invoiceItems)
        //{
        //    var kdvMatraklar = invoiceItems.Where(i => i.Tax != 0).GroupBy(i => i.Tax)
        //           .Select(a => new KeyValuePair<int, decimal>(a.Key, a.Sum(i => i.TotalPriceWithTax-i.TotalPrice)))
        //           .ToDictionary(x => x.Key, x => x.Value);
        //    return kdvMatraklar;
        //    //if (!(AraToplamIndirim > 0))
        //    //    return kdvMatraklar;

        //    //İndirimi yüzde olarak alıyoruz
        //    //var satirBrutToplam = AraToplamIndirimOran == (int)OranEnum.Yuzde
        //    //    ? 0
        //    //    : FaturaSatirlar?.Sum(i => i.BrutToplam) ?? 0;

        //    //var indirimYuzde = AraToplamIndirimOran == (int)OranEnum.Yuzde
        //    //    ? AraToplamIndirim
        //    //    : ((AraToplamIndirim / satirBrutToplam) * 100);

        //    //return kdvMatraklar.ToDictionary(item => item.Key, item => item.Value * (1 - (indirimYuzde / 100)));
        //}
        private void CreateFaturaGenelKDV(GidenInvoiceType electronicInvoice, Invoice invoice)
        {
            var kdvMatraklar = invoice.InvoiceItems.Where(i => i.Tax != 0).GroupBy(i => i.Tax)
                   .Select(a => new KeyValuePair<int, decimal>(a.Key, a.Sum(i => i.TotalPriceWithTax - i.TotalPrice)))
                   .ToDictionary(x => x.Key, x => x.Value);

            electronicInvoice.TaxTotal = new List<TaxTotal>();
            foreach (var kdvMatragi in kdvMatraklar)
            {
                var TaxTotal = new TaxTotal();
                TaxTotal.TaxSubtotal = new List<TaxSubTotal>();
                var taxSubTotal = new TaxSubTotal();
                taxSubTotal.TaxCategory = new TaxCategory();
                taxSubTotal.TaxCategory.TaxScheme = new TaxScheme
                {
                    TaxTypeCode = new Code { Value = kdvMatragi.Key.ToString() },
                    TaxName = new Namee { Value = "KDV" }
                };
                taxSubTotal.Percent = new NumericType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Key), 2) };
                taxSubTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Value), 2), CurrencyID = "TRY" };
                TaxTotal.TaxSubtotal.Add(taxSubTotal);

                TaxTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Value), 2), CurrencyID = "TRY" };
                electronicInvoice.TaxTotal.Add(TaxTotal);
            }

        }
        private void CreateMonetaryTotal(GidenInvoiceType electronicInvoice, Invoice invoice)
        {
            decimal araToplam = invoice.InvoiceItems.Sum(i => i.Price);
            decimal genelToplam = invoice.InvoiceItems.Sum(i => i.PriceWithTax);
            electronicInvoice.LegalMonetaryTotal = new LegalMonetaryTotal
            {
                //indirim
                //allowanceTotalAmount = new AmountType { Value = Convert.ToDecimal(_model.AraToplamIndirimTutarF), CurrencyID = "TRY" },
                //hariç
                TaxExclusiveAmount = new AmountType { Value = araToplam, CurrencyID = "TRY" },
                //Dahil
                TaxInclusiveAmount = new AmountType { Value = genelToplam, CurrencyID = "TRY" },
                lineExtensionAmount = new AmountType { Value = araToplam, CurrencyID = "TRY" },
                chargeTotalAmount = new AmountType { Value = genelToplam, CurrencyID = "TRY" },
                payableAmount = new AmountType { Value = genelToplam, CurrencyID = "TRY" },
            };
        }
    }
}
