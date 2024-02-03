using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class PartnerIndexViewModel
    {
        public PageMainPhoto MainPhoto { get; set; }

        public PartnerComponent Component { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
