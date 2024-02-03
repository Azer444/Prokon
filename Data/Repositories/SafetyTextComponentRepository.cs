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
    public class SafetyTextComponentRepository : Repository<SafetyTextComponent>, ISafetyTextComponentRepository
    {
        private readonly ProkonContext db;

        public SafetyTextComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<SafetyTextComponent> GetAsync()
        {
            var textComponent = await db.SafetyTextComponent.FirstOrDefaultAsync();
            return textComponent;
        }
    }
}
