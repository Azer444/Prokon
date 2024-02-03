using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                var mainNews = await unitOfWork.News.GetBySlugAsync(id);
                var model = new NewsViewModel()
                {
                    HeaderPartialViewModel = new HeaderPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    FooterPartialViewModel = new FooterPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    MobileMenuPartialViewModel = new MobileMenuPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("news"),
                    PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("news"),
                    MainNews = mainNews,
                    PreviousNews = mainNews != null ? await unitOfWork.News.GetPrevNewsAsync(mainNews) : null,
                    NextNews = mainNews != null ? await unitOfWork.News.GetNextNewsAsync(mainNews) : null
                };

                return View(model);
            }

            return NotFound();
        }
    }
}
