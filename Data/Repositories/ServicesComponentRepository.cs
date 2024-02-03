using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ServicesComponentRepository : Repository<ServicesComponent>, IServicesComponentRepository
    {
        private readonly ProkonContext db;

        public ServicesComponentRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async override Task<List<ServicesComponent>> GetAllAsync()
        {
            var servicesComponents = await db.ServicesComponents
                                                               .Include(sc => sc.ServicesComponentPhotos)
                                                               .ToListAsync();
            return servicesComponents;
        }

        public async override Task<ServicesComponent> GetAsync(int? id)
        {
            var servicesComponent = await db.ServicesComponents
                                                        .Include(sc => sc.ServicesComponentPhotos)
                                                        .FirstOrDefaultAsync(sc => sc.Id == id);
            return servicesComponent;
        }
    }
}
