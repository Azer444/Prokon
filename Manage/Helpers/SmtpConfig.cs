using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Helpers
{
    public class SmtpConfig
    {
        public string Password { get; set; }
        public string FromEmail { get; set; }
        public string ToHREmail { get; set; }
        public string ToContactEmail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
