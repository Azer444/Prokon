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
    public class PrivacyComponentRepository : Repository<PrivacyComponent>, IPrivacyComponentRepository
    {
        private readonly ProkonContext db;

        public PrivacyComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<PrivacyComponent> GetAsync()
        {
            var privacyComponent = await db.PrivacyComponent.FirstOrDefaultAsync();
            return privacyComponent;
        }
    }
}
