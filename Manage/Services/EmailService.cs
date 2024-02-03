using Manage.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Manage.Models;
using System.Net;

namespace Manage.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SmtpConfig> smtpConfig;

        public EmailService(IOptions<SmtpConfig> smtpConfig)
        {
            this.smtpConfig = smtpConfig;
        }

        public async Task SendEmailAsync(string subject, string body, string email)
        {
            using (MailMessage message = new MailMessage(smtpConfig.Value.FromEmail, email))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = smtpConfig.Value.Host;
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(smtpConfig.Value.FromEmail, smtpConfig.Value.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = cred;
                    smtp.Port = smtpConfig.Value.Port;
                    smtp.Send(message);
                };
            }
        }
    }
}
