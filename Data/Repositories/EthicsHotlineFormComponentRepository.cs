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
    public class EthicsHotlineFormComponentRepository : Repository<EthicsHotlineFormComponent>, IEthicsHotlineFormComponentRepository
    {
        private readonly ProkonContext db;

        public EthicsHotlineFormComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<EthicsHotlineFormComponent> GetAsync()
        {
            var formComponent = await db.EthicsHotlineFormComponent
                                                                .FirstOrDefaultAsync();
            return formComponent;
        }
    }
}
