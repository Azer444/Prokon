using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ProjectEditViewModel
    {
        public ProjectEditViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public int Id { get; set; }

        //[Required]
        [Display(Name = "Name(AZ)")]
        public string Name_AZ { get; set; }

        //[Required]
        [Display(Name = "Name(RU)")]
        public string Name_RU { get; set; }

        [Required]
        [Display(Name = "Name(EN)")]
        public string Name_EN { get; set; }

        //[Required]
        [Display(Name = "Name(TR)")]
        public string Name_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Type { get; set; }

        [Display(Name = "Location(AZ)")]
        public string Location_AZ { get; set; }

        [Display(Name = "Location(RU)")]
        public string Location_RU { get; set; }

        [Display(Name = "Location(EN)")]
        public string Location_EN { get; set; }

        [Display(Name = "Location(TR)")]
        public string Location_TR { get; set; }

        [Display(Name = "Description(AZ)")]
        public string Description_AZ { get; set; }

        [Display(Name = "Description(RU)")]
        public string Description_RU { get; set; }

        [Display(Name = "Description(EN)")]
        public string Description_EN { get; set; }

        [Display(Name = "Description(TR)")]
        public string Description_TR { get; set; }

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Planned Completion Date")]
        public DateTime? PlannedCompletionDate { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }

        public string TitlePhotoName { get; set; }

        public IFormFile TitlePhoto { get; set; }

        public ICollection<ProjectPhoto> ProjectPhotos { get; set; }

        public List<IFormFile> Photos { get; set; }

        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Home Order")]
        public int? HomePageOrder { get; set; }

        public bool ShowAsGallery { get; set; }

        public bool ShowOnHomePageAsGallery { get; set; }

        public int? GalleryOrder { get; set; }

        public int? CurrentOrder { get; set; }
    }
}
