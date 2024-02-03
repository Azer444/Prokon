using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class HomeSliderComponentEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        public string PhotoName { get; set; }

        public IFormFile Photo { get; set; }

        [Display(Name = "Button Text (AZ)")]
        public string ButtonText_AZ { get; set; }

        [Display(Name = "Button Text (RU)")]
        public string ButtonText_RU { get; set; }

        [Display(Name = "Button Text (EN)")]
        public string ButtonText_EN { get; set; }

        [Display(Name = "Button Text (TR)")]
        public string ButtonText_TR { get; set; }

        public string Link { get; set; }
    }
}
