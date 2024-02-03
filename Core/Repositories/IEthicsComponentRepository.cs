using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEthicsComponentRepository : IRepository<EthicsComponent>
    {
        Task<EthicsComponent> PrepareSplitedContentsAsync(EthicsComponent ethicsComponent);
    }
}
