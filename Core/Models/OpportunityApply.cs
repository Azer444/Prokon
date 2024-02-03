using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class OpportunityApply
    {
        public int Id { get; set; }

        public Opportunity Opportunity { get; set; }

        public int OpportunityId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string CVName { get; set; }

        public ICollection<OpportunityApplyFile> OpportunityApplyFiles { get; set; }
    }
}
