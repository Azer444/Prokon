using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class OpportunityApplyFile
    {
        public int Id { get; set; }

        public OpportunityApply OpportunityApply { get; set; }

        public int OpportunityApplyId { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
