using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ValuesComponentRepository : Repository<ValuesComponent>, IValuesComponentRepository
    {
        public ValuesComponentRepository(ProkonContext db)
            :base(db)
        {

        }
    }
}
