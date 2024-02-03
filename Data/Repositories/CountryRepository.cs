using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly ProkonContext db;

        public CountryRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async Task<List<SelectListItem>> GetSelectItems()
        {
            var countries = await db.Countries.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name_EN
            })
            .ToListAsync();

            return countries;
        }
    }
}
