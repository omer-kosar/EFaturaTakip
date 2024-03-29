﻿using EFaturaTakip.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Company
{
    public class BaseCompanyDto
    {
        public Guid? CompanyId { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("tcKimlikNo")]
        public string? TcKimlikNo { get; set; }
        public string? VergiNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [JsonProperty("taxOffice")]
        public string? TaxOffice { get; set; }
        [JsonProperty("adress")]
        public string? Adress { get; set; }
        [JsonProperty("province")]
        public string? Province { get; set; }
        [JsonProperty("district")]
        public string? District { get; set; }
        [JsonProperty("mobilePhone")]
        public string? MobilePhone { get; set; }
        [JsonProperty("faxNumber")]
        public string? FaxNumber { get; set; }
        [JsonProperty("eMailAdress")]
        public string? EMailAdress { get; set; }
        [JsonProperty("country")]
        public string? Country { get; set; }
        [JsonProperty("apartmentNumber")]
        public string? ApartmentNumber { get; set; }
        [JsonProperty("flatNumber")]
        public string? FlatNumber { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        public int CompanySaveType { get; set; } = (int)EnumCompanySaveType.Customer;
      
        //ticari sicil no
        [JsonProperty("commercialRegistrationNumber")]
        public string? CommercialRegistrationNumber { get; set; }
        //mersis no
        [JsonProperty("centralRegistrationNumber")]
        public string? CentralRegistrationNumber { get; set; }
    }
}
