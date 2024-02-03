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
    public class SectionLayoutContentRepository : Repository<SectionLayoutContent>, ISectionLayoutContentRepository
    {
        private readonly ProkonContext db;

        public SectionLayoutContentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<SectionLayoutContent> GetByNameAsync(string name)
        {
            var sectionLayoutContent = await db.SectionLayoutContents
                                                                .FirstOrDefaultAsync(c => c.SectionName == name);
            return sectionLayoutContent;
        }

        public async Task<List<SectionLayoutContent>> GetHomeSectionLayoutContentsAsync()
        {
            var homeSectionTitleContents = await db.SectionLayoutContents
                                                            .Where(c => c.SectionName == "project" ||
                                                            c.SectionName == "news" ||
                                                            c.SectionName == "licence" ||
                                                            c.SectionName == "gallery" ||
                                                            c.SectionName == "career")
                                                            .ToListAsync();
            return homeSectionTitleContents;
        }
    }
}
