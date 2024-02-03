using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class CareerFormComponent
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
        [Display(Name = "Field1 (AZ)")]
        public string Field1_AZ { get; set; }

        //[Required]
        [Display(Name = "Field1 (RU)")]
        public string Field1_RU { get; set; }

        [Required]
        [Display(Name = "Field1 (EN)")]
        public string Field1_EN { get; set; }

        //[Required]
        [Display(Name = "Field1 (TR)")]
        public string Field1_TR { get; set; }


        //[Required]
        [Display(Name = "Field2 (AZ)")]
        public string Field2_AZ { get; set; }

        //[Required]
        [Display(Name = "Field2 (RU)")]
        public string Field2_RU { get; set; }

        [Required]
        [Display(Name = "Field2 (EN)")]
        public string Field2_EN { get; set; }

        //[Required]
        [Display(Name = "Field2 (TR)")]
        public string Field2_TR { get; set; }


        //[Required]
        [Display(Name = "Field3 (AZ)")]
        public string Field3_AZ { get; set; }

        //[Required]
        [Display(Name = "Field3 (RU)")]
        public string Field3_RU { get; set; }

        [Required]
        [Display(Name = "Field3 (EN)")]
        public string Field3_EN { get; set; }

        //[Required]
        [Display(Name = "Field3 (TR)")]
        public string Field3_TR { get; set; }


        //[Required]
        [Display(Name = "Field4 (AZ)")]
        public string Field4_AZ { get; set; }

        //[Required]
        [Display(Name = "Field4 (RU)")]
        public string Field4_RU { get; set; }

        [Required]
        [Display(Name = "Field4 (EN)")]
        public string Field4_EN { get; set; }

        //[Required]
        [Display(Name = "Field4 (TR)")]
        public string Field4_TR { get; set; }


        //[Required]
        [Display(Name = "Field5 (AZ)")]
        public string Field5_AZ { get; set; }

        //[Required]
        [Display(Name = "Field5 (RU)")]
        public string Field5_RU { get; set; }

        [Required]
        [Display(Name = "Field5 (EN)")]
        public string Field5_EN { get; set; }

        //[Required]
        [Display(Name = "Field5 (TR)")]
        public string Field5_TR { get; set; }

        //[Required]
        [Display(Name = "Error Message (AZ)")]
        public string ErrorMessage_AZ { get; set; }

        //[Required]
        [Display(Name = "Error Message (RU)")]
        public string ErrorMessage_RU { get; set; }

        [Required]
        [Display(Name = "Error Message (EN)")]
        public string ErrorMessage_EN { get; set; }

        //[Required]
        [Display(Name = "Error Message (TR)")]
        public string ErrorMessage_TR { get; set; }

        //[Required]
        [Display(Name = "Success Message (AZ)")]
        public string SuccessMessage_AZ { get; set; }

        //[Required]
        [Display(Name = "Success Message (RU)")]
        public string SuccessMessage_RU { get; set; }

        [Required]
        [Display(Name = "Success Message (EN)")]
        public string SuccessMessage_EN { get; set; }

        //[Required]
        [Display(Name = "Success Message (TR)")]
        public string SuccessMessage_TR { get; set; }

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
    }
}
