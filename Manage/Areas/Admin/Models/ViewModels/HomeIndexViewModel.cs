using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<HomeSliderComponent> HomeSliderComponents { get; set; }

        public List<SectionLayoutContent> SectionLayoutContents { get; set; }
    }
}
