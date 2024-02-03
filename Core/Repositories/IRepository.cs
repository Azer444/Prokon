using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task EditAsync(T data);
        Task CreateAsync(T data);
        Task DeleteAsync(int? id);
        Task<int> GetCountAsync();
    }
}
