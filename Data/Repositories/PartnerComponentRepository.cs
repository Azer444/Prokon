using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PartnerComponentRepository : Repository<PartnerComponent>, IPartnerComponentRepository
    {
        private readonly ProkonContext db;

        public PartnerComponentRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async Task<PartnerComponent> GetAsync()
        {
            var partnerComponent = await db.ClientPartnerComponents
                                                                .FirstOrDefaultAsync();
            return partnerComponent;
        }

        public async Task<PartnerComponent> PrepareSplitedContentsAsync(PartnerComponent partnerComponent)
        {
            if (partnerComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();
                splitedContent_AZ.AddRange(partnerComponent.Content_AZ.Split("paragraph__"));
                partnerComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (partnerComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();
                splitedContent_RU.AddRange(partnerComponent.Content_RU.Split("paragraph__"));
                partnerComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();
            splitedContent_EN.AddRange(partnerComponent.Content_EN.Split("paragraph__"));
            partnerComponent.SplitedContent_EN = splitedContent_EN;

            if (partnerComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();
                splitedContent_TR.AddRange(partnerComponent.Content_TR.Split("paragraph__"));
                partnerComponent.SplitedContent_TR = splitedContent_TR;
            }

            return partnerComponent;
        }
    }
}
