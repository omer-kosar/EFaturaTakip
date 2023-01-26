using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Business.Concrete;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Invoice;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
    [ServiceFilter(typeof(ValidationFilter))]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IInvoiceItemManager _invoiceItemManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoicesController(IInvoiceManager invoiceManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, IInvoiceItemManager invoiceItemManager)
        {
            _invoiceManager = invoiceManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _invoiceItemManager = invoiceItemManager;
        }

        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var companyId = GetCurrentUserCompanyId();
            var invoiceList = _invoiceManager.GetAllWithFilter(i => i.CompanyId == companyId);
            var invoiceDtoList = _mapper.Map<List<InvoiceListDto>>(invoiceList);
            return Ok(invoiceDtoList);
        }
        [HttpGet("GetInvoice/{invoiceId}")]
        public IActionResult GetInvoice(Guid invoiceId)
        {
            var companyId = GetCurrentUserCompanyId();
            var invoice = _invoiceManager.GetAllWithFilter(i => i.CompanyId == companyId && i.Id == invoiceId).FirstOrDefault();
            if (invoice is null) return NotFound("Fatura bulunamadı.");
            var invoiceItemDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceItemDto);
        }

        [HttpGet("GetInvoiceItems/{invoiceId}")]
        public IActionResult GetInvoiceItems(Guid invoiceId)
        {
            var invoiceItemList = _invoiceItemManager.GetAllWithFilter(i => i.InvoiceId == invoiceId);
            var invoiceItemDtoList = _mapper.Map<List<InvoiceItemListDto>>(invoiceItemList);
            return Ok(invoiceItemDtoList);
        }

        [HttpPost("CreateInvoice")]
        public IActionResult Post([FromBody] InvoiceDto invoice)
        {
            var newInvoice = _mapper.Map<Invoice>(invoice);
            newInvoice.CompanyId = GetCurrentUserCompanyId();
            _invoiceManager.Create(newInvoice);
            return Ok(newInvoice.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] InvoiceDto invoiceModel)
        {
            _invoiceManager.UpdateInvoiceWithItems(invoiceModel, id, GetCurrentUserCompanyId());
            return Ok("Fatura Güncellendi.");
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.TaxPayer })]
        [HttpDelete("delete/{invoiceId}")]
        public IActionResult Delete(Guid invoiceId)
        {
            var invoice = _invoiceManager.GetById(invoiceId);
            if (invoice == null) return BadRequest("Fatura bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _invoiceManager.Delete(invoice);
            return Ok("Fatura silindi.");
        }

        private Guid GetCurrentUserCompanyId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(c => c.Type.Equals("CompanyId")).Value);
        }


        //--------------------------------------------------------
        //private void GibeGonder()
        //{
        //    ThreadPool.QueueUserWorkItem(state =>
        //    {
        //        try
        //        {
        //            var _uyumSoftClient = UyumSoftClient.GetInstance();
        //            //var result = _uyumSoftClient.GetInboxInvoice("ea5d2581-40c0-4717-8e01-4bfaccc79051");
        //            //var efatura = result.Data.Value;
        //            var olusturulaEFatura = EFaturaOlustur();

        //            if (olusturulaEFatura == null)
        //            {
        //                return;
        //            }
        //            List<GidenInvoiceInfo> invoices = new List<GidenInvoiceInfo>();
        //            invoices.Add(olusturulaEFatura);

        //            var result = _uyumSoftClient.SendInvoice(invoices);
        //                if (result.Data.IsSucceded)
        //                {
        //                    var id = result.Data.Value[0].id + "";
        //                    var Number = result.Data.Value[0].number + "";
        //                    ShowInformation("Başarılı bir şekilde dönüştürüldü.");
        //                    try
        //                    {
        //                        var gibeGonderilenFatura = _faturaService.Get(i => i.Id == _model.FaturaId);
        //                        gibeGonderilenFatura.EFaturaId = id;
        //                        gibeGonderilenFatura.No = Number;
        //                        _faturaService.Edit(gibeGonderilenFatura);
        //                    }
        //                    catch (Exception err)
        //                    {
        //                        ShowError("Fatura EFaturaId ve No güncellenirken hata oluştu. Message: " + err.Message);
        //                    }
        //                    RequestPopupClose?.Invoke(null, EventArgs.Empty);
        //                    MessageBoxShow(resultt => { }, "EFatura başarılı bir şekilde oluşturuldu. FaturaId=" + id, "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
        //                }
        //                else
        //                {
        //                    ShowError("EFatura gönderilemedi. Message: " + result.Data.Message);
        //                }
        //        }
        //        catch (Exception e)
        //        {
        //                ShowWarning("E fatura oluşturulurken hata oluştu. Hata: " + e.Message);
        //        }
        //    });
        //}
        //public GidenInvoiceInfo EFaturaOlustur()
        //{
        //    #region Kontroller
        //    var CurrentFirm = _firmaService.Get(i => i.Id == UserTool.CompanyId); // Programı kull. firma bilg.
        //    #region CurrentFirma Kontrolleri


        //    if (string.IsNullOrEmpty(CurrentFirm.VergiDairesi))
        //    {
        //        DispatchService.InvokeOnUi(() =>
        //        {
        //            ShowWarning("Firmanızın vergi dairesi boş olamaz.");
        //        });
        //        return null;
        //    }
        //    if (CurrentFirm.FirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        if (string.IsNullOrEmpty(CurrentFirm.VergiNo))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Firmanızın vergi numarası boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (CurrentFirm.VergiNo.Length != 10)
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Firmanızın vergi numarası 10 haneli olamlı.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(CurrentFirm.FirmaAd))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Firmanızın resmi adı boş olamaz.");
        //            });
        //            return null;
        //        }
        //    }
        //    if (CurrentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        if (string.IsNullOrEmpty(CurrentFirm.TC))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Firmanızın TC numarası boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (CurrentFirm.TC.Length != 11)
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Firmanızın TC numarası 11 haneli olmalı.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(CurrentFirm.Ad))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Şahıs firmanızın adı boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(CurrentFirm.Soyad))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Şahıs firmanızın soyadı boş olamaz.");
        //            });
        //            return null;
        //        }
        //    }
        //    #endregion
        //    #region FaturaCarisiKontrolu
        //    var faturaCarisi = _cariService.GetCariForEFatura((Guid)_model.CariId);
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma || faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        if (string.IsNullOrEmpty(faturaCarisi.VergiDaire))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi vergi dairesi boş olamaz.");
        //            });
        //            return null;
        //        }
        //    }
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        if (string.IsNullOrEmpty(faturaCarisi.VergiNumara))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi vergi numarası boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (faturaCarisi.VergiNumara.Length != 10)
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi vergi numarası 10 haneli olamlı.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(faturaCarisi.FirmaResmiAdi))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi resmi adı boş olamaz.");
        //            });
        //            return null;
        //        }
        //    }
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi || faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisKisi)
        //    {

        //        if (string.IsNullOrEmpty(faturaCarisi.Tc))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi TC numarası boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (faturaCarisi.Tc.Length != 11)
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi TC numarası 11 haneli olmalı.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(faturaCarisi.Ad))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi adı boş olamaz.");
        //            });
        //            return null;
        //        }
        //        if (string.IsNullOrEmpty(faturaCarisi.Soyad))
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("Fatura carisi soyadı boş olamaz.");
        //            });
        //            return null;
        //        }
        //    }
        //    #endregion
        //    if (_model.FaturaSatirlar.Any(i => i.Kdv == 0))
        //    {
        //        DispatchService.InvokeOnUi(() =>
        //        {
        //            ShowWarning("Fatura kalemlerinde kdv seçilmemiş satırlar var. Lütfen tüm ürünlerin kdv'sini seçin");
        //        });
        //        return null;
        //    }

        //    #endregion

        //    var invoice = new GidenInvoiceType();
        //    #region Genel Fatura Bilgileri
        //    invoice.ProfileID = new IdentificationId { Value = EnumUtilities.GetName(typeof(InvoiceTypes), SelectedEFaturaTip1) };//
        //    invoice.CopyIndicator = new IndicatorType { Value = false };//
        //    invoice.IssueDate = new DateType { Value = _model.FaturaTarih.ToString("yyyy.MM.dd") };//format bu şekilde olmalı. Diğer türlü olursa hata veriyor.
        //    invoice.IssueTime = new TimeType { Value = _model.FaturaTarih.ToShortTimeString() };//
        //    invoice.InvoiceTypeCode = new Code { Value = EnumUtilities.GetName(typeof(InvoiceTipTypeEnum), SelectedEFaturaTip2) };//
        //    invoice.Notlar = new List<Namee> { new Namee { Value = _model.FaturaAciklama } };//
        //    invoice.DocumentCurrencyCode = new Code { Value = "TRY" };//USD EUR
        //    invoice.PricingCurrencyCode = new Code { Value = "TRY" };//
        //    #region Fatura Satırları - InvoiceLines
        //    invoice.FaturaSatirlari = FaturaSatirlariAl();//
        //    invoice.LineCountNumeric = new NumericType { Value = invoice.FaturaSatirlari.Count };//
        //    #endregion
        //    //SGK lar eksik
        //    invoice.UblVersionId = new NumericType { Value = Convert.ToDecimal(2.1) };//
        //    invoice.CustomizationId = new IdentificationId { Value = "TR1.2" };//

        //    #endregion

        //    invoice.Gonderici = GondericiBilgileriAl(CurrentFirm);
        //    invoice.Alici = AliciBilgileriAl(faturaCarisi);


        //    #region e-Arşiv Fatura Bilgileri
        //    //Bu alanda eğer fatura bir e-arşiv faturası ise doldurulması gerkene alanlar doldurulmalıdır.
        //    EArchiveInvoiceInfo earchiveinfo = new EArchiveInvoiceInfo
        //    {
        //        deliveryType = true ? InvoiceDeliveryType.Electronic : InvoiceDeliveryType.Paper, //kağıt ortamda olduğunda Paper değeri set edilmelidir.
        //                                                                                          //Eğer ilgili fatura bir internet satışına ait ise InternetSalesInfo nesnesinde gerekli değerler dolu olmalıdır. 
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
        //    };
        //    #endregion

        //    #region Vergi Alt Toplamları - TaxTotal
        //    //Fatura Genel KDV 
        //    invoice.TaxTotal = new List<TaxTotal>();
        //    foreach (var kdvMatragi in _model.KdvMatraklarForEFatura)
        //    {
        //        var TaxTotal = new TaxTotal();
        //        TaxTotal.TaxSubtotal = new List<TaxSubTotal>();
        //        var taxSubTotal = new TaxSubTotal();
        //        taxSubTotal.TaxCategory = new TaxCategory();
        //        taxSubTotal.TaxCategory.TaxScheme = new TaxScheme
        //        {
        //            TaxTypeCode = new Code { Value = "0015" },
        //            TaxName = new Namee { Value = "KDV" }
        //        };
        //        //taxSubTotal.TaxCategory.TaxExemptionReason = new TaxExemptionReasonType { Value="11/1-a Mal ihracatı" },
        //        //taxSubTotal.TaxCategory.TaxExemptionReasonCode= new TaxExemptionReasonCodeType { Value= "301" }
        //        taxSubTotal.Percent = new NumericType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Key), 2) };
        //        taxSubTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Value), 2), CurrencyID = "TRY" };
        //        TaxTotal.TaxSubtotal.Add(taxSubTotal);

        //        TaxTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(kdvMatragi.Value), 2), CurrencyID = "TRY" };
        //        invoice.TaxTotal.Add(TaxTotal);
        //    }

        //    #endregion
        //OrderLineReference = new OrderLineReferenceType[] { new OrderLineReferenceType { OrderReference = new OrderReferenceType { ID = new IDType { Value = "a" } } } }

        //    #region Tevkifatlar
        //    invoice.WithholdingTaxTotal = new List<TaxTotal> { };
        //    #endregion

        //    invoice.LegalMonetaryTotal = new LegalMonetaryTotal
        //    {
        //        //indirim
        //        allowanceTotalAmount = new AmountType { Value = Convert.ToDecimal(_model.AraToplamIndirimTutarF), CurrencyID = "TRY" },
        //        //hariç
        //        TaxExclusiveAmount = new AmountType { Value = Convert.ToDecimal(_model.AraToplamR), CurrencyID = "TRY" },
        //        //Dahil
        //        TaxInclusiveAmount = new AmountType { Value = Convert.ToDecimal(_model.GenelToplamR), CurrencyID = "TRY" },
        //        lineExtensionAmount = new AmountType { Value = Convert.ToDecimal(_model.AraToplamR), CurrencyID = "TRY" },
        //        chargeTotalAmount = new AmountType { Value = Convert.ToDecimal(_model.GenelToplamR), CurrencyID = "TRY" },
        //        payableAmount = new AmountType { Value = Convert.ToDecimal(_model.GenelToplamR), CurrencyID = "TRY" },
        //        //payableRoundingAmount = new AmountType { Value = Convert.ToDecimal(faturaDetay.GenelToplamR), CurrencyID = "TRY" }
        //    };
        //    var invoiceInfo = new GidenInvoiceInfo();
        //    invoiceInfo.EFatura = invoice;
        //    invoiceInfo.EFaturaMiEArsivMi = InvoiceScenarioType.Automated;
        //    invoiceInfo.EArchiveInvoiceInfo = earchiveinfo;
        //    return invoiceInfo;
        //}
        //private void PopupEFaturaOlustur()
        //{
        //    var preLoaderPopup = new PreLoaderPopup();
        //    ThreadPool.QueueUserWorkItem(state =>
        //    {
        //        try
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                preLoaderPopup.TxtTitle.Text = "Yükleniyor...";
        //                preLoaderPopup.Show();
        //            });
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                var popup = new Popup();
        //                popup.Loaded += (sender, args) =>
        //                {
        //                    preLoaderPopup.Close();
        //                };
        //                var eFaturayaDonusturView = new EFaturayaDonusturView();
        //                eFaturayaDonusturView.DataContext = this;

        //                if (eFaturayaDonusturView.DataContext is ICloseableForPopUp closeable)
        //                    closeable.RequestPopupClose += (x, y) =>
        //                    {
        //                        popup.Close();
        //                    };
        //                popup.FramePopUp.Navigate(eFaturayaDonusturView);
        //                popup.ShowDialog();
        //            });
        //        }
        //        catch (Exception e)
        //        {
        //            DispatchService.InvokeOnUi(() =>
        //            {
        //                ShowWarning("E fatura oluşturulurken hata oluştu. Hata: " + e.Message);
        //                preLoaderPopup.Close();
        //            });
        //        }
        //    });
        //}
        //public List<WebServices.UyumSoft.FaturaSatir> FaturaSatirlariAl()
        //{
        //    var efaturaSatirlari = new List<WebServices.UyumSoft.FaturaSatir>();
        //    int sira = 1;
        //    foreach (var faturaDetaySatir in _model.FaturaSatirlar)
        //    {
        //        var faturaSatir = new WebServices.UyumSoft.FaturaSatir();
        //        faturaSatir.Id = new IdentificationId { Value = sira + "k" };
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
        //        //Vergi 1 KDV
        //        var taxSubTotal = new TaxSubTotal();
        //        taxSubTotal.Percent = new NumericType { Value = Convert.ToDecimal(faturaDetaySatir.Kdv) }; //Percent =   //new PercentType{ Value=Math.Round(Convert.ToDecimal(txtKdvOrani1.Text),2)},
        //        taxSubTotal.TaxCategory = new TaxCategory();
        //        taxSubTotal.TaxCategory.TaxScheme = new TaxScheme { TaxTypeCode = new Code { Value = "0015" }, TaxName = new Namee { Value = "KDV" } };
        //        //TaxExemptionReason=new TaxExemptionReasonType{ Value="12345 sayılı kanuna istinaden" }
        //        taxSubTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(faturaDetaySatir.KdvToplam), 2), CurrencyID = "TRY" };
        //        faturaSatir.TaxTotal.TaxSubtotal = new List<TaxSubTotal>();
        //        faturaSatir.TaxTotal.TaxSubtotal.Add(taxSubTotal);

        //        faturaSatir.TaxTotal.TaxAmount = new AmountType { Value = Math.Round(Convert.ToDecimal(faturaDetaySatir.KdvToplam), 2), CurrencyID = "TRY" };
        //        efaturaSatirlari.Add(faturaSatir);
        //        sira++;
        //    }

        //    return efaturaSatirlari;
        //}
        //public AccountingSupplierParty GondericiBilgileriAl(Firma currentFirm)
        //{
        //    var Gonderici = new AccountingSupplierParty();
        //    Gonderici.Bilgiler = new PartyType();
        //    Gonderici.Bilgiler.ResmiBilgileri = new List<PartyIdentification>();
        //    if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        Gonderici.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = currentFirm.FirmaAd } };
        //    }
        //    else if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        Gonderici.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = currentFirm.KisaAd } };
        //    }
        //    var partyIdentificationVergi = new PartyIdentification();
        //    var partyIdentificationMersis = new PartyIdentification();
        //    var partyIdentificationTcaretSiciliNo = new PartyIdentification();

        //    partyIdentificationVergi.id = new IdentificationId();

        //    if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        partyIdentificationVergi.id.Value = currentFirm.VergiNo;
        //        partyIdentificationVergi.id.SchemeID = "VKN";
        //    }
        //    else if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisKisi || currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        partyIdentificationVergi.id.Value = currentFirm.TC;
        //        partyIdentificationVergi.id.SchemeID = "TCKN";
        //    }
        //    Gonderici.Bilgiler.ResmiBilgileri.Add(partyIdentificationVergi);

        //    if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        if (!string.IsNullOrEmpty(currentFirm.MersisNo))
        //        {
        //            partyIdentificationMersis.id = new IdentificationId();
        //            partyIdentificationMersis.id.Value = currentFirm.MersisNo;
        //            partyIdentificationMersis.id.SchemeID = "MERSISNO";
        //            Gonderici.Bilgiler.ResmiBilgileri.Add(partyIdentificationMersis);
        //        }
        //        if (!string.IsNullOrEmpty(currentFirm.TicaretSicilNo))
        //        {
        //            partyIdentificationTcaretSiciliNo.id = new IdentificationId();
        //            partyIdentificationTcaretSiciliNo.id.Value = currentFirm.TicaretSicilNo;
        //            partyIdentificationTcaretSiciliNo.id.SchemeID = "TICARETSICILNO";
        //            Gonderici.Bilgiler.ResmiBilgileri.Add(partyIdentificationTcaretSiciliNo);
        //        }
        //    }

        //    if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.Firma || currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        Gonderici.Bilgiler.PartyTaxScheme = new PartyTaxScheme { TaxScheme = new TaxScheme { TaxName = new Namee { Value = currentFirm.VergiDairesi } } };
        //    }
        //    Gonderici.Bilgiler.Adres = new AddressType();
        //    Gonderici.Bilgiler.Adres.IlAdi = new Namee { Value = currentFirm.Il };
        //    Gonderici.Bilgiler.Adres.IlceAdi = new Namee { Value = currentFirm.Ilce };
        //    Gonderici.Bilgiler.Adres.streetName = new Namee { Value = currentFirm.Adres };
        //    Gonderici.Bilgiler.Adres.country = new Country { name = new Namee { Value = currentFirm.Ulke } };
        //    Gonderici.Bilgiler.Adres.room = new Namee { Value = currentFirm.DaireNo };
        //    Gonderici.Bilgiler.Adres.buildingNumber = new Namee { Value = currentFirm.BinaNo };
        //    Gonderici.Bilgiler.Adres.PostaKodu = new Namee { Value = currentFirm.PostaKodu };
        //    if (currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisKisi || currentFirm.FirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        Gonderici.Bilgiler.person = new PersonType { firstName = new Namee { Value = currentFirm.Ad }, familyName = new Namee { Value = currentFirm.Soyad } };
        //    }
        //    return Gonderici;
        //}
        //public AccountingSupplierParty AliciBilgileriAl(CariDetailForEfaturaModel faturaCarisi)
        //{

        //    AccountingSupplierParty customer = new AccountingSupplierParty();
        //    customer.Bilgiler = new PartyType();
        //    customer.Bilgiler.ResmiBilgileri = new List<PartyIdentification>();

        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        customer.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = faturaCarisi.FirmaResmiAdi } };
        //    }
        //    else if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        customer.Bilgiler.FirmaAdi = new PartyName { Name = new Namee { Value = faturaCarisi.FirmaKisaAd } };
        //    }
        //    var partyIdentification = new PartyIdentification();
        //    partyIdentification.id = new IdentificationId();
        //    var partyIdentificationMersis = new PartyIdentification();
        //    var partyIdentificationTcaretSiciliNo = new PartyIdentification();
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        partyIdentification.id.Value = faturaCarisi.VergiNumara;
        //        partyIdentification.id.SchemeID = "VKN";
        //    }
        //    else if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisKisi || faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        partyIdentification.id.Value = faturaCarisi.Tc;
        //        partyIdentification.id.SchemeID = "TCKN";
        //    }
        //    customer.Bilgiler.ResmiBilgileri.Add(partyIdentification);
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma)
        //    {
        //        if (!string.IsNullOrEmpty(faturaCarisi.MersisNo))
        //        {
        //            partyIdentificationMersis.id = new IdentificationId();
        //            partyIdentificationMersis.id.Value = faturaCarisi.MersisNo;
        //            partyIdentificationMersis.id.SchemeID = "MERSISNO";
        //            customer.Bilgiler.ResmiBilgileri.Add(partyIdentificationMersis);
        //        }
        //        if (!string.IsNullOrEmpty(faturaCarisi.TicaretSicilNo))
        //        {
        //            partyIdentificationTcaretSiciliNo.id = new IdentificationId();
        //            partyIdentificationTcaretSiciliNo.id.Value = faturaCarisi.TicaretSicilNo;
        //            partyIdentificationTcaretSiciliNo.id.SchemeID = "TICARETSICILNO";
        //            customer.Bilgiler.ResmiBilgileri.Add(partyIdentificationTcaretSiciliNo);
        //        }
        //    }
        //    customer.Bilgiler.IletisimBilgileri = new Contact();
        //    customer.Bilgiler.IletisimBilgileri.Fax = new Namee();
        //    customer.Bilgiler.IletisimBilgileri.Fax.Value = faturaCarisi.CariFax;
        //    customer.Bilgiler.IletisimBilgileri.Mail = new Namee();
        //    customer.Bilgiler.IletisimBilgileri.Mail.Value = faturaCarisi.CariEMail;
        //    customer.Bilgiler.IletisimBilgileri.Telefon = new Namee();
        //    customer.Bilgiler.IletisimBilgileri.Telefon.Value = faturaCarisi.CariTelefon;

        //    customer.Bilgiler.PartyTaxScheme = new PartyTaxScheme();
        //    customer.Bilgiler.PartyTaxScheme.TaxScheme = new TaxScheme();
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.Firma || faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        customer.Bilgiler.PartyTaxScheme.TaxScheme.TaxName = new Namee { Value = faturaCarisi.VergiDaire };
        //    }
        //    else if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisKisi)
        //    {
        //        customer.Bilgiler.PartyTaxScheme.TaxScheme.TaxName = new Namee { Value = "" };
        //    }
        //    customer.Bilgiler.Adres = new AddressType();
        //    customer.Bilgiler.Adres.IlAdi = new Namee { Value = faturaCarisi.CariIl };
        //    customer.Bilgiler.Adres.IlceAdi = new Namee { Value = faturaCarisi.CariIlce };
        //    customer.Bilgiler.Adres.streetName = new Namee { Value = faturaCarisi.CariAcikAdres };
        //    customer.Bilgiler.Adres.country = new Country { name = new Namee { Value = faturaCarisi.CariUlke } };
        //    customer.Bilgiler.Adres.room = new Namee { Value = faturaCarisi.DaireNo };
        //    customer.Bilgiler.Adres.buildingNumber = new Namee { Value = faturaCarisi.BinaNo };
        //    customer.Bilgiler.Adres.PostaKodu = new Namee { Value = faturaCarisi.PostaKodu };
        //    if (faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisKisi || faturaCarisi.CariFirmaTur == (byte)CariFirmaTurEnum.SahisSirketi)
        //    {
        //        customer.Bilgiler.person = new PersonType { firstName = new Namee { Value = faturaCarisi.Ad }, familyName = new Namee { Value = faturaCarisi.Soyad } };
        //    }
        //    return customer;
        //}
    }
}
