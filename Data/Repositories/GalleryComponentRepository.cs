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
    public class GalleryComponentRepository : Repository<GalleryComponent>, IGalleryComponentRepository
    {
        private readonly ProkonContext db;

        public GalleryComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<List<GalleryComponent>> GetAllAsync()
        {
            var galleryComponents = await db.GalleryComponents
                                                            .OrderByDescending(c => c.Date)
                                                            .Include(g => g.GalleryComponentPhotos)
                                                            .ToListAsync();
            return galleryComponents;
        }

        public async override Task<GalleryComponent> GetAsync(int? id)
        {
            var galleryComponent = await db.GalleryComponents
                                    .Include(p => p.GalleryComponentPhotos)
                                    .FirstOrDefaultAsync(p => p.Id == id);
            return galleryComponent;
        }


        public async Task<List<int>> GetEmptyOrdersAsync()
        {
            var galleryComponents = await db.GalleryComponents
                                                        .Where(gc => gc.ShowOnHomePage)
                                                        .ToListAsync();

            var orders = new List<int> { 1, 2, 3, 4, 5, 6 };

            foreach (var galleryComponent in galleryComponents)
            {
                if (galleryComponent.Order != null)
                    orders.Remove((int)galleryComponent.Order);
            }

            return orders;
        }

        public async Task<List<int>> GetEmptyOrdersAsync(GalleryComponent galleryComponent)
        {
            var galleryComponents = await db.GalleryComponents
                                                      .Where(gc => gc.ShowOnHomePage)
                                                      .ToListAsync();

            var orders = new List<int> { 1, 2, 3, 4, 5, 6 };

            foreach (var galleryComponent_ in galleryComponents)
            {
                if (galleryComponent_.Order != null && galleryComponent_.Order != galleryComponent.Order)
                    orders.Remove((int)galleryComponent_.Order);
            }

            return orders;
        }

        public async Task<List<GalleryComponent>> GetHomeGalleryComponentsAsync()
        {
            var galleryComponents = await db.GalleryComponents
                                                        .Include(gc => gc.GalleryComponentPhotos)
                                                        .Where(gc => gc.ShowOnHomePage)
                                                        .ToListAsync();
            return galleryComponents;
        }

        public async Task DeleteByProjectIdAsync(int? id)
        {
            var galleryComponent = await db.GalleryComponents
                                                      .FirstOrDefaultAsync(gc => gc.ProjectId == id);
            if (galleryComponent != null)
                db.GalleryComponents.Remove(galleryComponent);
        }
    }
}
