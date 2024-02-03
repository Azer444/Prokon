using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NavComponent
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        //[Required]
        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        //[Required]
        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        public NavTitleComponent NavTitleComponent { get; set; }

        public int NavTitleComponentId { get; set; }

        public ICollection<NavSubComponent> NavSubComponents { get; set; }

        public string Link { get; set; }
    }
}
