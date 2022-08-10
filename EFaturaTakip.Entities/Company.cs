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
        public string TcknVkn { get; set; }
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
    }
}
