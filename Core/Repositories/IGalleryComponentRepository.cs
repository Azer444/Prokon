using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGalleryComponentRepository : IRepository<GalleryComponent>
    {
        Task<List<GalleryComponent>> GetHomeGalleryComponentsAsync();

        Task<List<int>> GetEmptyOrdersAsync();

        Task<List<int>> GetEmptyOrdersAsync(GalleryComponent galleryComponent);

        Task DeleteByProjectIdAsync(int? id);
    }
}
