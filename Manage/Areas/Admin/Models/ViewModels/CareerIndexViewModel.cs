using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class CareerIndexViewModel
    {      
        public List<Opportunity> JobOpportunities { get; set; }

        public List<Opportunity> InternshipOpportunities { get; set; }

        public List<GeneralApply> GeneralApplies { get; set; }
    }
}
