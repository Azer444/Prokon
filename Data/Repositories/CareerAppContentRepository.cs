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
    public class CareerAppContentRepository : Repository<CareerAppContent>, ICareerAppContentRepository
    {
        private readonly ProkonContext db;

        public CareerAppContentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<CareerAppContent> GetAsync()
        {
            var careerAppContent = await db.CareerAppContent
                                                            .FirstOrDefaultAsync();
            return careerAppContent;
        }
    }
}
