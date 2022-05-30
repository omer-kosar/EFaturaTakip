using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EFaturaTakip.Common.Enums
{
    public enum EnvelopeStatus
    {
        [Description("Zarf Yok")]
        NoEnvelope,
        [Description("Zarf Hazırlanıyor")]
        Preparing,
        [Description("Zarf Kuyrukta")]
        EnvelopIsQueued,
        [Description("Zarf İşleniyor")]
        EnvelopIsProcessing,
        [Description("Zarf Dosyası Zip Değil")]
        FileIsNotZip,
        [Description("Geçersiz Zarf Id Uzunluğu")]
        InvalidEnvelopIdLength,
        [Description("Zarf Arşive Kopyalanamadı")]
        EnvelopCouldNotCopiedFromArchive,
        [Description("Zip Olarak Açma")]
        CouldNotOpenZip,
        [Description("Zarf Zipinde Zarf Verisi Mevcut Değil")]
        ZipIsEmpty,
        [Description("Zarf Dosyası Xml Değil")]
        FileIsNotXml,
        [Description("Zarf ve Xml Aynı İsimde Olmalıdır")]
        EnvelopeIdAndXmlNameMustBeSame,
        [Description("Doküman Parse Edilemiyor")]
        CouldNotParseDocument,
        [Description("Zarf Bulunamadı")]
        EnvelopeIdNotFound,
        [Description("Zarf Adı ve Zip Dosyası Adı Aynı Olmak Zorunda")]
        EnvelopeIdAndZipNameMustBeSame,
        [Description("Geçersiz Versiyon")]
        InvalidVersion,
        [Description("Şematron Kontrolü Geçemedi")]
        SchematronCheckFailed,
        [Description("Xml Şematron Kontrolünü Geçemedi")]
        XmlSchemaCheckFailed,
        [Description("İmza TcknVkn Bilgisi Alınamadı")]
        CouldNotTakeTcknVknForSigner,
        [Description("İmza Kaydedilemiyor")]
        CouldNotSaveSigniture,
        [Description("Zarf Adı Daha Önce Kullanılmış")]
        EnvelopeIdIsAlreadyUsed,
        [Description("İmza Atanın İmza İzni Yok")]
        EnvelopeContainsIdIsAlreadyUsed,
        [Description("Göderim İzni Yok")]
        CouldNotCheckPermission,
        [Description("Posta Kutusunda İşlem Yapma Yetkisi Yok")]
        DoesNotHaveSenderUnitPermission,
        [Description("İmza Yetkisi Doğrulanamadı")]
        DoesNotHavePostBoxPermission,
        [Description("")]
        CouldNotCheckSignPermission,
        [Description("İmzalama Yetkisi Bulunmayan Kullanıcı")]
        SignerHasNoPermission,
        [Description("")]
        IllegalSign,
        [Description("")]
        CouldNotCheckAddress,
        [Description("")]
        AddressNotFound,
        [Description("")]
        DoesNotHaveEntegratorApplication,
        [Description("")]
        CouldNotPrepareSystemResponse,
        [Description("")]
        SystemError,
        [Description("")]
        EnvelopedProcessSuccessfully,
        [Description("")]
        CouldNotSendDocumentToTheAddress,
        [Description("")]
        DocumentSendingFailedWillNotRetry,
        [Description("")]
        TargetDoesNotSendSystemResponse,
        [Description("")]
        TargetSendFailedSystemResponse,
        [Description("")]
        InvoiceLinkedToCancel,
        [Description("")]
        CompletedSuccessfully,
    }
}
