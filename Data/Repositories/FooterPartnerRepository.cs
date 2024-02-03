using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class FooterPartnerRepository : Repository<FooterPartner>, IFooterPartnerRepository
    {
        private readonly ProkonContext db;

        public FooterPartnerRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
