using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AboutPhotoRepository : Repository<AboutPhoto>, IAboutPhotoRepository
    {
        private readonly ProkonContext db;

        public AboutPhotoRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
