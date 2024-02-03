using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class ServicesComponentPhotoRepository : Repository<ServicesComponentPhoto>, IServicesComponentPhotoRepository
    {
        private readonly ProkonContext db;

        public ServicesComponentPhotoRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
