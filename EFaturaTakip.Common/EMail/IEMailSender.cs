using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.EMail
{
    public interface IEMailSender
    {
        void SendEmail(EMailMessage message);
        Task SendEmailAsync(EMailMessage message);
    }
}
