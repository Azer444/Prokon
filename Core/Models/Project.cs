using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Project
    {
        public Project()
        {
            Photos = new List<IFormFile>();
            ProjectPhotos = new List<ProjectPhoto>();
            SplitedDescription_AZ = new List<string>();
            SplitedDescription_RU = new List<string>();
            SplitedDescription_EN = new List<string>();
            SplitedDescription_TR = new List<string>();
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

        [NotMapped]
        public List<string> SplitedDescription_AZ { get; set; }

        [NotMapped]
        public List<string> SplitedDescription_RU{ get; set; }

        [NotMapped]
        public List<string> SplitedDescription_EN { get; set; }

        [NotMapped]
        public List<string> SplitedDescription_TR { get; set; }

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Planned Completion Date")]
        public DateTime? PlannedCompletionDate { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }

        public string TitlePhotoName { get; set; }

        [Required]
        [NotMapped]
        [Display(Name ="Title Photo")]
        public IFormFile TitlePhoto { get; set; }

        public ICollection<ProjectPhoto> ProjectPhotos { get; set; }

        [NotMapped]
        public List<IFormFile> Photos { get; set; }

        [Display(Name = "Show on Home Page")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Home Order")]
        public int? HomePageOrder { get; set; }

        [NotMapped]
        [Display(Name = "Show as Gallery")]
        public bool ShowAsGallery { get; set; }

        [NotMapped]
        [Display(Name = "Show as Gallery on Home Page")]
        public bool ShowOnHomePageAsGallery { get; set; }

        [NotMapped]
        [Display(Name = "Gallery Order")]
        public int? GalleryOrder { get; set; }

        [Display(Name = "Order")]
        public int? CurrentOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public GalleryComponent GalleryComponent { get; set; }
    }
}
