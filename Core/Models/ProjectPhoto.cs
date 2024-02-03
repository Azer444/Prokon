using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProjectPhoto
    {
        public int Id { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

        public string PhotoName { get; set; }
    }
}
