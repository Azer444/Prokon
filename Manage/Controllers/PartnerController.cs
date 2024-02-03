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
    public class PartnerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PartnerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var partnerComponent = await unitOfWork.PartnerComponent.GetAsync();

            var model = new PartnerViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("partner"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("partner"),
                PartnerComponent = partnerComponent != null ? await unitOfWork.PartnerComponent.PrepareSplitedContentsAsync(partnerComponent) : null,
                Partners = await unitOfWork.Partner.GetAllAsync()
            };

            return View(model);
        }
    }
}
