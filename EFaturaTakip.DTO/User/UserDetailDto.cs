using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.User
{
    public class UserDetailDto
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("serviceUserName")]
        public string ServiceUserName { get; set; }
        [JsonProperty("servicePassword")]
        public string ServicePassword { get; set; }
        [JsonProperty("province")]
        public string Province { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("apartmentNumber")]
        public string ApartmentNumber { get; set; }
        [JsonProperty("flatNumber")]
        public string FlatNumber { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
