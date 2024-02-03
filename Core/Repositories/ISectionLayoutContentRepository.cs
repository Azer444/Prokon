using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISectionLayoutContentRepository : IRepository<SectionLayoutContent>
    {
        Task<List<SectionLayoutContent>> GetHomeSectionLayoutContentsAsync();

        Task<SectionLayoutContent> GetByNameAsync(string name);
    }
}
