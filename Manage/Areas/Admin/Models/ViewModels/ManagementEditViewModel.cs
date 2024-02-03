using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ManagementEditViewModel
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Name(AZ)")]
        public string Name_AZ { get; set; }

        //[Required]
        [Display(Name = "Name(RU)")]
        public string Name_RU { get; set; }

        [Required]
        [Display(Name = "Name(EN)")]
        public string Name_EN { get; set; }

        //[Required]
        [Display(Name = "Name(TR)")]
        public string Name_TR { get; set; }

        [Required]
        [Display(Name = "Duty(AZ)")]
        public string Duty_AZ { get; set; }

        [Required]
        [Display(Name = "Duty(RU)")]
        public string Duty_RU { get; set; }

        [Required]
        [Display(Name = "Duty(EN)")]
        public string Duty_EN { get; set; }

        [Required]
        [Display(Name = "Duty(TR)")]
        public string Duty_TR { get; set; }

        [Required]
        [Display(Name = "About(AZ)")]
        public string About_AZ { get; set; }

        [Required]
        [Display(Name = "About(RU)")]
        public string About_RU { get; set; }

        [Required]
        [Display(Name = "About(EN)")]
        public string About_EN { get; set; }

        [Required]
        [Display(Name = "About(TR)")]
        public string About_TR { get; set; }

        public string PhotoName { get; set; }

        
        public IFormFile Photo { get; set; }
    }
}
