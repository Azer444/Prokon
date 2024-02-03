using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class GovernanceIndexViewModel
    {
        public PageMainPhoto GovernanceMainPhoto { get; set; }

        public List<GovernanceComponent> GovernanceComponents { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
