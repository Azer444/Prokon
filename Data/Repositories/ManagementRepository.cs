using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ManagementRepository : Repository<Management>, IManagementRepository
    {
        public ManagementRepository(ProkonContext db)
            :base(db)
        {

        }
    }
}
