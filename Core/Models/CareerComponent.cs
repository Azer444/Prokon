using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class CareerComponent
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        //[Required]
        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        //[Required]
        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string PhotoName { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
