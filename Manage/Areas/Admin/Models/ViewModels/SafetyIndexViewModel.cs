using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class SafetyIndexViewModel
    {
        public PageMainPhoto SafetyMainPhoto { get; set; }

        public List<SafetyComponent> SafetyComponents { get; set; }

        public SafetyTextComponent SafetyTextComponent { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
