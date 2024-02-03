using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ServicesComponentEditViewModel
    {
        public ServicesComponentEditViewModel()
        {
            Photos = new List<IFormFile>();
        }
        public int Id { get; set; }

        [Display(Name = "Title(AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title(RU)")]
        public string Title_RU { get; set; }

        [Display(Name = "Title(EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Title(TR)")]
        public string Title_TR { get; set; }

        //[Required]
        [Display(Name = "Content(AZ)")]
        public string Content_AZ { get; set; }

        //[Required]
        [Display(Name = "Content(RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content(EN)")]
        public string Content_EN { get; set; }

        //[Required]
        [Display(Name = "Content(TR)")]
        public string Content_TR { get; set; }

        public List<IFormFile> Photos { get; set; }

        public ICollection<ServicesComponentPhoto> ServicesComponentPhotos { get; set; }
    }
}
