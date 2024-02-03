using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPartnerComponentRepository : IRepository<PartnerComponent>
    {
        Task<PartnerComponent> GetAsync();

        Task<PartnerComponent> PrepareSplitedContentsAsync(PartnerComponent partnerComponent);
    }
}
