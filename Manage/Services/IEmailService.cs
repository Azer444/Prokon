using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string body, string email);
    }
}
