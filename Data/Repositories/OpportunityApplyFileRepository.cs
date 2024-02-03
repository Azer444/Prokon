using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class OpportunityApplyFileRepository : Repository<OpportunityApplyFile>, IOpportunityApplyFileRepository
    {
        private readonly ProkonContext db;

        public OpportunityApplyFileRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
