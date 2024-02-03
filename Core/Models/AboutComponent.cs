using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AboutComponent
    {
        public AboutComponent()
        {
            Photos = new List<IFormFile>();
            SplitedContent_AZ = new List<string>();
            SplitedContent_RU = new List<string>();
            SplitedContent_EN = new List<string>();
            SplitedContent_TR = new List<string>();
        }

        public int Id { get; set; }

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

        [NotMapped]
        public List<string> SplitedContent_AZ { get; set; }

        [NotMapped]
        public List<string> SplitedContent_RU { get; set; }

        [NotMapped]
        public List<string> SplitedContent_EN { get; set; }

        [NotMapped]
        public List<string> SplitedContent_TR { get; set; }

        public ICollection<AboutPhoto> AboutPhotos { get; set; }

        [NotMapped]
        public List<IFormFile> Photos { get; set; }
    }
}
