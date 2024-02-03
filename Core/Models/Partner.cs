using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Partner
    {
        public int Id { get; set; }

        public string LogoName { get; set; }

        [NotMapped]
        public IFormFile Logo { get; set; }

    }
}
