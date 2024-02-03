using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CareerComponentRepository : Repository<CareerComponent>, ICareerComponentRepository
    {
        private readonly ProkonContext db;

        public CareerComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<List<CareerComponent>> GetAllByTypeAsync(string type)
        {
            var careerComponents = await db.CareerComponents
                                                         .Where(c => c.Type == type)
                                                         .ToListAsync();
            return careerComponents;
        }
    }
}
