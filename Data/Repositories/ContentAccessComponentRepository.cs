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
    public class ContentAccessComponentRepository : Repository<ContentAccessComponent>, IContentAccessComponentRepository
    {
        private readonly ProkonContext db;

        public ContentAccessComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<ContentAccessComponent> GetByPageNameAsync(string page)
        {
            var contentAccessComponent = await db.ContentAccessComponents
                                                           .FirstOrDefaultAsync(c => c.Page == page);
            return contentAccessComponent;
        }
    }
}
