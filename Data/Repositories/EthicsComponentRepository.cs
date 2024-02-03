using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EthicsComponentRepository : Repository<EthicsComponent>, IEthicsComponentRepository
    {
        private readonly ProkonContext db;

        public EthicsComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<EthicsComponent> PrepareSplitedContentsAsync(EthicsComponent ethicsComponent)
        {
            if (ethicsComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();
                splitedContent_AZ.AddRange(ethicsComponent.Content_AZ.Split("paragraph__"));
                ethicsComponent.SplitedContent_AZ = splitedContent_AZ;
            }
            if (ethicsComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();
                splitedContent_RU.AddRange(ethicsComponent.Content_RU.Split("paragraph__"));
                ethicsComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();
            splitedContent_EN.AddRange(ethicsComponent.Content_EN.Split("paragraph__"));
            ethicsComponent.SplitedContent_EN = splitedContent_EN;

            if (ethicsComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();
                splitedContent_TR.AddRange(ethicsComponent.Content_TR.Split("paragraph__"));
                ethicsComponent.SplitedContent_TR = splitedContent_TR;
            }

            return ethicsComponent;
        }
    }
}
