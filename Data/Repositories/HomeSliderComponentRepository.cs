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
    public class HomeSliderComponentRepository : Repository<HomeSliderComponent>, IHomeSliderComponentRepository
    {
        private readonly ProkonContext db;

        public HomeSliderComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<List<HomeSliderComponent>> GetAllByOrderDescendingAsync()
        {
            var homeSliderComponents = await db.HomeSliderComponents
                                                                .OrderByDescending(c => c.Id)
                                                                .ToListAsync();
            return homeSliderComponents;
        }
    }
}
