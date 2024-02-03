using Core.Models;
using Core.Repositories;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class GeneralApplyFileRepository : Repository<GeneralApplyFile>, IGeneralApplyFileRepository
    {
        private readonly ProkonContext db;

        public GeneralApplyFileRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }
    }
}
