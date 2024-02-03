using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAboutComponentRepository : IRepository<AboutComponent>
    {
        Task<AboutComponent> GetAsync();

        Task<AboutComponent> PrepareSplitedContentsAsync(AboutComponent aboutComponent);
    }
}
