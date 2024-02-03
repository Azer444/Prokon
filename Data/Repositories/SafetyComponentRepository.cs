using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class SafetyComponentRepository : Repository<SafetyComponent>, ISafetyComponentRepository
    {
        private readonly ProkonContext db;

        public SafetyComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
