using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        //[Required]
        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        //[Required]
        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

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

        //[Required]
        [Display(Name = "Button Text (AZ)")]
        public string ButtonText_AZ { get; set; }

        //[Required]
        [Display(Name = "Button Text (RU)")]
        public string ButtonText_RU { get; set; }

        [Required]
        [Display(Name = "Button Text (EN)")]
        public string ButtonText_EN { get; set; }

        //[Required]
        [Display(Name = "Button Text (TR)")]
        public string ButtonText_TR { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OpportunityApply> OpportunityApplies { get; set; }
    }
}
