using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.User
{
    public class UserAddDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public string? ServiceUserName { get; set; }
        public string? ServicePassword { get; set; }
    }
}
