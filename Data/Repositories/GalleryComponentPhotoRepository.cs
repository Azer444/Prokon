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
    public class GalleryComponentPhotoRepository : Repository<GalleryComponentPhoto>, IGalleryComponentPhotoRepository
    {
        private readonly ProkonContext db;

        public GalleryComponentPhotoRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }


        public async override Task<GalleryComponentPhoto> GetAsync(int? id)
        {
            var galleryComponentPhoto = await db.GalleryComponentPhotos
                                                                       .Include(p => p.GalleryComponent)
                                                                       .FirstOrDefaultAsync(p => p.Id == id);
            return galleryComponentPhoto;
        }

        public async Task DeleteByPhotoName(string photoName)
        {
            var galleryComponentPhoto = await db.GalleryComponentPhotos
                                                                    .FirstOrDefaultAsync(p => p.PhotoName == photoName);
            if (galleryComponentPhoto != null)
                db.GalleryComponentPhotos.Remove(galleryComponentPhoto);
        }

        public async Task<List<GalleryComponentPhoto>> GetGalleryComponentPhotosAsync(int? id)
        {
            var galleryComponentPhotos = await db.GalleryComponentPhotos
                                                            .Where(gc => gc.GalleryComponentId == id)
                                                            .ToListAsync();
            return galleryComponentPhotos;
        }
    }
}
