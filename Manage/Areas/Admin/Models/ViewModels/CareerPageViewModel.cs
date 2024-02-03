using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class CareerPageViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public ContentAccessComponent ContentAccessComponent { get; set; }

        public List<CareerComponent> JobComponents { get; set; }

        public List<CareerComponent> InternshipComponents { get; set; }


        public CareerFormComponent CareerFormComponent { get; set; }

        public CareerAppContent CareerAppContent { get; set; }
    }
}
