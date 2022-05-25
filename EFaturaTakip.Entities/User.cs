using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Roles = new HashSet<UserRole>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ServiceUserName { get; set; }
        public string ServicePassword { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }

    }
}
