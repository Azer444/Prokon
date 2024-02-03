using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class NavSubComponentRepository : Repository<NavSubComponent>, INavSubComponentRepository
    {
        public NavSubComponentRepository(ProkonContext db)
            :base(db)
        {

        }
    }
}
