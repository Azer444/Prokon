using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ManagementIndexViewModel
    {
        public List<Management> Managements { get; set; }

        public SectionLayoutContent ManagementLayoutContent { get; set; }
    }
}
