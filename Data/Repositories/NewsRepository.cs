using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly ProkonContext db;

        public NewsRepository(ProkonContext db)
            : base(db)
        {
            this.db = db;
        }

        public async Task<List<News>> GetAllCommunitiesAsync()
        {
            var communities = await db.News
                                    .OrderByDescending(n => n.CreatedAt)
                                    .Where(n => n.Type == "community")
                                    .ToListAsync();
            return communities;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            var news = await db.News
                                    .OrderByDescending(n => n.CreatedAt)
                                    .Where(n => n.Type == "news")
                                    .ToListAsync();
            return news;
        }

        public async Task<News> GetBySlugAsync(string slug)
        {
            var news = await db.News
                                   .FirstOrDefaultAsync(n => n.Slug == slug);
            return news;
        }

        public async Task RegulateSlugAsync(News news)
        {
            if (db.News.Any(n => n.Id != news.Id && n.Slug == news.Slug))
                news.Slug = news.Slug + "-" + news.Id;

            db.News.Attach(news);
            db.Entry(news).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<News>> GetHomeNewsAsync()
        {
            var news = await db.News
                            .OrderByDescending(n => n.CreatedAt)
                            .Take(2)
                            .ToListAsync();
            return news;
        }

        public async Task<News> GetPrevNewsAsync(News news)
        {
            var previousNews = await db.News
                                    .Where(n => n.CreatedAt < news.CreatedAt)
                                    .OrderByDescending(n => n.CreatedAt)
                                    .Take(1)
                                    .FirstOrDefaultAsync();
            return previousNews;
        }

        public async Task<News> GetNextNewsAsync(News news)
        {
            var nextNews = await db.News
                                    .Where(n => n.CreatedAt > news.CreatedAt)
                                    .OrderBy(n => n.CreatedAt)
                                    .Take(1)
                                    .FirstOrDefaultAsync();
            return nextNews;
        }
    }
}
