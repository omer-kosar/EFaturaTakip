using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.UyumSoft.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.UyumSoft.Model
{
    public class GidenEFaturaModel : GidenResponse
    {
        public InvoiceData Data { get; set; }
    }
    public class InvoiceData : BaseData
    {

        [JsonProperty("InvoiceInfo")]
        public GidenInvoiceInfo Value { get; set; }
    }
    public class GidenInvoiceInfo
    {
        [JsonProperty("invoice")]
        public GidenInvoiceType EFatura { get; set; }
        public string LocalDocumentId { get; set; }
        //public CustomerInfo TargetCustomer { get; set; }
        //public string ExtraInformation { get; set; }
        public EArchiveInvoiceInfo EArchiveInvoiceInfo { get; set; }
        [JsonProperty("Scenario")]
        public InvoiceScenarioType EFaturaMiEArsivMi { get; set; }
        public NotificationInformation notification { get; set; }
    }
    public class NotificationInformation
    {
        public List<MailingInformation> mailing { get; set; }
        public List<SmsMessageInformation> messaging { get; set; }
    }
    public class MailingInformation
    {
        public string subject { get; set; }
        public MailAttachmentInformation attachment { get; set; }
        public bool enableNotification { get; set; }
        public string to { get; set; }
        public string bodyXsltIdentifier { get; set; }
        public string emailAccountIdentifier { get; set; }
    }
    public class MailAttachmentInformation
    {
        public string xml { get; set; }
        public string pdf { get; set; }
        public string html { get; set; }
    }
    public class SmsMessageInformation
    {
        public string to { get; set; }
        public string bodyXsltIdentifier { get; set; }
    }
    public class EArchiveInvoiceInfo
    {
        public InternetSalesInformation internetSalesInfo { get; set; }
        public List<EArchiveWithHoldingInformation> withHoldings { get; set; }
        public InvoiceDeliveryType deliveryType { get; set; }

    }
    public class EArchiveWithHoldingInformation
    {
        public string code { get; set; }
        public string rate { get; set; }
        public string total { get; set; }
    }
    public class InternetSalesInformation
    {
        public string webAddress { get; set; }
        public string paymentMidierName { get; set; }
        public string paymentType { get; set; }
        public DateTime paymentDate { get; set; }
        public ShipmentInformation shipmentInfo { get; set; }
    }
    public class ShipmentInformation
    {
        public ShipmentCarier carier { get; set; }
        public DateTime sendDate { get; set; }
    }
    public class ShipmentCarier
    {
        public string senderTcknVkn { get; set; }
        public string senderName { get; set; }
    }

    public class GidenInvoiceType
    {
        [JsonProperty("UblVersionId")]
        public NumericType UblVersionId { get; set; }


        [JsonProperty("CustomizationId")]
        public IdentificationId CustomizationId { get; set; }

        [JsonProperty("ProfileId")]
        public IdentificationId ProfileID { get; set; }
        //[JsonProperty("Id")]
        //public IdentificationId EFaturaNo { get; set; }
        //Kopya Göstergesi
        [JsonProperty("CopyIndicator")]
        public IndicatorType CopyIndicator { get; set; }
        [JsonProperty("uUID")]
        public IdentificationId EFaturaId { get; set; }
        [JsonProperty("issueDate")]
        public DateType IssueDate { get; set; }
        [JsonProperty("issueTime")]
        public TimeType IssueTime { get; set; }
        [JsonProperty("InvoiceTypeCode")]
        public Code InvoiceTypeCode { get; set; }
        [JsonProperty("note")]
        public List<Namee> Notlar { get; set; }
        [JsonProperty("documentCurrencyCode")]
        public Code DocumentCurrencyCode { get; set; }
        [JsonProperty("pricingCurrencyCode")]
        public Code PricingCurrencyCode { get; set; }
        [JsonProperty("lineCountNumeric")]
        public NumericType LineCountNumeric { get; set; }

        [JsonProperty("accountingSupplierParty")]
        public AccountingSupplierParty Gonderici { get; set; }
        [JsonProperty("accountingCustomerParty")]
        public AccountingSupplierParty Alici { get; set; }
        [JsonProperty("invoiceLine")]
        public List<FaturaSatir> FaturaSatirlari { get; set; }
        public List<TaxTotal> TaxTotal { get; set; }
        public List<TaxTotal> WithholdingTaxTotal { get; set; }
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }


    }



    #region AccountingSupplierParty  and AccountingCustomerParty

    public class AccountingSupplierParty
    {
        [JsonProperty("Party")]
        public PartyType Bilgiler { get; set; }
    }
    public class PartyIdentification
    {
        public IdentificationId id { get; set; }
    }
    public class PartyName
    {
        public Namee Name { get; set; }
    }
    public class Country
    {
        public Code identificationCode { get; set; }
        public Namee name { get; set; }
    }
    public class AddressType
    {
        public IdentificationId id { get; set; }
        public Namee postbox { get; set; }
        public Namee room { get; set; }
        public Namee streetName { get; set; }
        public Namee blockName { get; set; }
        public Namee buildingName { get; set; }
        public Namee buildingNumber { get; set; }
        [JsonProperty("citySubdivisionName")]
        public Namee IlceAdi { get; set; }
        [JsonProperty("cityName")]
        public Namee IlAdi { get; set; }
        [JsonProperty("postalZone")]
        public Namee PostaKodu { get; set; }
        public Namee region { get; set; }
        public Namee district { get; set; }
        public Country country { get; set; }
    }
    #region İletişim Bilgileri
    public class Contact
    {
        public IdentificationId id { get; set; }
        public Namee name { get; set; }
        [JsonProperty("telephone")]
        public Namee Telefon { get; set; }
        [JsonProperty("telefax")]
        public Namee Fax { get; set; }
        [JsonProperty("electronicMail")]
        public Namee Mail { get; set; }
        public Namee note { get; set; }

        //public CommunicationType[] otherCommunication;
    }
    #endregion
    //public class TaxScheme
    //{
    //    public IdentificationId id { get; set; }
    //    public Namee name{ get; set; }
    //    public Code taxTypeCode { get; set; }
    //}
    public class PartyTaxScheme
    {
        public Namee registrationName { get; set; }
        public IdentificationId companyID { get; set; }
        public TaxScheme TaxScheme { get; set; }
    }
    public class PartyType
    {
        public IdentificationId websiteURI { get; set; }
        public IdentificationId endpointID { get; set; }
        public Code industryClassificationCode { get; set; }
        [JsonProperty("PartyIdentification")]
        public List<PartyIdentification> ResmiBilgileri { get; set; }
        [JsonProperty("PartyName")]
        public PartyName FirmaAdi { get; set; }
        [JsonProperty("PostalAddress")]
        public AddressType Adres { get; set; }
        public LocationType1 physicalLocation { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public List<PartyLegalEntityType> partyLegalEntity { get; set; }
        [JsonProperty("Contact")]
        public Contact IletisimBilgileri { get; set; }
        public PersonType person { get; set; }
        public PartyType agentParty { get; set; }
    }
    public partial class PersonType
    {
        public Namee firstName { get; set; }
        public Namee familyName { get; set; }
        public Namee title { get; set; }
        public Namee middleName { get; set; }
        public Namee nameSuffix { get; set; }
        public IdentificationId nationalityID { get; set; }
        public FinancialAccountType financialAccount { get; set; }
        public DocumentReferenceType identityDocumentReference { get; set; }
    }
    public class DocumentReferenceType
    {
        public IdentificationId id { get; set; }
        public DateType issueDate { get; set; }
        public Code documentTypeCode { get; set; }
        public Namee documentType { get; set; }
        public List<Namee> documentDescription { get; set; }
        public AttachmentType attachment { get; set; }
        public PeriodType validityPeriod { get; set; }
        public PartyType issuerParty { get; set; }
    }
    public partial class AttachmentType
    {
        public BinaryObjectType embeddedDocumentBinaryObject { get; set; }
        public ExternalReferenceType externalReference { get; set; }
    }
    public class ExternalReferenceType
    {
        public IdentificationId uRI { get; set; }
    }
    public class BinaryObjectType
    {
        public string format { get; set; }
        public string mimeCode { get; set; }
        public string encodingCode { get; set; }
        public string characterSetCode { get; set; }
        public string uri { get; set; }
        public string filename { get; set; }
        public byte[] value { get; set; }
    }
    public class FinancialAccountType
    {
        public IdentificationId id { get; set; }
        public Code currencyCode { get; set; }
        public Namee paymentNote { get; set; }
        public BranchType financialInstitutionBranch { get; set; }
    }
    public class BranchType
    {
        public Namee name { get; set; }
        public FinancialInstitutionType financialInstitution { get; set; }
    }
    public partial class FinancialInstitutionType
    {
        public Namee name { get; set; }
    }
    public class PartyLegalEntityType
    {
        public Namee registrationName { get; set; }
        public IdentificationId companyID { get; set; }
        public DateType registrationDate { get; set; }
        public IndicatorType soleProprietorshipIndicator { get; set; }
        public AmountType corporateStockAmount { get; set; }
        public IndicatorType fullyPaidSharesIndicator { get; set; }
        public CorporateRegistrationSchemeType corporateRegistrationScheme { get; set; }
        public PartyType headOfficeParty { get; set; }
    }
    public class CorporateRegistrationSchemeType
    {
        public IdentificationId id { get; set; }
        public Namee name { get; set; }
        public Code corporateRegistrationTypeCode { get; set; }
        public List<AddressType> jurisdictionRegionAddress { get; set; }
    }
    public class IndicatorType
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }
    public class LocationType1
    {
        public IdentificationId id { get; set; }
        public AddressType address { get; set; }
    }

    #endregion
    public class CustomerInfo
    {
        public string VknTckn { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
    }

    public class FaturaSatir
    {
        [JsonProperty("id")]
        public IdentificationId Id { get; set; }
        [JsonProperty("note")]
        public List<Namee> Notlar { get; set; }
        [JsonProperty("invoicedQuantity")]
        public InvoiceQuantity Miktar { get; set; }
        [JsonProperty("lineExtensionAmount")]
        public AmountType SatirKdvSizToplam { get; set; }
        [JsonProperty("TaxTotal")]
        public TaxTotal TaxTotal { get; set; } = new TaxTotal();
        [JsonProperty("item")]
        public Item Item { get; set; }
        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("AllowanceCharge")]
        public List<SatirIndirimi> SatirIndirimleri { get; set; }

    }
    public partial class SatirIndirimi
    {
        public IndicatorType chargeIndicator { get; set; }
        public Namee allowanceChargeReason { get; set; }
        public NumericType multiplierFactorNumeric { get; set; }
        public NumericType sequenceNumeric { get; set; }
        public AmountType amount { get; set; }
        public AmountType baseAmount { get; set; }
        public AmountType perUnitAmount { get; set; }
    }

    public class LegalMonetaryTotal
    {
        public AmountType lineExtensionAmount { get; set; }
        public AmountType TaxExclusiveAmount { get; set; }
        public AmountType TaxInclusiveAmount { get; set; }
        //indirim
        public AmountType allowanceTotalAmount { get; set; }
        public AmountType chargeTotalAmount { get; set; }
        public AmountType payableRoundingAmount { get; set; }
        public AmountType payableAmount { get; set; }
    }
    public class InvoiceQuantity
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("unitCode")]
        public string UnitCode { get; set; }
    }
    public class TaxTotal
    {
        [JsonProperty("taxAmount")]
        public AmountType TaxAmount { get; set; }
        [JsonProperty("taxSubtotal")]
        public List<TaxSubTotal> TaxSubtotal { get; set; }
    }

    public class TaxSubTotal
    {
        [JsonProperty("taxableAmount")]
        public AmountType TaxableAmount { get; set; }
        [JsonProperty("taxAmount")]
        public AmountType TaxAmount { get; set; }
        [JsonProperty("calculationSequenceNumeric")]
        public NumericType CalculationSequence { get; set; }
        [JsonProperty("transactionCurrencyTaxAmount")]
        public AmountType TransactionCurrencyTaxAmount { get; set; }
        [JsonProperty("percent")]
        public NumericType Percent { get; set; }
        [JsonProperty("baseUnitMeasure")]
        public string BaseUnitMeasure { get; set; }
        [JsonProperty("perUnitAmount")]
        public AmountType PerUnitAmount { get; set; }
        [JsonProperty("taxCategory")]
        public TaxCategory TaxCategory { get; set; }
    }
    public class AmountType
    {
        [JsonProperty("currencyID")]
        public string CurrencyID { get; set; }
        [JsonProperty("currencyCodeListVersionID")]
        public string CurrencyCodeListVersionID { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public class NumericType
    {
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
    #region Tax Alani
    public class TaxCategory
    {
        [JsonProperty("Name")]
        public Namee Name { get; set; }
        [JsonProperty("taxExemptionReasonCode")]
        public Code TaxExemptionReasonCode { get; set; }
        [JsonProperty("taxExemptionReason")]
        public Code TaxExemptionReason { get; set; }
        [JsonProperty("taxScheme")]
        public TaxScheme TaxScheme { get; set; }
    }
    public class TaxScheme
    {
        [JsonProperty("id")]
        public IdentificationId Id { get; set; }
        [JsonProperty("Name")]
        public Namee TaxName { get; set; }
        [JsonProperty("taxTypeCode")]
        public Code TaxTypeCode { get; set; }
    }
    #endregion
    public class Item
    {
        [JsonProperty("description")]
        public Namee Description { get; set; }
        [JsonProperty("Name")]
        public Namee Name { get; set; }
        [JsonProperty("keyword")]
        public Namee Keyword { get; set; }
        [JsonProperty("brandName")]
        public Namee BrandName { get; set; }
        [JsonProperty("modelName")]
        public Namee ModelName { get; set; }
        [JsonProperty("buyersItemIdentification")]
        public Identification BuyersItemIdentification { get; set; }
        [JsonProperty("sellersItemIdentification")]
        public Identification SellersItemIdentification { get; set; }
        [JsonProperty("manufacturersItemIdentification")]
        public Identification ManufacturersItemIdentification { get; set; }
        [JsonProperty("additionalItemIdentification")]
        public List<Identification> AdditionalItemIdentification { get; set; }
        [JsonProperty("originCountry")]
        public Country OriginCountry { get; set; }
        [JsonProperty("commodityClassification")]
        public List<Code> CommodityClassification { get; set; }
        [JsonProperty("itemInstance")]
        public List<ItemInstanceType> ItemInstance { get; set; }
    }
    public class ItemInstanceType
    {
        public IdentificationId productTraceID { get; set; }
        public DateType manufactureDate { get; set; }
        public DateType manufactureTime { get; set; }
        public DateType bestBeforeDate { get; set; }
        public IdentificationId registrationID { get; set; }
        public IdentificationId serialID { get; set; }
        public List<ItemPropertyType> additionalItemProperty { get; set; }
        public LotIdentificationType lotIdentification { get; set; }
    }
    public class LotIdentificationType
    {
        public IdentificationId lotNumberID { get; set; }
        public DateType expiryDate { get; set; }
        public List<ItemPropertyType> additionalItemProperty { get; set; }
    }
    public class ItemPropertyType
    {
        public IdentificationId id { get; set; }
        public Namee name { get; set; }
        public Code nameCode { get; set; }
        public Namee testMethod { get; set; }
        public Namee value { get; set; }
        public QuantityType valueQuantity { get; set; }
        public List<Namee> valueQualifier { get; set; }
        public Code importanceCode { get; set; }
        public List<Namee> listValue { get; set; }
        public PeriodType usabilityPeriod { get; set; }
        public List<ItemPropertyGroupType> itemPropertyGroup { get; set; }
        public DimensionType rangeDimension { get; set; }
        public ItemPropertyRangeType itemPropertyRange { get; set; }
    }
    public class ItemPropertyRangeType
    {
        public Namee minimumValue { get; set; }
        public Namee maximumValue { get; set; }
    }
    public class DimensionType
    {
        public IdentificationId attributeID { get; set; }
        public MeasureType measure { get; set; }
        public List<Namee> description { get; set; }
        public MeasureType minimumMeasure { get; set; }
        public MeasureType maximumMeasure { get; set; }
    }
    public class ItemPropertyGroupType
    {
        public IdentificationId id { get; set; }
        public Namee name { get; set; }
        public Code importanceCode { get; set; }
    }
    public class PeriodType
    {
        public DateType startDate { get; set; }
        public DateType startTime { get; set; }
        public DateType endDate { get; set; }
        public DateType endTime { get; set; }
        public MeasureType durationMeasure { get; set; }
        public Namee description { get; set; }
    }
    public class MeasureType
    {
        public string unitCode { get; set; }
        public string unitCodeListVersionID { get; set; }
        public decimal value { get; set; }
    }
    public partial class QuantityType
    {
        public string unitCode { get; set; }
        public string unitCodeListID { get; set; }
        public string unitCodeListAgencyID { get; set; }
        public string unitCodeListAgencyName { get; set; }
        public decimal value { get; set; }
    }
    public class DateType
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class TimeType
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class Price
    {
        [JsonProperty("priceAmount")]
        public AmountType PriceAmount { get; set; }
    }
    public class Code
    {
        public string listID { get; set; }
        public string listAgencyID { get; set; }
        public string listAgencyName { get; set; }
        public string listName { get; set; }
        public string listVersionID { get; set; }
        public string name { get; set; }
        public string languageID { get; set; }
        public string listURI { get; set; }
        public string listSchemeURI { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class Identification
    {
        [JsonProperty("id")]
        public IdentificationId Id { get; set; }
    }
    public class Namee
    {
        public string languageID { get; set; }
        public string languageLocaleID { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class IdentificationId
    {
        [JsonProperty("schemeID")]
        public string SchemeID { get; set; }
        [JsonProperty("schemeName")]
        public string SchemeName { get; set; }
        [JsonProperty("schemeAgencyID")]
        public string SchemeAgencyID { get; set; }
        [JsonProperty("schemeAgencyName")]
        public string SchemeAgencyName { get; set; }
        [JsonProperty("schemeVersionID")]
        public string SchemeVersionID { get; set; }
        [JsonProperty("schemeDataURI")]
        public string SchemeDataURI { get; set; }
        [JsonProperty("schemeURI")]
        public string SchemeURI { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}