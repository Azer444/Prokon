using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class GovernanceViewModel
    {
        public HeaderPartialViewModel HeaderPartialViewModel { get; set; }

        public FooterPartialViewModel FooterPartialViewModel { get; set; }

        public MobileMenuPartialViewModel MobileMenuPartialViewModel { get; set; }

        public PageMainPhoto PageMainPhoto { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public List<GovernanceComponent> GovernanceComponents { get; set; }

        public SectionLayoutContent ManagementLayoutContent { get; set; }

        public List<Management> Managements { get; set; }
    }
}
