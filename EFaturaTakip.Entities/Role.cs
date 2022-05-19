using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }

    }
}
