using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Models;

namespace Data.Repositories
{
    public class AboutComponentRepository : Repository<AboutComponent>, IAboutComponentRepository
    {
        private readonly ProkonContext db;

        public AboutComponentRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async Task<AboutComponent> GetAsync()
        {
            var content = await db.AboutComponents
                                                .Include(c => c.AboutPhotos)
                                                .FirstOrDefaultAsync();
            return content;
        }

        public async Task<AboutComponent> PrepareSplitedContentsAsync(AboutComponent aboutComponent)
        {
            if (aboutComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();
                splitedContent_AZ.AddRange(aboutComponent.Content_AZ.Split("paragraph__"));
                aboutComponent.SplitedContent_AZ = splitedContent_AZ;
            }
            if (aboutComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();
                splitedContent_RU.AddRange(aboutComponent.Content_RU.Split("paragraph__"));
                aboutComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();
            splitedContent_EN.AddRange(aboutComponent.Content_EN.Split("paragraph__"));
            aboutComponent.SplitedContent_EN = splitedContent_EN;

            if (aboutComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();
                splitedContent_TR.AddRange(aboutComponent.Content_TR.Split("paragraph__"));
                aboutComponent.SplitedContent_TR = splitedContent_TR;
            }

            return aboutComponent;
        }
    }
}
