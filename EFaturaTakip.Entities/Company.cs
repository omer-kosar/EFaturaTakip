using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities
{
    [Table("Company")]

    public class Company
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcKimlikNo { get; set; }
        public string VergiNo { get; set; }
        public string TaxOffice { get; set; }
        public string Adress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string EMailAdress { get; set; }
        public string Country { get; set; }
        public string ApartmentNumber { get; set; }
        public string FlatNumber { get; set; }
        public int Type { get; set; }

        public int CompanySaveType { get; set; }
        public string ServiceUserName { get; set; }
        public string ServicePassword { get; set; }

        public string CommercialRegistrationNumber { get; set; }

        public string CentralRegistrationNumber { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
