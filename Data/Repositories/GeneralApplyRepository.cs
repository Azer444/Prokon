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
    public class GeneralApplyRepository : Repository<GeneralApply>, IGeneralApplyRepository
    {
        private readonly ProkonContext db;

        public GeneralApplyRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<List<GeneralApply>> GetAllAsync()
        {
            var opportunities = await db.GeneralApplies
                                                    .Include(a => a.GeneralApplyFiles)
                                                    .OrderByDescending(a => a.Id)
                                                    .ToListAsync();
            return opportunities;
        }
    }
}
