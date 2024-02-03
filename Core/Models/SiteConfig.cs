using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SiteConfig
    {
        public SiteConfig()
        {
            FooterPartnerPhotos = new List<IFormFile>();
        }

        public int Id { get; set; }

        public string FirstLogoName{ get; set; }

        [NotMapped]
        [Required]
        public IFormFile FirstLogo { get; set; }

        public string SecondLogoName { get; set; }

        [NotMapped]
        [Required]
        public IFormFile SecondLogo { get; set; }

        //[Required]
        [Display(Name = "Head Office(AZ)")]
        public string HeadOffice_AZ { get; set; }

        //[Required]
        [Display(Name = "Head Office(RU)")]
        public string HeadOffice_RU { get; set; }

        [Required]
        [Display(Name = "Head Office(EN)")]
        public string HeadOffice_EN { get; set; }

        //[Required]
        [Display(Name = "Head Office(TR)")]
        public string HeadOffice_TR { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Linkedin Link")]
        public string LinkedinLink { get; set; }

        [Required]
        [Display(Name = "Linkedin Text (AZ,EN,TR)")]
        public string LinkedinText { get; set; }

        //[Required]
        [Display(Name = "Linkedin Text (RU)")]
        public string LinkedinText_RU { get; set; }

        [Required]
        [Display(Name = "Facebook Link")]
        public string FacebookLink { get; set; }

        [Required]
        [Display(Name = "Facebook Text (AZ,EN,TR)")]
        public string FacebookText { get; set; }

        //[Required]
        [Display(Name = "Facebook Text (RU)")]
        public string FacebookText_RU { get; set; }

        [Required]
        [Display(Name = "Twitter Link")]
        public string TwitterLink { get; set; }

        [Required]
        [Display(Name = "Twitter Text (AZ,EN,TR)")]
        public string TwitterText { get; set; }

        //[Required]
        [Display(Name = "Twitter Text (RU)")]
        public string TwitterText_RU { get; set; }

        //[Required]
        [Display(Name = "Copyright Text (AZ)")]
        public string CopyrightText_AZ { get; set; }

        //[Required]
        [Display(Name = "Copyright Text (RU)")]
        public string CopyrightText_RU { get; set; }

        [Display(Name = "Copyright Text (EN)")]
        [Required]
        public string CopyrightText_EN { get; set; }

        //[Required]
        [Display(Name = "Copyright Text (TR)")]
        public string CopyrightText_TR { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<FooterPartner> FooterPartners { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Footer Partner Photos")]
        public List<IFormFile> FooterPartnerPhotos { get; set; }
    }
}
