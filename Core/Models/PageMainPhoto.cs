﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PageMainPhoto
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

        public string PhotoName { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Page { get; set; }
    }
}
