using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Company
{
    public class CompanyListDto : BaseCompanyDto
    {
        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }
        [JsonProperty("typeDescription")]
        public string TypeDescription { get; set; }
    }
}
