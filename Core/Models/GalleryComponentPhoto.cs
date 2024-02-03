using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GalleryComponentPhoto
    {
        public int Id { get; set; }

        public GalleryComponent GalleryComponent { get; set; }

        public int GalleryComponentId { get; set; }

        public string PhotoName { get; set; }
    }
}
