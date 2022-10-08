using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.User
{
    public class UserListDto : BaseUserDto
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("lastLoginDate")]
        public DateTime LastLoginDate { get; set; }

        public string TypeDescription { get; set; }

        public string CompanyName { get; set; }
    }
}
