using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    public class EthicsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EthicsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var splitedEthicsComponents = new List<EthicsComponent>();
            var ethicsComponents = await unitOfWork.EthicsComponent.GetAllAsync();

            foreach (var ethicsComponent in ethicsComponents)
            {
                var splitedComponent = await unitOfWork.EthicsComponent.PrepareSplitedContentsAsync(ethicsComponent);
                splitedEthicsComponents.Add(splitedComponent);
            }

            var model = new EthicsViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics"),
                EthicsComponents = splitedEthicsComponents,
                EthicsFileComponents = await unitOfWork.EthicsFileComponent.GetAllAsync()
            };

            return View(model);
        }
    }
}
