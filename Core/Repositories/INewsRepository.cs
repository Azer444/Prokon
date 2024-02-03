using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
        Task<List<News>> GetHomeNewsAsync();

        Task<List<News>> GetAllNewsAsync();

        Task<List<News>> GetAllCommunitiesAsync();

        Task<News> GetBySlugAsync(string slug);

        Task RegulateSlugAsync(News news);

        Task<News> GetPrevNewsAsync(News news);

        Task<News> GetNextNewsAsync(News news);
    }
}
