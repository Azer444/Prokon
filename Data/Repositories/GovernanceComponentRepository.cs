﻿using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GovernanceComponentRepository : Repository<GovernanceComponent>, IGovernanceComponentRepository
    {
        public GovernanceComponentRepository(ProkonContext db)
            :base(db)
        {

        }
    }
}
