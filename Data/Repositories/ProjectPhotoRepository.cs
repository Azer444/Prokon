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
    public class ProjectPhotoRepository : Repository<ProjectPhoto>, IProjectPhotoRepository
    {
        private readonly ProkonContext db;

        public ProjectPhotoRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<List<ProjectPhoto>> GetProjectPhotosAsync(int? id)
        {
            var projectPhotos = await db.ProjectPhotos
                                                .Where(pp => pp.ProjectId == id)
                                                .ToListAsync();
            return projectPhotos;
        }
    }
}
