using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class TeamIndexViewModel
    {
        public PageMainPhoto MainPhoto { get; set; }

        public List<TeamComponent> Components { get; set; }
    }
}
