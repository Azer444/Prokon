using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<List<SelectListItem>> GetSelectItems();
    }
}
