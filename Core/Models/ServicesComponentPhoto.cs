using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class ServicesComponentPhoto
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public int ServicesComponentId { get; set; }

        public ServicesComponent ServicesComponent { get; set; }
    }
}
