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
        
        public Guid Id { get; set; }
        [JsonProperty("typeDescription")]
        public string TypeDescription { get; set; }
        public Guid? MusavirId { get; set; }
        public string? ServiceUserName { get; set; }
        public string? ServicePassword { get; set; }
    }
}
