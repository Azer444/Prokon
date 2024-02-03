using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class NewsEditViewModel
    {
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

        [Required]
        public string Slug { get; set; }

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

        [Display(Name = "Location(AZ)")]
        public string Location_AZ { get; set; }

        [Display(Name = "Location(RU)")]
        public string Location_RU { get; set; }

        [Display(Name = "Location(EN)")]
        public string Location_EN { get; set; }

        [Display(Name = "Location(TR)")]
        public string Location_TR { get; set; }

        public string PhotoName { get; set; }

        [Required]
        public string Type { get; set; }

        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime CreatedAt { get; set; }
    }
}
