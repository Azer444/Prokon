using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class ServicesViewModel
    {
        public HeaderPartialViewModel HeaderPartialViewModel { get; set; }

        public FooterPartialViewModel FooterPartialViewModel { get; set; }

        public MobileMenuPartialViewModel MobileMenuPartialViewModel { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public PageMainPhoto PageMainPhoto { get; set; }

        public List<ServicesComponent> ServicesComponents { get; set; }
    }
}
