using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICareerFormComponentRepository : IRepository<CareerFormComponent>
    {
        Task<CareerFormComponent> GetAsync();
    }
}
