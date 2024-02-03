using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class CareerViewModel
    {
        public HeaderPartialViewModel HeaderPartialViewModel { get; set; }

        public FooterPartialViewModel FooterPartialViewModel { get; set; }

        public MobileMenuPartialViewModel MobileMenuPartialViewModel { get; set; }

        public PageMainPhoto PageMainPhoto { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public ContentAccessComponent ContentAccessComponent { get; set; }

        public List<CareerComponent> JobComponents { get; set; }

        public List<Opportunity> JobOpportunities { get; set; }

        public List<CareerComponent> InternshipComponents { get; set; }
        
        public List<Opportunity> InternshipOpportunities { get; set; }

        public CareerFormComponent CareerFormComponent { get; set; }

        public CareerAppContent CareerAppContent { get; set; }
    }
}
