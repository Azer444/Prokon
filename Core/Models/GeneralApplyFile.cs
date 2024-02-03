using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class GeneralApplyFile
    {
        public int Id { get; set; }

        public GeneralApply GeneralApply { get; set; }

        public int GeneralApplyId { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
