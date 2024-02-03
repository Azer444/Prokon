using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class AboutIndexViewModel
    {
        public PageMainPhoto AboutMainPhoto { get; set; }
        public AboutComponent AboutComponent { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
