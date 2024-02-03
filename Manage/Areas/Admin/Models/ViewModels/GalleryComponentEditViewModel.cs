using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class GalleryComponentEditViewModel
    {
        public GalleryComponentEditViewModel()
        {
            Photos = new List<IFormFile>();
        }
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Title(AZ)")]
        public string Title_AZ { get; set; }

        //[Required]
        [Display(Name = "Title(RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title(EN)")]
        public string Title_EN { get; set; }

        //[Required]
        [Display(Name = "Title(TR)")]
        public string Title_TR { get; set; }

        public string TitlePhotoName { get; set; }

        public IFormFile TitlePhoto { get; set; }

        public ICollection<GalleryComponentPhoto> GalleryComponentPhotos { get; set; }

        public List<IFormFile> Photos { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int? Order { get; set; }

        public DateTime Date { get; set; }
    }
}
