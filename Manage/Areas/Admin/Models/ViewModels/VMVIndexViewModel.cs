using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class VMVIndexViewModel
    {
        public PageMainPhoto VMVMainPhoto { get; set; }

        public List<VMVComponent> VMVComponents { get; set; }

        public List<ValuesComponent> ValuesComponents { get; set; }

        public SectionLayoutContent ValuesLayoutContent { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

    }
}
