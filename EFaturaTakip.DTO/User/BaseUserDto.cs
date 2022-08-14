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
    
        [JsonProperty("province")]

        public string? Province { get; set; }
        [JsonProperty("district")]

        public string? District { get; set; }
        [JsonProperty("apartmentNumber")]
        public string? ApartmentNumber { get; set; }
        [JsonProperty("flatNumber")]

        public string? FlatNumber { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }
    }
}
