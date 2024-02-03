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
    public class PageMainPhotoRepository : Repository<PageMainPhoto>, IPageMainPhotoRepository
    {
        private readonly ProkonContext db;

        public PageMainPhotoRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<PageMainPhoto> GetPageMainPhotoAsync(string page)
        {
            var mainPhoto = await db.PagesMainPhotos.FirstOrDefaultAsync(p => p.Page == page);
            return mainPhoto;
        }
    }
}
