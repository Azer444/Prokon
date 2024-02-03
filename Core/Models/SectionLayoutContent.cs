using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class SectionLayoutContent
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        //[Required]
        [Display(Name = "Title Text (AZ)")]
        public string TitleText_AZ { get; set; }

        //[Required]
        [Display(Name = "Title Text (RU)")]
        public string TitleText_RU { get; set; }

        [Required]
        [Display(Name = "Title Text (EN)")]
        public string TitleText_EN { get; set; }

        //[Required]
        [Display(Name = "Title Text (TR)")]
        public string TitleText_TR { get; set; }


        [Display(Name = "Helper Text (AZ)")]
        public string HelperText_AZ { get; set; }

        [Display(Name = "Helper Text (RU)")]
        public string HelperText_RU { get; set; }

        [Display(Name = "Helper Text (EN)")]
        public string HelperText_EN { get; set; }

        [Display(Name = "Helper Text (TR)")]
        public string HelperText_TR { get; set; }

        [Display(Name = "Bottom Text (AZ)")]
        public string BottomText_AZ { get; set; }

        [Display(Name = "Bottom Text (RU)")]
        public string BottomText_RU { get; set; }

        [Display(Name = "Bottom Text (EN)")]
        public string BottomText_EN { get; set; }

        [Display(Name = "Bottom Text (TR)")]
        public string BottomText_TR { get; set; }
    }
}
