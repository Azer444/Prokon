using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class HomeViewModel
    {
        public HeaderPartialViewModel HeaderPartialViewModel { get; set; }

        public FooterPartialViewModel FooterPartialViewModel { get; set; }

        public MobileMenuPartialViewModel MobileMenuPartialViewModel { get; set; }

        public List<SectionLayoutContent> SectionLayoutContents { get; set; }

        public List<HomeSliderComponent> SliderComponents { get; set; }

        public List<Project> Projects { get; set; }

        public List<News> News { get; set; }

        public List<Licence> Licences { get; set; }

        public List<GalleryComponent> GalleryComponents { get; set; }

        public SiteConfig SiteConfig { get; set; }
    }
}
