using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Role
{
    public class RoleDto
    {
        [JsonPropertyName("value")]
        public Guid Id { get; set; }
        [JsonPropertyName("label")]
        public string Name { get; set; }
    }
}
