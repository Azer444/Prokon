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
    public class SiteConfigRepository : Repository<SiteConfig>, ISiteConfigRepository
    {
        private readonly ProkonContext db;

        public SiteConfigRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<SiteConfig> GetConfigAsync()
        {
            var siteConfig = await db.SiteConfig
                                        .Include(c => c.FooterPartners)
                                        .FirstOrDefaultAsync();
            return siteConfig;
        }
    }
}
