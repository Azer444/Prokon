using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPageAccessComponentRepository : IRepository<PageAccessComponent>
    {
        Task<PageAccessComponent> GetByPageNameAsync(string page);
    }
}
