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
    public class CareerFormComponentRepository : Repository<CareerFormComponent>, ICareerFormComponentRepository
    {
        private readonly ProkonContext db;

        public CareerFormComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<CareerFormComponent> GetAsync()
        {
            var careerFormComponent = await db.CareerFormComponent
                                                                .FirstOrDefaultAsync();
            return careerFormComponent;
        }
    }
}
