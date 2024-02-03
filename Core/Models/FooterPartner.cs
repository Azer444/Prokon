using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class FooterPartner
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public SiteConfig SiteConfig { get; set; }

        public int SiteConfigId { get; set; }
    }
}
