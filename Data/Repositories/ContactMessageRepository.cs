using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactMessageRepository : Repository<ContactMessage>, IContactMessageRepository
    {
        private readonly ProkonContext db;

        public ContactMessageRepository(ProkonContext db)
            :base(db)
        {
            this.db = db;
        }

        public async override Task<List<ContactMessage>> GetAllAsync()
        {
            var contactMessages = await db.ContactMessages
                                                    .OrderByDescending(m => m.Id)
                                                    .ToListAsync();
            return contactMessages;
        }
    }
}
