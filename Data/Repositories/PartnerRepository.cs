using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        private readonly ProkonContext db;

        public PartnerRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
