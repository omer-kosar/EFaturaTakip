using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.EMail
{
    public class EMailAttachment
    {
        public EMailAttachment(string fileType, string fileName, byte[] file)
        {
            File = file;
            FileName = fileName;
            Type = fileType;
        }
        public string Type { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
