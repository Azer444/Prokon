using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        private readonly ProkonContext db;

        public OpportunityRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<List<Opportunity>> GetAllAsync()
        {
            var opportunities = await db.Opportunities
                                                    .OrderByDescending(o => o.Id)
                                                    .ToListAsync();
            return opportunities;
        }

        public async override Task<Opportunity> GetAsync(int? id)
        {
            var opportunity = await db.Opportunities
                                                   .Include(o => o.OpportunityApplies.OrderByDescending(oa => oa.Id))
                                                   .ThenInclude(a => a.OpportunityApplyFiles)
                                                   .FirstOrDefaultAsync(o => o.Id == id);
            return opportunity;
        }

        public async Task<List<Opportunity>> GetAllByTypeAsync(string type)
        {
            var opportunities = await db.Opportunities
                                                      .Where(o => o.Type == type)
                                                      .ToListAsync();
            return opportunities;
        }
    }
}
