using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class HeaderPartialViewModel
    {
        public List<NavTitleComponent> NavTitleComponents { get; set; }

        public SiteConfig SiteConfig { get; set; }
    }
}
