using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NavComponentRepository : Repository<NavComponent>, INavComponentRepository
    {
        private readonly ProkonContext db;

        public NavComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<NavComponent> GetAsync(int? id)
        {
            var navComponent = await db.NavComponents
                                               .Include(c => c.NavTitleComponent)
                                               .Include(c => c.NavSubComponents)
                                               .FirstOrDefaultAsync(c => c.Id == id);
            return navComponent;
        }
    }
}
