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
    public class NavTitleComponentRepository : Repository<NavTitleComponent>, INavTitleComponentRepository
    {
        private readonly ProkonContext db;

        public NavTitleComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<List<NavTitleComponent>> GetAllAsync()
        {
            var navTitleComponents = await db.NavTitleComponents
                                                            .Include(c => c.NavComponents)
                                                            .ThenInclude(c => c.NavSubComponents)
                                                            .ToListAsync();
            return navTitleComponents;
        }

        public async override Task<NavTitleComponent> GetAsync(int? id)
        {
            var navTitleComponent = await db.NavTitleComponents
                                                        .Include(c => c.NavComponents)
                                                        .ThenInclude(c => c.NavSubComponents)
                                                        .FirstOrDefaultAsync(c=> c.Id == id);
            return navTitleComponent;
        }
    }
}
