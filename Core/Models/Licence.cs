using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Licence
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name ="Name(AZ)")]
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
        [NotMapped]
        public IFormFile PDF { get; set; }

        public string PDFName { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string PhotoName { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }
    }
}
