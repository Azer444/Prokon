using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AboutPhoto 
    {
        public int Id { get; set; }

        public AboutComponent AboutComponent { get; set; }

        public int AboutComponentId { get; set; }

        [Required]
        public string PhotoName { get; set; }
    }
}
