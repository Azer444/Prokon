using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NoticeComponentRepository : Repository<NoticeComponent>, INoticeComponentRepository
    {
        private readonly ProkonContext db;

        public NoticeComponentRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async Task<NoticeComponent> GetAsync()
        {
            var noticeComponent = await db.NoticeComponent.FirstOrDefaultAsync();
            return noticeComponent;
        }
    }
}
