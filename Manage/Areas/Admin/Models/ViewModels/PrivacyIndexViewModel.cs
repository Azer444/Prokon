using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class PrivacyIndexViewModel
    {
        public PageMainPhoto PrivacyMainPhoto { get; set; }

        public PrivacyComponent PrivacyComponent { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
