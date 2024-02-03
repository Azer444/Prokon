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
    public class PageAccessComponentRepository : Repository<PageAccessComponent>, IPageAccessComponentRepository
    {
        private readonly ProkonContext db;

        public PageAccessComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<PageAccessComponent> GetByPageNameAsync(string page)
        {
            var pageAccessComponent = await db.PageAccessComponents
                                                           .FirstOrDefaultAsync(c => c.Page == page);
            return pageAccessComponent;
        }
    }
}
