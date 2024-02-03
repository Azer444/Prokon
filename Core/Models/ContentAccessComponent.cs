using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class ContentAccessComponent
    {
        public int Id { get; set; }

        [Required]
        public string Page { get; set; }

        //[Required]
        [Display(Name = "Access1 (AZ)")]
        public string Access1_AZ { get; set; }

        //[Required]
        [Display(Name = "Access1 (RU)")]
        public string Access1_RU { get; set; }

        [Required]
        [Display(Name = "Access1 (EN)")]
        public string Access1_EN { get; set; }

        //[Required]
        [Display(Name = "Access1 (TR)")]
        public string Access1_TR { get; set; }

        //[Required]
        [Display(Name = "Access2 (AZ)")]
        public string Access2_AZ { get; set; }

        //[Required]
        [Display(Name = "Access2 (RU)")]
        public string Access2_RU { get; set; }

        [Required]
        [Display(Name = "Access2 (EN)")]
        public string Access2_EN { get; set; }

        //[Required]
        [Display(Name = "Access2 (TR)")]
        public string Access2_TR { get; set; }

        [Display(Name = "Access3 (AZ)")]
        public string Access3_AZ { get; set; }

        [Display(Name = "Access3 (RU)")]
        public string Access3_RU { get; set; }

        [Display(Name = "Access3 (EN)")]
        public string Access3_EN { get; set; }

        [Display(Name = "Access3 (TR)")]
        public string Access3_TR { get; set; }
    }
}
