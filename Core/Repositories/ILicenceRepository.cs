using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ILicenceRepository : IRepository<Licence>
    {
        Task<List<Licence>> GetHomeLicencesAsync();

        Task<List<Licence>> GetByCountryNameAsync(string name);
    }
}
