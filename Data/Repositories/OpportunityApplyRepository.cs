using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class OpportunityApplyRepository : Repository<OpportunityApply>, IOpportunityApplyRepository
    {
        private readonly ProkonContext db;

        public OpportunityApplyRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }


    }
}
