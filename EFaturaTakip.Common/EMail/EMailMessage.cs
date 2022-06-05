using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.EMail
{
    public class EMailMessage
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }

        public List<EMailAttachment> Attachments { get; set; }

        public EMailMessage(IEnumerable<string> to, string subject, string content, List<EMailAttachment> attachments)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("gmail", x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
        public EMailMessage(IEnumerable<string> to, string subject, string content, EMailAttachment attachment)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("gmail", x)));
            Subject = subject;
            Content = content;
            Attachments = new List<EMailAttachment> { attachment };
        }
    }
}
