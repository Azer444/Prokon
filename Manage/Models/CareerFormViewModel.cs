using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Models
{
    public class CareerFormViewModel
    {
        public CareerFormViewModel()
        {
            SupportingFiles = new List<IFormFile>();
        }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public IFormFile CV { get; set; }

        public List<IFormFile> SupportingFiles { get; set; }

        [Required]
        public int? OpportunityId { get; set; }
    }
}
