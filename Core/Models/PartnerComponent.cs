﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PartnerComponent
    {
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

        public string PhotoName { get; set; }

        [NotMapped]
        public List<string> SplitedContent_AZ { get; set; }

        [NotMapped]
        public List<string> SplitedContent_RU { get; set; }

        [NotMapped]
        public List<string> SplitedContent_EN { get; set; }

        [NotMapped]
        public List<string> SplitedContent_TR { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
