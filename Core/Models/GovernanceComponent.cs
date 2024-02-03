using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GovernanceComponent
    {
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


        public string PhotoName { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
