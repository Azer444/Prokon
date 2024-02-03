using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class EthicsFileComponentRepository : Repository<EthicsFileComponent>, IEthicsFileComponentRepository
    {
        private readonly ProkonContext db;

        public EthicsFileComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
