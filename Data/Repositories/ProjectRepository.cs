using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ProkonContext db;

        public ProjectRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async override Task<Project> GetAsync(int? id)
        {
            var project = await db.Projects
                                    .Include(p => p.GalleryComponent)
                                    .Include(p => p.ProjectPhotos)
                                    .FirstOrDefaultAsync(p => p.Id == id);
            return project;
        }

        public async Task<List<Project>> GetCompletedProjectsAsync()
        {
            var projects = await db.Projects
                                .OrderByDescending(p => p.CompletedDate)
                                .Where(p => p.Type == "completed")
                                .ToListAsync();
            return projects;
        }

        public async Task<List<Project>> GetCurrentProjectsAsync()
        {
            var projects = await db.Projects
                                .Where(p => p.Type == "current")
                                .OrderByDescending(p => p.CurrentOrder.HasValue)
                                .ThenBy(p => p.CurrentOrder)
                                .ToListAsync();
            return projects;
        }

        public async Task<List<Project>> GetHomeProjectsAsync()
        {
            var projects = await db.Projects
                                        .Where(p => p.ShowOnHomePage)
                                        .OrderByDescending(p => p.HomePageOrder.HasValue)
                                        .ThenBy(p => p.HomePageOrder)
                                        .ToListAsync();
            return projects;
        }

        public async Task<Project> GetBySlugAsync(string slug)
        {
            var project = await db.Projects
                                     .Include(p => p.GalleryComponent)
                                     .Include(p => p.ProjectPhotos)
                                     .FirstOrDefaultAsync(p => p.Slug == slug);
            return project;
        }

        public async Task RegulateSlugAsync(Project project)
        {
            if (db.Projects.Any(p => p.Id != project.Id && p.Slug == project.Slug))
                project.Slug = project.Slug + "-" + project.Id;

            db.Projects.Attach(project);
            db.Entry(project).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<int> AddLastCurrentOrderAsync()
        {
            var maxValue = await db.Projects.MaxAsync(p => p.CurrentOrder);

            if (!maxValue.HasValue)
                maxValue = 0;

            return (int)maxValue + 1;
        }

        public async Task<Project> PrepareSplitedContentsAsync(Project project)
        {
            if (project.Description_AZ != null)
            {
                List<string> splitedDescription_AZ = new List<string>();
                splitedDescription_AZ.AddRange(project.Description_AZ.Split("<p>paragraph__</p>"));
                project.SplitedDescription_AZ = splitedDescription_AZ;
            }
            if (project.Description_RU != null)
            {
                List<string> splitedDescription_RU = new List<string>();
                splitedDescription_RU.AddRange(project.Description_RU.Split("<p>paragraph__</p>"));
                project.SplitedDescription_RU = splitedDescription_RU;
            }

            if (project.Description_EN != null)
            {
                List<string> splitedDescription_EN = new List<string>();
                splitedDescription_EN.AddRange(project.Description_EN.Split("<p>paragraph__</p>"));
                project.SplitedDescription_EN = splitedDescription_EN;
            }

            if (project.Description_TR != null)
            {
                List<string> splitedDescription_TR = new List<string>();
                splitedDescription_TR.AddRange(project.Description_TR.Split("<p>paragraph__</p>"));
                project.SplitedDescription_TR = splitedDescription_TR;
            }

            return project;
        }
    }
}
