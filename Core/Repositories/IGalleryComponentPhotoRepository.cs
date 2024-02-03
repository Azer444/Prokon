using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGalleryComponentPhotoRepository : IRepository<GalleryComponentPhoto>
    {
        Task<List<GalleryComponentPhoto>> GetGalleryComponentPhotosAsync(int? id);

        Task DeleteByPhotoName(string photoName);
    }
}
