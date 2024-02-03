using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProkonContext db;
        private readonly DbSet<T> dbTable;

        public Repository(ProkonContext db)
        {
            this.db = db;
            dbTable = db.Set<T>();
        }

        public async Task CreateAsync(T data)
        {
            await dbTable.AddAsync(data);
        }

        public async Task DeleteAsync(int? id)
        {
            var data = await dbTable.FindAsync(id);
            dbTable.Remove(data);
        }

        public async Task EditAsync(T data)
        {
            dbTable.Attach(data);
            db.Entry(data).State = EntityState.Modified;
        }

        public async virtual Task<T> GetAsync(int? id)
        {
            var data = await dbTable.FindAsync(id);
            return data;
        }

        public async virtual Task<List<T>> GetAllAsync()
        {
            return await dbTable.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await dbTable.CountAsync();
        }
    }
}
