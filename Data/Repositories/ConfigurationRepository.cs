using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Models;

namespace Data.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ProkonContext db;

        public ConfigurationRepository(ProkonContext db)
        {
            this.db = db;
        }

        public async Task DefineAsync(SiteConfig siteConfig)
        {
            await db.SiteConfig.AddAsync(siteConfig);
        }

        public async Task EditAsync(SiteConfig siteConfig)
        {
            db.SiteConfig.Attach(siteConfig);
            db.Entry(siteConfig).State = EntityState.Modified;
        }

        public async Task<SiteConfig> GetAsync()
        {
            var configuration = await db.SiteConfig
                                            .Include(c=> c.FooterPartners)
                                            .FirstOrDefaultAsync();

            return configuration;
        }
    }
}
