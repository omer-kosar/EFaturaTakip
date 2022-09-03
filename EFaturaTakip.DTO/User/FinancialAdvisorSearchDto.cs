using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.User
{
    public class FinancialAdvisorSearchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Companies { get; set; } = new List<Guid>();
    }
}
