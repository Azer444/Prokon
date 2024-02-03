using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Prokon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel()
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
                SectionLayoutContents = await unitOfWork.SectionLayoutContent.GetHomeSectionLayoutContentsAsync(),
                SliderComponents = await unitOfWork.HomeSliderComponent.GetAllByOrderDescendingAsync(),
                Projects = await unitOfWork.Project.GetHomeProjectsAsync(),
                News = await unitOfWork.News.GetHomeNewsAsync(),
                Licences = await unitOfWork.Licence.GetHomeLicencesAsync(),
                GalleryComponents = await unitOfWork.GalleryComponent.GetHomeGalleryComponentsAsync(),
                SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
            };

            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
