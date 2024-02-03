using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Manage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public SitemapController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SitemapViewModel
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("sitemap"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("sitemap"),
                NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync()
            };

            return View(model);
        }
    }
}
