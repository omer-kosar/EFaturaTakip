using EFaturaTakip.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class InvoiceResponse : BaseResponse
    {
        public InvoiceData Data { get; set; }
    }
    public class InvoiceData : BaseData
    {
        public InvoiceInfo Value { get; set; }
    }
    public class InvoiceInfo
    {
        [JsonProperty("Invoice")]
        public InvoiceType EFatura { get; set; }
        public string LocalDocumentId { get; set; }

        public CustomerInfo TargetCustomer { get; set; }
        public string ExtraInformation { get; set; }
        public EArchiveInvoiceInfo EArchiveInvoiceInfo { get; set; }
        [JsonProperty("Scenario")]
        public InvoiceScenarioType EFaturaMiEArsivMi { get; set; }
        public NotificationInformation notificationField { get; set; }
        public DateTime CreateDateUtc { get; set; }
    }
    public class NotificationInformation
    {
        public List<MailingInformation> mailingField { get; set; }
        public List<SmsMessageInformation> messagingField { get; set; }
    }
    public class MailingInformation
    {
        public string subjectField { get; set; }
        public MailAttachmentInformation attachmentField { get; set; }
        public bool enableNotificationField { get; set; }
        public string toField { get; set; }
        public string bodyXsltIdentifierField { get; set; }
        public string emailAccountIdentifierField { get; set; }
    }
    public class MailAttachmentInformation
    {
        public string xmlField { get; set; }
        public string pdfField { get; set; }
        public string htmlField { get; set; }
    }
    public class SmsMessageInformation
    {
        public string toField { get; set; }
        public string bodyXsltIdentifierField { get; set; }
    }
    public class EArchiveInvoiceInfo
    {
        public InternetSalesInformation internetSalesInfoField { get; set; }
        public List<EArchiveWithHoldingInformation> withHoldingsField { get; set; }
        public InvoiceDeliveryType deliveryTypeField { get; set; }

    }
    public class EArchiveWithHoldingInformation
    {
        public string codeField { get; set; }
        public string rateField { get; set; }
        public string totalField { get; set; }
    }
    public class InternetSalesInformation
    {
        public string webAddressField { get; set; }
        public string paymentMidierNameField { get; set; }
        public string paymentTypeField { get; set; }
        public DateTime paymentDateField { get; set; }
        public ShipmentInformation shipmentInfoField { get; set; }
    }
    public class ShipmentInformation
    {
        public ShipmentCarier carierField { get; set; }
        public DateTime sendDateField { get; set; }
    }
    public class ShipmentCarier
    {
        public string senderTcknVknField { get; set; }
        public string senderNameField { get; set; }
    }

    public class InvoiceType
    {
        [JsonProperty("idField")]
        public IdentificationId EFaturaNo { get; set; }
        [JsonProperty("uUIDField")]
        public IdentificationId EFaturaId { get; set; }
        public Code invoiceTypeCodeField { get; set; }
        [JsonProperty("accountingSupplierPartyField")]
        public AccountingSupplierPartyField Gonderici { get; set; }
        [JsonProperty("accountingCustomerPartyField")]
        public AccountingSupplierPartyField Alici { get; set; }
        [JsonProperty("noteField")]
        public List<NameField> Notlar { get; set; }
        [JsonProperty("invoiceLineField")]
        public List<InvoiceLine> FaturaSatirlari { get; set; }
    }
    #region AccountingSupplierPartyField  and AccountingCustomerPartyField

    public class AccountingSupplierPartyField
    {
        [JsonProperty("partyField")]
        public PartyType Bilgiler { get; set; }
    }
    public class PartyIdentificationField
    {
        public IdentificationId idField { get; set; }
    }
    public class PartyNameField
    {
        public NameField NameField { get; set; }
    }
    public class CountryField
    {
        public Code identificationCodeField { get; set; }
        public NameField nameField { get; set; }
    }
    public class AddressType
    {
        public IdentificationId idField { get; set; }
        public NameField postboxField { get; set; }
        public NameField roomField { get; set; }
        public NameField streetNameField { get; set; }
        public NameField blockNameField { get; set; }
        public NameField buildingNameField { get; set; }
        public NameField buildingNumberField { get; set; }
        public NameField citySubdivisionNameField { get; set; }
        public NameField cityNameField { get; set; }
        public NameField postalZoneField { get; set; }
        public NameField regionField { get; set; }
        public NameField districtField { get; set; }
        public CountryField countryField { get; set; }
    }
    #region İletişim Bilgileri
    public class ContactField
    {
        public IdentificationId idField { get; set; }
        public NameField nameField { get; set; }
        [JsonProperty("telephoneField")]
        public NameField Telefon { get; set; }
        [JsonProperty("telefaxField")]
        public NameField Fax { get; set; }
        [JsonProperty("electronicMailField")]
        public NameField Mail { get; set; }
        public NameField noteField { get; set; }

        //public CommunicationType[] otherCommunicationField;
    }
    #endregion
    public class TaxSchemeField
    {
        public IdentificationId idField { get; set; }
        public NameField nameField { get; set; }
        public Code taxTypeCodeField { get; set; }
    }
    public class PartyTaxSchemeField
    {
        public NameField registrationNameField { get; set; }
        public IdentificationId companyIDField { get; set; }
        public TaxSchemeField taxSchemeField { get; set; }
    }
    public class PartyType
    {
        public IdentificationId websiteURIField { get; set; }
        public IdentificationId endpointIDField { get; set; }
        public Code industryClassificationCodeField { get; set; }
        public List<PartyIdentificationField> partyIdentificationField { get; set; }
        [JsonProperty("partyNameField")]
        public PartyNameField partyNameField { get; set; }
        [JsonProperty("postalAddressField")]
        public AddressType Adres { get; set; }
        public LocationType1 physicalLocationField { get; set; }
        public PartyTaxSchemeField partyTaxSchemeField { get; set; }
        public List<PartyLegalEntityType> partyLegalEntityField { get; set; }
        [JsonProperty("contactField")]
        public ContactField IletisimBilgileri { get; set; }
        public PersonType personField { get; set; }
        public PartyType agentPartyField { get; set; }
    }
    public partial class PersonType
    {
        public NameField firstNameField { get; set; }
        public NameField familyNameField { get; set; }
        public NameField titleField { get; set; }
        public NameField middleNameField { get; set; }
        public NameField nameSuffixField { get; set; }
        public IdentificationId nationalityIDField { get; set; }
        public FinancialAccountType financialAccountField { get; set; }
        public DocumentReferenceType identityDocumentReferenceField { get; set; }
    }
    public class DocumentReferenceType
    {
        public IdentificationId idField { get; set; }
        public DateType issueDateField { get; set; }
        public Code documentTypeCodeField { get; set; }
        public NameField documentTypeField { get; set; }
        public List<NameField> documentDescriptionField { get; set; }
        public AttachmentType attachmentField { get; set; }
        public PeriodType validityPeriodField { get; set; }
        public PartyType issuerPartyField { get; set; }
    }
    public partial class AttachmentType
    {
        public BinaryObjectType embeddedDocumentBinaryObjectField { get; set; }
        public ExternalReferenceType externalReferenceField { get; set; }
    }
    public class ExternalReferenceType
    {
        public IdentificationId uRIField { get; set; }
    }
    public class BinaryObjectType
    {
        public string formatField { get; set; }
        public string mimeCodeField { get; set; }
        public string encodingCodeField { get; set; }
        public string characterSetCodeField { get; set; }
        public string uriField { get; set; }
        public string filenameField { get; set; }
        public byte[] valueField { get; set; }
    }
    public class FinancialAccountType
    {
        public IdentificationId idField { get; set; }
        public Code currencyCodeField { get; set; }
        public NameField paymentNoteField { get; set; }
        public BranchType financialInstitutionBranchField { get; set; }
    }
    public class BranchType
    {
        public NameField nameField { get; set; }
        public FinancialInstitutionType financialInstitutionField { get; set; }
    }
    public partial class FinancialInstitutionType
    {
        public NameField nameField { get; set; }
    }
    public class PartyLegalEntityType
    {
        public NameField registrationNameField { get; set; }
        public IdentificationId companyIDField { get; set; }
        public DateType registrationDateField { get; set; }
        public IndicatorType soleProprietorshipIndicatorField { get; set; }
        public AmountType corporateStockAmountField { get; set; }
        public IndicatorType fullyPaidSharesIndicatorField { get; set; }
        public CorporateRegistrationSchemeType corporateRegistrationSchemeField { get; set; }
        public PartyType headOfficePartyField { get; set; }
    }
    public class CorporateRegistrationSchemeType
    {
        public IdentificationId idField { get; set; }
        public NameField nameField { get; set; }
        public Code corporateRegistrationTypeCodeField { get; set; }
        public List<AddressType> jurisdictionRegionAddressField { get; set; }
    }
    public class IndicatorType
    {
        public bool valueField { get; set; }
    }
    public class LocationType1
    {
        public IdentificationId idField { get; set; }
        public AddressType addressField { get; set; }
    }

    #endregion
    public class CustomerInfo
    {
        public string VknTckn { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
    }

    public class InvoiceLine
    {
        [JsonProperty("idField")]
        public IdentificationId InvoiceId { get; set; }
        [JsonProperty("noteField")]
        public List<NameField> Notlar { get; set; }
        [JsonProperty("invoicedQuantityField")]
        public InvoiceQuantity Miktar { get; set; }
        [JsonProperty("lineExtensionAmountField")]
        public AmountType SatirKdvSizToplam { get; set; }
        [JsonProperty("taxTotalField")]
        public TaxTotal TaxTotal { get; set; }

        [JsonProperty("withholdingTaxTotalField")]
        public List<TaxTotal> WithholdingTaxTotal { get; set; }
        public legalMonetaryTotalField legalMonetaryTotalField { get; set; }
        [JsonProperty("itemField")]
        public Item Item { get; set; }
        [JsonProperty("priceField")]
        public Price Price { get; set; }
        [JsonProperty("subInvoiceLineField")]
        public List<InvoiceLine> SubInvoiceLine { get; set; }
    }

    public class legalMonetaryTotalField
    {
        public AmountType lineExtensionAmountField { get; set; }
        public AmountType taxExclusiveAmountField { get; set; }
        public AmountType taxInclusiveAmountField { get; set; }
        public AmountType allowanceTotalAmountField { get; set; }
        public AmountType chargeTotalAmountField { get; set; }
        public AmountType payableRoundingAmountField { get; set; }
        public AmountType payableAmountField { get; set; }
    }
    public class InvoiceQuantity
    {
        [JsonProperty("valueField")]
        public decimal Value { get; set; }
        [JsonProperty("unitCodeField")]
        public string UnitCodeField { get; set; }
    }
    public class TaxTotal
    {
        [JsonProperty("taxAmountField")]
        public AmountType TaxAmountField { get; set; }
        [JsonProperty("taxSubtotalField")]
        public List<TaxSubTotal> TaxSubtotalField { get; set; }
    }

    public class TaxSubTotal
    {
        [JsonProperty("taxableAmountField")]
        public AmountType TaxableAmount { get; set; }
        [JsonProperty("taxAmountField")]
        public AmountType TaxAmount { get; set; }
        [JsonProperty("calculationSequenceNumericField")]
        public NumericType CalculationSequence { get; set; }
        [JsonProperty("transactionCurrencyTaxAmountField")]
        public AmountType TransactionCurrencyTaxAmount { get; set; }
        [JsonProperty("percentField")]
        public NumericType Percent { get; set; }
        [JsonProperty("baseUnitMeasureField")]
        public string BaseUnitMeasure { get; set; }
        [JsonProperty("perUnitAmountField")]
        public AmountType PerUnitAmount { get; set; }
        [JsonProperty("taxCategoryField")]
        public TaxCategory TaxCategory { get; set; }
    }
    public class AmountType
    {
        [JsonProperty("currencyIDField")]
        public string CurrencyIDField { get; set; }
        [JsonProperty("currencyCodeListVersionIDField")]
        public string CurrencyCodeListVersionID { get; set; }
        [JsonProperty("valueField")]
        public decimal Value { get; set; }
    }

    public class NumericType
    {
        [JsonProperty("formatField")]
        public string FormatField { get; set; }
        [JsonProperty("valueField")]
        public decimal Value { get; set; }
    }
    #region Tax Alani
    public class TaxCategory
    {
        [JsonProperty("nameField")]
        public NameField Name { get; set; }
        [JsonProperty("taxExemptionReasonCodeField")]
        public Code TaxExemptionReasonCode { get; set; }
        [JsonProperty("taxExemptionReasonField")]
        public Code TaxExemptionReason { get; set; }
        [JsonProperty("taxSchemeField")]
        public TaxScheme TaxScheme { get; set; }
    }
    public class TaxScheme
    {
        [JsonProperty("idField")]
        public IdentificationId Id { get; set; }
        [JsonProperty("nameField")]
        public NameField TaxName { get; set; }
        [JsonProperty("taxTypeCodeField")]
        public Code TaxTypeCode { get; set; }
    }
    #endregion
    public class Item
    {
        [JsonProperty("descriptionField")]
        public NameField Description { get; set; }
        [JsonProperty("nameField")]
        public NameField Name { get; set; }
        [JsonProperty("keywordField")]
        public NameField Keyword { get; set; }
        [JsonProperty("brandNameField")]
        public NameField BrandName { get; set; }
        [JsonProperty("modelNameField")]
        public NameField ModelName { get; set; }
        [JsonProperty("buyersItemIdentificationField")]
        public Identification BuyersItemIdentification { get; set; }
        [JsonProperty("sellersItemIdentificationField")]
        public Identification SellersItemIdentification { get; set; }
        [JsonProperty("manufacturersItemIdentificationField")]
        public Identification ManufacturersItemIdentification { get; set; }
        [JsonProperty("additionalItemIdentificationField")]
        public List<Identification> AdditionalItemIdentification { get; set; }
        [JsonProperty("originCountryField")]
        public CountryField OriginCountry { get; set; }
        [JsonProperty("commodityClassificationField")]
        public List<Code> CommodityClassification { get; set; }
        [JsonProperty("itemInstanceField")]
        public List<ItemInstanceType> ItemInstanceField { get; set; }
    }
    public class ItemInstanceType
    {
        public IdentificationId productTraceIDField { get; set; }
        public DateType manufactureDateField { get; set; }
        public DateType manufactureTimeField { get; set; }
        public DateType bestBeforeDateField { get; set; }
        public IdentificationId registrationIDField { get; set; }
        public IdentificationId serialIDField { get; set; }
        public List<ItemPropertyType> additionalItemPropertyField { get; set; }
        public LotIdentificationType lotIdentificationField { get; set; }
    }
    public class LotIdentificationType
    {
        public IdentificationId lotNumberIDField { get; set; }
        public DateType expiryDateField { get; set; }
        public List<ItemPropertyType> additionalItemPropertyField { get; set; }
    }
    public class ItemPropertyType
    {
        public IdentificationId idField { get; set; }
        public NameField nameField { get; set; }
        public Code nameCodeField { get; set; }
        public NameField testMethodField { get; set; }
        public NameField valueField { get; set; }
        public QuantityType valueQuantityField { get; set; }
        public List<NameField> valueQualifierField { get; set; }
        public Code importanceCodeField { get; set; }
        public List<NameField> listValueField { get; set; }
        public PeriodType usabilityPeriodField { get; set; }
        public List<ItemPropertyGroupType> itemPropertyGroupField { get; set; }
        public DimensionType rangeDimensionField { get; set; }
        public ItemPropertyRangeType itemPropertyRangeField { get; set; }
    }
    public class ItemPropertyRangeType
    {
        public NameField minimumValueField { get; set; }
        public NameField maximumValueField { get; set; }
    }
    public class DimensionType
    {
        public IdentificationId attributeIDField { get; set; }
        public MeasureType measureField { get; set; }
        public List<NameField> descriptionField { get; set; }
        public MeasureType minimumMeasureField { get; set; }
        public MeasureType maximumMeasureField { get; set; }
    }
    public class ItemPropertyGroupType
    {
        public IdentificationId idField { get; set; }
        public NameField nameField { get; set; }
        public Code importanceCodeField { get; set; }
    }
    public class PeriodType
    {
        public DateType startDateField { get; set; }
        public DateType startTimeField { get; set; }
        public DateType endDateField { get; set; }
        public DateType endTimeField { get; set; }
        public MeasureType durationMeasureField { get; set; }
        public NameField descriptionField { get; set; }
    }
    public class MeasureType
    {
        public string unitCodeField { get; set; }
        public string unitCodeListVersionIDField { get; set; }
        public decimal valueField { get; set; }
    }
    public partial class QuantityType
    {
        public string unitCodeField { get; set; }
        public string unitCodeListIDField { get; set; }
        public string unitCodeListAgencyIDField { get; set; }
        public string unitCodeListAgencyNameField { get; set; }
        public decimal valueField { get; set; }
    }
    public class DateType
    {
        [JsonProperty("valueField")]
        public DateTime Value { get; set; }
    }
    public class Price
    {
        [JsonProperty("priceAmountField")]
        public AmountType PriceAmount { get; set; }
    }
    public class Code
    {
        public string listIDField { get; set; }
        public string listAgencyIDField { get; set; }
        public string listAgencyNameField { get; set; }
        public string listNameField { get; set; }
        public string listVersionIDField { get; set; }
        public string nameField { get; set; }
        public string languageIDField { get; set; }
        public string listURIField { get; set; }
        public string listSchemeURIField { get; set; }
        public string valueField { get; set; }
    }
    public class Identification
    {
        [JsonProperty("idField")]
        public IdentificationId IdField { get; set; }
    }
    public class NameField
    {
        public string languageIDField { get; set; }
        public string languageLocaleIDField { get; set; }
        [JsonProperty("valueField")]
        public string Value { get; set; }
    }
    public class IdentificationId
    {
        [JsonProperty("schemeIDField")]
        public string SchemeID { get; set; }
        [JsonProperty("schemeNameField")]
        public string SchemeName { get; set; }
        [JsonProperty("schemeAgencyIDField")]
        public string SchemeAgencyID { get; set; }
        [JsonProperty("schemeAgencyNameField")]
        public string SchemeAgencyName { get; set; }
        [JsonProperty("schemeVersionIDField")]
        public string SchemeVersionID { get; set; }
        [JsonProperty("schemeDataURIField")]
        public string SchemeDataURI { get; set; }
        [JsonProperty("schemeURIField")]
        public string SchemeURI { get; set; }
        [JsonProperty("valueField")]
        public string Value { get; set; }
    }
}