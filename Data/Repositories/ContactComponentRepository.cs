using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class ContactComponentRepository : Repository<ContactComponent>, IContactComponentRepository
    {
        private readonly ProkonContext db;

        public ContactComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
