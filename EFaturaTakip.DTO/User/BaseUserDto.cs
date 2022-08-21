using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.User
{
    public class BaseUserDto
    {
        public Guid? CompanyId { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("userType")]
        public int UserType { get; set; }
    }
}
