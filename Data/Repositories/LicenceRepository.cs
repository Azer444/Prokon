using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class LicenceRepository : Repository<Licence>, ILicenceRepository
    {
        private readonly ProkonContext db;

        public LicenceRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async override Task<List<Licence>> GetAllAsync()
        {
            var licences = await db.Licences
                                      .Include(l => l.Country)
                                      .OrderByDescending(l => l.Id)
                                      .ToListAsync();
            return licences;
        }

        public async Task<List<Licence>> GetByCountryNameAsync(string name)
        {
            var licences = await db.Licences
                                            .Include(l => l.Country)
                                            .OrderByDescending(l => l.Id)
                                            .Where(l => l.Country.Name_EN == name)
                                            .ToListAsync();
            return licences;
        }

        public async Task<List<Licence>> GetHomeLicencesAsync()
        {
            var licences = await db.Licences
                                         .OrderByDescending(l => l.Id)
                                         .Take(6)
                                         .ToListAsync();
            return licences;
        }
    }
}
