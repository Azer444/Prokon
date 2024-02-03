using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetCurrentProjectsAsync();

        Task<List<Project>> GetCompletedProjectsAsync();

        Task<Project> GetBySlugAsync(string slug);

        Task<List<Project>> GetHomeProjectsAsync();

        Task RegulateSlugAsync(Project project);

        Task<int> AddLastCurrentOrderAsync();

        Task<Project> PrepareSplitedContentsAsync(Project project);
    }
}
